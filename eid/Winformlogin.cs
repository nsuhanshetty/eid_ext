using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
        DataTable dt = new DataTable();

        // MysqlConn ObjData = new MysqlConn();
        WinformMainmenu wfMain = new WinformMainmenu();

        # endregion 'ConstructorsAndPrivateVariables
                
        #region 'PrivateMethods

        private void btncncl_Click(object sender, EventArgs e)
        {             
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                disableMenu();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            statusStrip1.Text = "Authenticating..";
            
            //compare txt and db values            
            if (string.IsNullOrEmpty(txtusernm.Text) || string.IsNullOrEmpty(txtpasswd.Text))
            {
                MessageBox.Show("Username and Password are Mandatory." + Environment.NewLine + "Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                statusStrip1.Text = "Waiting for User's input...";
                return;
            }
            else
            {
                userId = MysqlConn.returnFirstCell("select USPUSERID from userprivilege where USPUSERNAME='" + txtusernm.Text + "' and USPPASSWORD='" + txtpasswd.Text + "' and USPdeleted='N' Limit 1");
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

            //insert into the log table
            qry = "insert into log_table(LT_USER_ID,LT_DATE_ENTRY,LT_TIME_OF_ENTRY)values ('" + (int)userId + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToShortTimeString() + "')";
            no_rows = MysqlConn.executeQry(qry);

            //collect respective user attributes 
            qry = "select UA_menu,UA_enable from user_attribute where UA_user_id='" + userId + "'";
            dt = MysqlConn.getDataTable(qry);

            enableMenu();
        }

        private void enableMenu()
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
                        subitem.Enabled = Convert.ToBoolean(this.dt.Rows[this.menuno][1]);
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
