using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using eid.Savers;

namespace eid
{
    /// <summary>
    /// Login Methods.
    /// </summary>
    public partial class Winformlogin : Form
    {
        # region 'ConstructorsAndPrivateVariables
        public Winformlogin()
        {
            InitializeComponent();
        }

        public Winformlogin(WinformMainmenu wfmain)
        {
            InitializeComponent();
            this.wfMain = wfmain;
        }


        int no_rows = 0;
        string qry = "";
        Object userId = null;
        int index = 0;
        int menuno = 0;


        WinformMainmenu wfMain = new WinformMainmenu();

        # endregion 'ConstructorsAndPrivateVariables

        #region 'PrivateMethods

        private void btncncl_Click(object sender, EventArgs e)
        {
            disableMenu();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            UserMasterSaver userMasterSaver = new UserMasterSaver();
            LogSaver logsaver = new LogSaver();

            statusStrip1.Text = "Authenticating..";
            Cursor.Current = Cursors.WaitCursor;

            #region compare txt and db values
            if (string.IsNullOrEmpty(txtusernm.Text) || string.IsNullOrEmpty(txtpasswd.Text))
            {
                MessageBox.Show("Username and Password are Mandatory." + Environment.NewLine + "Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusStrip1.Text = "Waiting for User's input...";
                return;
            }
            else
            {
                userId = userMasterSaver.fetchUSPID(txtusernm.Text, txtpasswd.Text);
                if (userId == null)
                {
                    MessageBox.Show("Username / Password is Incorrect." + Environment.NewLine + "Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusStrip1.Text = "Waiting for User's input...";
                    disableMenu();
                    return;
                }
                //on match continue..
                User.UserId = (int)userId;
            }
            #endregion compare txt and db values


            logsaver.insert((int)userId, DateTime.Now.Date.ToString("yyyy-MM-dd"), DateTime.Now.ToShortTimeString());
            dt = userMasterSaver.FetchUserAttribute(userId);
            enableMenu(dt);
            Cursor.Current = Cursors.Default;
        }

        private void enableMenu(DataTable dt)
        {
            foreach (ToolStripMenuItem item in wfMain.Mainmenustrip.Items.OfType<ToolStripMenuItem>())
                if (index < 2)
                {
                    //index = count to restrict the loop to master and utilities
                    index++;
                    foreach (ToolStripMenuItem subitem in item.DropDownItems.OfType<ToolStripMenuItem>())
                    {
                        //menuno = represents each row of user attribute in dt 
                        if ((item.Enabled == false) && ((int)dt.Rows[this.menuno][1] == 1))
                            item.Enabled = true;
                        subitem.Enabled = Convert.ToBoolean(dt.Rows[this.menuno][1]);
                        menuno++;
                    }
                }
            this.Close();

        }

        private void disableMenu()
        {
            foreach (ToolStripMenuItem item in wfMain.Mainmenustrip.Items.OfType<ToolStripMenuItem>())
                if (index < 2)
                {
                    //index = count to restrict the loop to master and utilities
                    index++;
                    foreach (ToolStripMenuItem subitem in item.DropDownItems.OfType<ToolStripMenuItem>())
                    {
                        if (item.Enabled == true)
                        {
                            item.Enabled = false;
                            subitem.Enabled = false;
                        }
                    }
                }
            this.Close();
        }

        #endregion 'PrivateMethods
    }
}
