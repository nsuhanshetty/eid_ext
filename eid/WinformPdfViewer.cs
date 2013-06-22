using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using eid.Report;

namespace eid
{
 
    public partial class WinformPdfViewer : Form
    {
        ErrorDump ed = new ErrorDump();
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
                     string qry = "Select * from employee_registry where ER_EMP_NO='" + EmpNo + "'";
                     dt = MysqlConn.getDataTable(qry);
                     string reportpath = Application.StartupPath + "\\Report\\BioData.rpt";               
                     rptDoc.Load(reportpath);
                 }
                 else
                 {
                     dt = MysqlConn.getDataTable("Select ED_EMP_NAME,ED_CREATED_ON from employee_details where ED_EMP_NO='" + EmpNo + "'");
                     rptDoc.Load(".//Reports/IdCard.rpt");
                 }
                 ds.Tables[0].Merge(dt);

                 //set dataset to the report viewer.
                 rptDoc.SetDataSource(ds);

                 //convert rpt to pdf            
                 ExportOptions CrExportOptions;
                 DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                 PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                 CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath +"\\sample.pdf";
                 CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
                 CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                 CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                 CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                 CrExportOptions.FormatOptions = CrFormatTypeOptions;
                 rptDoc.Export();

                 //view pdf in webbrowser
                 
                 // Set the Url property to load the document.
                 WebBrows.Url = new Uri(@""+Application.StartupPath +"\\sample.pdf");
                 //wait until its loaded.
                 while (WebBrows.ReadyState!=WebBrowserReadyState.Complete)
                 {
                     //wait until document is loaded 
                 }
                 btnPrint.Enabled = true;
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
