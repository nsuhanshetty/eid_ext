using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using eid.Report;

namespace eid
{
 
    public partial class WinformPdfViewer : Form
    {
        ErrorDump ed = new ErrorDump();
        WinformReportViewer rpv = new WinformReportViewer();
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

             try
             {
                 this.Cursor = Cursors.WaitCursor;
                 btnPrint.Enabled = false;

                 //load dataset
                 // load report to rptdoc
                 ReportDocument rptDoc = new ReportDocument();
                 dsBiodata ds = new dsBiodata();
                 DataTable dt = new DataTable();
                 if (PrintOpt == "Bio")
                 {
                     //Select reg.*, proof.EP_EMP_PIC from employee_registry as reg LEFT JOIN employee_proof as proof 
                     //on reg.ER_EMP_NO= proof.EP_EMP_NO 
                     //where proof.EP_EMP_NO='24567890' 
                     //ORDER BY reg.ER_EMP_NO

                     string qry = "Select reg.*, proof.EP_EMP_PIC from employee_registry as reg  LEFT JOIN employee_proof as proof";
                     qry += " on reg.ER_EMP_NO = proof.EP_EMP_NO ";
                     qry += "where reg.ER_EMP_NO='" + EmpNo + "'";

                     dt = MysqlConn.getDataTable(qry);
                     //get the image location from dt
                     string path = Convert.ToString(dt.Rows[0]["EP_EMP_PIC"]);

                     //if path !=null
                     if (!string.IsNullOrEmpty(path))
                     {
                         if (File.Exists(path))
                         {
                             // add the column in table to store the image of Byte array type 
                             dt.Columns.Add("ER_EMP_PIC", System.Type.GetType("System.Byte[]"));

                             // open image in file stream 
                             using (FileStream fs = new FileStream(path, FileMode.Open))
                             {
                                 // initialise the binary reader from file streamobject 
                                 using (BinaryReader br = new BinaryReader(fs))
                                 {
                                     // define the byte array of filelength 
                                     byte[] imgbyte = new byte[fs.Length + 1];
                                     // read the bytes from the binary reader 
                                     imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                                     dt.Rows[0]["ER_EMP_PIC"] = imgbyte;
                                 }
                                 // close the binary reader 
                             }
                             string reportpath = Application.StartupPath + "\\Report\\BioData.rpt";
                             rptDoc.Load(reportpath);
                             RptView.ReportSource = rptDoc;
                         }
                     }
                 }
                 else
                 {
                     dt = MysqlConn.getDataTable("Select ED_EMP_NAME,ED_CREATED_ON from employee_details where ED_EMP_NO='" + EmpNo + "'");
                     rptDoc.Load(".//Reports/IdCard.rpt");
                 }
                 ds.Tables[0].Merge(dt);

                 //set dataset to the report viewer.
                 rptDoc.SetDataSource(ds);


                 ////convert rpt to pdf            
                 //ExportOptions CrExportOptions;
                 //DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                 //PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                 //CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath +"\\sample.pdf";
                 //CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
                 //CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                 //CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                 //CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                 //CrExportOptions.FormatOptions = CrFormatTypeOptions;
                 //rptDoc.Export();

                 ////view pdf in webbrowser
                 
                 //// Set the Url property to load the document.
                 //WebBrows.Url = new Uri(@""+Application.StartupPath +"\\sample.pdf");
                 ////wait until its loaded.
                 //while (WebBrows.ReadyState!=WebBrowserReadyState.Complete)
                 //{
                 //    //wait until document is loaded 
                 //}
                 //btnPrint.Enabled = true;
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
    }
}
