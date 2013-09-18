using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
//using eid.Report;
using Microsoft.Reporting.WinForms;

namespace eid
{
    public partial class WinformPdfViewer : Form
    {
        ErrorDump ed = new ErrorDump();
        ImageResize imageResizer = new ImageResize();
        private string mEmpNo;
        public string EmpNo
        {
            get
            {
                return mEmpNo;
            }
            set
            {
                mEmpNo = value;
            }
        }

        public WinformPdfViewer()
        {
            InitializeComponent();
        }

        public WinformPdfViewer(string EmpNo)
        {
            InitializeComponent();
            this.EmpNo = EmpNo;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grbPrintOpt_Enter(object sender, EventArgs e)
        {
            string PrintOpt = (rdbBiodata.Checked) ? "Bio" : "Id";
            string qry = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnPrint.Enabled = false;

                ReportDocument rptDoc = new ReportDocument();
                dsBiodata ds = new dsBiodata();
                DataTable dt = new DataTable();
                ReportDataSource rptDataSource;
                string reportpath;

                if (PrintOpt == "Bio")
                {
                    qry = "Select reg.*, proof.EP_EMP_PIC from employee_registry as reg  LEFT JOIN employee_proof as proof";
                    qry += " on reg.ER_EMP_NO = proof.EP_EMP_NO ";
                    qry += "where reg.ER_EMP_NO='" + EmpNo + "'";

                    dt = MysqlConn.getDataTable(qry);

                    dt.Columns.Add("TEMP_EMP_DOB", System.Type.GetType("System.String"));
                    dt.Columns.Add("TEMP_EMP_NOCHILD", System.Type.GetType("System.String"));
                    dt.Columns.Add("TEMP_EMP_DOM", System.Type.GetType("System.String")); 

                    //alter ER_EMP_DOB  
                    dt.Rows[0]["TEMP_EMP_DOB"] = Convert.ToDateTime(dt.Rows[0]["ER_EMP_DOB"]).ToString("dd/MM/yyyy"); 

                    //alter ER_EMP_NOCHILD
                    dt.Rows[0]["TEMP_EMP_NOCHILD"] = (DBNull.Value.Equals(dt.Rows[0]["ER_EMP_NOCHILD"])) ? "N/A" : dt.Rows[0]["ER_EMP_NOCHILD"].ToString();

                    //alter ER_EMP_DOM
                    dt.Rows[0]["TEMP_EMP_DOM"] = DBNull.Value.Equals(dt.Rows[0]["ER_EMP_DOM"])?"N/A":
                        (Convert.ToDateTime(dt.Rows[0]["ER_EMP_DOM"]).ToString("dd/MM/yyyy"));

                    //alter ER_WIFE_NAME
                    dt.Rows[0]["ER_WIFE_NAME"] = (DBNull.Value.Equals(dt.Rows[0]["ER_WIFE_NAME"])) ? "N/A" : dt.Rows[0]["ER_WIFE_NAME"].ToString();

                    ds._dsBiodata.Merge(dt);
                    reportpath = Application.StartupPath + "\\Report\\repBiodata.rdlc";
                    rptDataSource = new ReportDataSource("dsBiodata", (DataTable)ds._dsBiodata);
                }
                else
                {
                    qry = "Select reg.ER_EMP_NO,reg.ER_EMP_NAME,proof.EP_EMP_PIC from employee_registry as reg  LEFT JOIN employee_proof as proof";
                    qry += " on reg.ER_EMP_NO = proof.EP_EMP_NO ";
                    qry += "where reg.ER_EMP_NO='" + EmpNo + "'";
                    dt = MysqlConn.getDataTable(qry);

                    dt.Columns.Add("ER_EMP_PIC", System.Type.GetType("System.String"));
                    dt.Rows[0]["ER_EMP_PIC"] = "file:///" + Convert.ToString(dt.Rows[0]["EP_EMP_PIC"]) + ".jpg";
                    dt.Columns.Remove("EP_EMP_PIC");
                    ds.dsIdCard.Merge(dt);
                    reportpath = Application.StartupPath + "\\Report\\IDCard.rdlc";
                    rptDataSource = new ReportDataSource("DataSet1", (DataTable)ds.dsIdCard);
                }

                rptView.Reset();
                rptView.LocalReport.ReportPath = reportpath;
                rptView.LocalReport.DisplayName = (rdbBiodata.Checked) ? "Resume" : "ID Card Print";
                rptView.LocalReport.DataSources.Clear();
                rptView.LocalReport.DataSources.Add(rptDataSource);
                rptView.LocalReport.EnableExternalImages = true;
                rptView.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                ed.WriteToErrorLog(ErrorDump.ErrorDumpErrorLogType.Critical, ex, "Load Report Failed");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Print the document now that it is fully loaded.
            ((WebBrowser)sender).Print();

            // Dispose the WebBrowser now that the task is complete. 
            ((WebBrowser)sender).Dispose();
        }

        private void WinformPdfViewer_Load(object sender, EventArgs e)
        {
            this.rptView.RefreshReport();
        }
    }
}

