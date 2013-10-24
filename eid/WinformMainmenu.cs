using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace eid
{
    public partial class WinformMainmenu : Form
    {
        #region 'PrpertiesAndVariables
        private int childFormNumber = 0;
        DataTable dt = new DataTable();
        #endregion 'PropertiesAndVariables

        public WinformMainmenu()
        {
            InitializeComponent();
        }

        #region 'PrivateMethods

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void frmMain_KeyDown(Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
                Loginbtn_Click(sender, e);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AboutustoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //WinformAboutus WinformAboutus = new WinformAboutus();
            // WinformAboutus.Show();
        }

        private void CalculatorAccess_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            Winformlogin wfLogin = new Winformlogin(this);
            wfLogin.ShowDialog();
        }

        private void Staffdetails_Click(object sender, EventArgs e)
        {
            WinformEmpReg wfEmpReg = new WinformEmpReg();
            wfEmpReg.ShowDialog();
        }

        private void UserMasterAccess_Click(object sender, EventArgs e)
        {
            WinformUsermaster wfUserMast = new WinformUsermaster();
            wfUserMast.ShowDialog();
        }

        private void WinformMainmenu_Load(object sender, EventArgs e)
        {
            // Winformlogin login = new Winformlogin();
            // login.Show();            
        }

        private void ChangePasswordAccess_Click(object sender, EventArgs e)
        {
            WinformChangepass wfChangepass = new WinformChangepass();
            wfChangepass.ShowDialog();
        }

        private void CalculatorAccess_Click_1(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void BackupDataAccess_Click(object sender, EventArgs e)
        {
            #region savedialog_property
            saveFileDialog1.Title = "BacK Up Dialog";
            saveFileDialog1.Filter = "SQL Files (*.sql)|*.sql";
            saveFileDialog1.FileName = "Backup" + DateTime.Now.ToString("dd-MM-yyyy");
            #endregion savedialog_property

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string path = saveFileDialog1.FileName;
            if (path != "")
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.WorkingDirectory = Application.StartupPath;
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.Start();
                StreamWriter myStreamWriter = myProcess.StandardInput;
                StreamReader mystreamreader = myProcess.StandardOutput;
                myStreamWriter.WriteLine("mysqldump -u sa -psshetty --databases=privateeyeeid>" + path);
                myStreamWriter.Close();
                myProcess.WaitForExit();
                myProcess.Close();
            }
            else
                MessageBox.Show("No Values Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void UpdatetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            winformUpdate wfUpdate = new winformUpdate();
            wfUpdate.ShowDialog();
        }

        private void Exitmenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion 'PrivateMethods

 
    }
}
