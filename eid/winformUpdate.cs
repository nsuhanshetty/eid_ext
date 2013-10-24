using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic.Devices;

namespace eid
{
    public partial class winformUpdate : Form
    {
        public string serverVersion { get; set; }

        public winformUpdate()
        {
            InitializeComponent();
        }

        private void winformUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                checkIfFileExist(Application.StartupPath + "\\UpdateVersionLog.zip");

                #region download the File from server
                Network network = new Network();
                try
                {
                    network.DownloadFile("http://kayakkitchen.com/privateeye/UpdateVersionLog.zip", Application.StartupPath + "\\UpdateVersionLog.zip");
                }
                catch (Exception ex)
                {
                    ErrorDump er = new ErrorDump();
                    er.WriteToErrorLog(ErrorDump.ErrorDumpErrorLogType.Critical, ex, "Unable to Download the UpdateVersionLog File");
                }
                #endregion download the File from server

                string updateVersionLogPath = Application.StartupPath + "\\updateVersionLog";

                #region Create_updateVersionLogPath_Directory_ifNotExist
                if (!Directory.Exists(updateVersionLogPath))
                    Directory.CreateDirectory(updateVersionLogPath);
                #endregion Create_updateVersionLogPath_Directory_ifNotExist

                checkIfFileExist(updateVersionLogPath + "\\updateVersionLog.xml");

                #region unzip the file
                try
                {
                    ZipFile.ExtractToDirectory(Application.StartupPath + "\\UpdateVersionLog.zip", updateVersionLogPath);
                }
                catch (Exception ex)
                {
                    ErrorDump er = new ErrorDump();
                    er.WriteToErrorLog(ErrorDump.ErrorDumpErrorLogType.Critical, ex, "Unable to Extract the UpdateVersionLog File");
                }
                File.Delete(Application.StartupPath + "\\UpdateVersionLog.zip");
                #endregion unzip the file

                #region compare current version are equal to server versions
                string appVersion = ConfigurationManager.AppSettings["Version"];
                lblVersion.Text = "Version: " + appVersion;
                serverVersion = readXmlValue(Application.StartupPath + "\\updateVersionLog\\updateVersionLog.xml");

                if (appVersion == serverVersion)
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.Text = "Secusys-EID is upto date";
                }
                else
                {
                    btnUpdate.Enabled = true;
                    btnUpdate.Text = "Secusys-EID Update is available";
                }
                #endregion
            }
            catch (Exception ex)
            {
                ErrorDump ed = new ErrorDump();
                ed.WriteToErrorLog(ErrorDump.ErrorDumpErrorLogType.Critical, ex, "Update Failed.");
                MessageBox.Show("Something Nasty Happened. Please try Again.", "Secusys - EID Update", MessageBoxButtons.OK);
            }
        }

        private void checkIfFileExist(string Path)
        {
            if (File.Exists(Path))
                File.Delete(Path);
        }

        private string readXmlValue(string Path)
        {
            string value;
            DataSet ds = new DataSet();
            FileStream fsReadXml = new FileStream(Path, System.IO.FileMode.Open);
            using (fsReadXml)
            {
                ds.ReadXml(fsReadXml);
                value = (string)ds.Tables[0].Rows[0]["Version"];
            }
            return value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                checkIfFileExist(Application.StartupPath + "\\UpdateExeFile.zip");

                #region download the Update File from server
                Network network = new Network();
                try
                {
                    network.DownloadFile("http://kayakkitchen.com/privateeye/UpdateExeFile.zip", Application.StartupPath + "\\UpdateExeFile.zip");
                }
                catch (Exception ex)
                {
                    ErrorDump er = new ErrorDump();
                    er.WriteToErrorLog(ErrorDump.ErrorDumpErrorLogType.Critical, ex, "Unable to Download the Update File");
                }
                #endregion download the Update File from server

                #region unzip the file
                try
                {
                    ZipFile.ExtractToDirectory(Application.StartupPath + "\\UpdateExeFile.zip", Application.StartupPath);
                }
                catch (Exception ex)
                {
                    ErrorDump er = new ErrorDump();
                    er.WriteToErrorLog(ErrorDump.ErrorDumpErrorLogType.Critical, ex, "Unable to Extract the Update File");
                }
                #endregion unzip the file

                #region writeupdated Version No.
                XmlDocument xml = new XmlDocument();
                xml.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("Version");
                config.AppSettings.Settings.Add("Version", serverVersion);
                config.Save(ConfigurationSaveMode.Minimal);
                xml.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("appSettings");
                #endregion writeupdated Version No.

                File.Delete(Application.StartupPath + "\\updateVersionLog\\updateVersionLog.xml");
                File.Delete(Application.StartupPath + "\\UpdateExeFile.zip");
                Process.Start(Application.StartupPath + "\\updateHelper.exe");
                mailUpdateConfirmation(serverVersion);

                Application.Exit();
            }
            catch (Exception ex)
            {
                ErrorDump ed = new ErrorDump();
                ed.WriteToErrorLog(ErrorDump.ErrorDumpErrorLogType.Critical, ex, "Update Failed.");
                MessageBox.Show("Update Failed. Please try Again.", "Secusys - EID Update", MessageBoxButtons.OK);
            }
        }

        private void mailUpdateConfirmation(string version)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("nsuhanshetty@gmail.com");
                message.To.Add(new MailAddress("nsuhanshetty@gmail.com"));
                message.Subject = "Secusys-EID Update Confirmation";
                message.Body = "Secusys_EID updated to Version " + version + " taken by User Id " + User.UserId + " at " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("nsuhanshetty@gmail.com", " Surendra");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }
    }
}
