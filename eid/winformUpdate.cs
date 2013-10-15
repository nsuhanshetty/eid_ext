using System;
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
            #region download the File from server
            Network network = new Network();
            network.DownloadFile("http://kayakkitchen.com/privateeye/UpdateLog.zip", Application.StartupPath + "\\UpdateLog.zip");
            #endregion download the File from server

            #region unzip the file
            string updatePath = Application.StartupPath + "//updateVersionLog";
            ZipFile.ExtractToDirectory(Application.StartupPath + "//updateVersionLog.zip", updatePath);
            File.Delete(updatePath);
            #endregion unzip the file

            #region compare current version are equal to server versions
            string appVersion = readXmlValue(Application.StartupPath + "//appversion.xml");
            lblVersion.Text = "Version: " + appVersion;
            serverVersion = readXmlValue(Application.StartupPath + "//updateVersionLog//updateVersionLog.xml");

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
            Process.Start(Application.StartupPath + "\\updater.exe");

            #region writeupdated Version No.
            XmlDocument xmlDoc = new XmlDocument();
            using (FileStream fsWriteXml = new FileStream(Application.StartupPath + "//appversion.xml", System.IO.FileMode.Open))
            {
                xmlDoc.Load(fsWriteXml);
                XmlNodeList nodeList = xmlDoc.SelectNodes("/updateLog/Version");
                nodeList[0].InnerXml = "0.0.0.3";// serverVersion;    
            }
            xmlDoc.Save(Application.StartupPath + "//appversion.xml");
            #endregion writeupdated Version No.

            File.Delete(Application.StartupPath + "//updateVersionLog//updateVersionLog.xml");

            mailUpdateLog(serverVersion);

            Application.Exit();
        }

        private void mailUpdateLog(string version)  
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("nsuhanshetty@gmail.com");
                message.To.Add(new MailAddress("nsuhanshetty@gmail.com"));
                message.Subject = "Secusys-EID Update Confirmation";
                message.Body = "Secusys_EID updated to Version " + version + " taken by User Id " + User.UserId + " at "+ DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +".";

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
