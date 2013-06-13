using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eid
{
    public partial class WinformUsermaster : WinformAbstract
    {
        # region 'PropertiesAndVariables

        string qry ="";
        Common com = new Common();      
        DataTable dt = new DataTable();
        //MysqlConn objData = new MysqlConn();
        WinformAbstract wfAbs = new WinformAbstract();
        WinformMainmenu wfMain = new WinformMainmenu();                                               

        private bool mdelete;
        private bool DeleteState
        {
            get
            {
                return mdelete;
            }
            set
            {
                mdelete = value;
            }
        }

        private bool _update;
        private bool UpdateState
        {
            get
            {
                return _update;
            }
            set
            {
                _update = value;
            }
        }
    # endregion 'PropertiesAndVariables

        public WinformUsermaster()
        {
            InitializeComponent();
        }

        # region PrivateAndProtectedMethods

        private void WinformUsermaster_Load(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            
           // LOADCHECKBX();
            pnlUsrNew.Visible = false;
            pnlUsrView.Visible = false;

            //set location of the pnlView
            pnlUsrView.Location = new Point(12, 81);
            this.Size = new Size(350, 524);
        }

        protected override void btnnew_Click(object sender, EventArgs e)
        {
            //enable / Disable the controls
            MenuMode(this, false);
            this.pnlUsrNew.Visible = true;
            this.GrbxNewUser.Enabled = true;
            this.pnlUsrView.Visible = false;
            
            //all the checkbox are checked
            LoadCheckBox("");
        }

        protected override void btnmodify_Click(object sender, EventArgs e)
        {
            //MenuMode(this, false);
            DeleteState = false;
            txtSrchUserName.Text = "";
            this.pnlUsrNew.Visible = false;
            this.pnlUsrView.Visible = true;         
            
            lblMessage.Text = "Double Click the Username to Modify the User Privleges.";
                        
            LoadDGV();
        }

        protected override void btndelete_Click(object sender, EventArgs e)
        {
            DeleteState = true;
            txtSrchUserName.Text = "";
            this.pnlUsrNew.Visible = false;
            this.pnlUsrView.Visible = true;           
            
            lblMessage.Text = "Double Click the Username to delete the User.";
            
            //load the datagrid with checkboxes
            LoadDGV();
        }

        protected override void btnsave_Click(object sender, EventArgs e)
        {
            //Check if textbox null or empty
            if (string.IsNullOrEmpty(txtUsrname.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtConPass.Text))
            {
                MessageBox.Show("Username and Password are Mandatory." + Environment.NewLine + "Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if pass and con pass match
            if (string.Compare(txtConPass.Text, txtPass.Text) != 0)
            {
                MessageBox.Show("Password and Confirm Password do not match." + Environment.NewLine + "Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = string.Empty;
                txtUsrname.Focus();
                txtUsrname.Text = string.Empty;
                txtConPass.Text = string.Empty;
                return;
            }           


                if (UpdateState != true)
                {
                    //save user into DB
                    qry = "insert into userprivilege(USPUSERNAME,USPPASSWORD,USPCREATEDBY,USPCREATEDON)values('" + txtUsrname.Text + "','" + txtPass.Text + "','" + User.UserId + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                    MysqlConn.executeQry(qry);

                    qry = "Select USPUSERID from userprivilege where USPUSERNAME='" + txtUsrname.Text + "'";
                    int USPUserid = (int)MysqlConn.returnFirstCell(qry);

                    //save userAttribute into DB
                    for (int i = 0; i< this.chklstbx.Items.Count; i++)
                    {
                        qry = "insert into user_attribute(UA_user_id,UA_menu,UA_enable,UA_CREATEDBY,UA_CREATEDON)values('" + USPUserid + "','" + i + "','" + Convert.ToInt16(this.chklstbx.GetItemChecked(i)) + "'," + com.qrytime("ins") + ")";
                        MysqlConn.executeQry(qry);
                        //status bar value inserted                   
                    }
                }

                else
                //for updates
                //save user into DB
                {
                    qry = "Select USPUSERID from userprivilege where USPUSERNAME='" + txtUsrname.Text + "'";
                    int USPUserid = (int)MysqlConn.returnFirstCell(qry);

                    qry = "update userprivilege set USPMODIFIEDBY='" + User.UserId + "',USPMODIFIEDON='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where USPUSERID='" + USPUserid + "'";
                    MysqlConn.executeQry(qry);
                    for (int i = 0; i < this.chklstbx.Items.Count; i++)
                    {
                        qry = "update user_attribute set UA_enable='" + Convert.ToInt16(this.chklstbx.GetItemChecked(i)) + "'," + com.qrytime("upd", "UA_") +
                            " where  UA_user_id='" + USPUserid + "' and UA_menu='" + i + "'";
                        MysqlConn.executeQry(qry);
                    }
                    txtPass.Enabled = true;
                    txtConPass.Enabled = true;
                    UpdateState = false;
                    //Status Bar values are updated.
                }

            //Accessing the Status bar in Winform Abstract (Parent)                         
            updateStatus(this,"Values Saved");

            //Clear all Controls After Save
            com.clearcontrol(GrbxNewUser, false);
            LoadCheckBox("");
            txtUsrname.Focus();
        }

        protected override void btncancel_Click(object sender, EventArgs e)
        {
            //check if on edit
            if (com.controlisinedit(GrbxNewUser,false))
            {
                DialogResult dr = MessageBox.Show("Do you want to Exit","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {                    
                    return;
                }
                //if yes
                com.clearcontrol(GrbxNewUser, true);
            }

            MenuMode(this, true);
            txtConPass.Enabled = true;
            txtPass.Enabled = true;
            pnlUsrNew.Visible = false;
        }

        protected override void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDGV()
        {
            //load the datagrid
            qry = "select USPUSERID, USPUSERNAME from userprivilege where USPDELETED='N'";
            dt = MysqlConn.getDataTable(qry);

            /* ACTIVATE IF A CHECK BOX IS REQUIRED
            if (DeleteState)
            {
                //adding combobox to datatable
                dt.Columns.Add(new DataColumn("Selected", typeof(bool)));
                dt.Columns["Selected"].SetOrdinal(1);
            }
            */

            this.dgvView.DataSource = dt.DefaultView;
            dgvView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //If delete state is active then 2 else 1
            //int x = DeleteState ? 2 : 1;
            dgvView.Columns[0].HeaderText = "ID";
            dgvView.Columns[1].HeaderText = "NAME";
        }

        private void LoadCheckBox(string rcvid)
        {
            int count = 0, menuno = 0;
            chklstbx.ColumnWidth = 350;

            //clear checkbox before putting values into it.
            chklstbx.Items.Clear();
            chklstbx.CheckOnClick = true;

            dt.Clear();

            if (!(rcvid == ""))
            {
                //if user already exists,set according to his settings
                qry = "SELECT UA_menu,UA_enable FROM user_attribute WHERE UA_user_id='" + rcvid + "'";
                dt = MysqlConn.getDataTable(qry);
            }

            //fetch the menu items and add it into checklistbox
            foreach (ToolStripMenuItem item in wfMain.Mainmenustrip.Items)
            {
                if (count < 2)
                {
                    count ++;

                    foreach (ToolStripMenuItem subitem in item.DropDownItems.OfType<ToolStripMenuItem>())
                    {
                        string chkname;
                        switch (item.Name)
                        {
                            case "Utilities":
                                chkname = item.Name + "........" + subitem.Name;
                                break;
                            case "Master":
                                chkname = item.Name + "..........." + subitem.Name;
                                break;
                            default:
                                chkname = item.Name + "....." + subitem.Name;
                                break;
                        }
                        if (dt.Rows.Count == 0)
                        {
                            if (rcvid == "")
                                // add the name only for new user
                                chklstbx.Items.Add(chkname, true);
                            //else
                            //    //check state on reset
                            //    chklstbx.SetItemChecked(menuno, true);
                        }
                        else
                        {
                            //check if menuno corresponds to name 
                            int a = (int)dt.Rows[menuno][1];
                            chklstbx.Items.Add(chkname, (CheckState)dt.Rows[menuno][1]);
                        }
                        menuno += 1;
                    }
                }
                else
                    return;
            }
        }

        private void chklstbx_leave(object sender, EventArgs e)
        {
            //Check atleast one check box is checked
            int count = chklstbx.Items.Count;
            foreach (CheckBox chkbx in chklstbx.Items.OfType<CheckBox>())
            {
                if (chkbx.Checked)
                    count++;
            }
            if (count == 0)
            {
                MessageBox.Show("Atleast one Privilege must be selected to enable the User Account." + Environment.NewLine + "Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtUsrname_TextChanged(object sender, EventArgs e)
        {
            //updating the status bar
            updateStatus(this, "Waiting for User's Input....");

            if (string.IsNullOrEmpty(txtUsrname.Text))
                 return;
            
            //Check if Username already exists
            qry = "select USPUSERNAME from userprivilege where USPUSERNAME = '" + txtUsrname + "'";
            if (MysqlConn.returnFirstCell(qry) != null)
            {
                MessageBox.Show("Username already Exists." + Environment.NewLine + "Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = string.Empty;
                txtUsrname.Focus();
                txtUsrname.Text = string.Empty;
                txtConPass.Text = string.Empty;
                //reflect values in user inherited status bar 
                return;
            }
        }

        private void txtlSrchUserName_TextChanged(object sender, EventArgs e)
        {
            // fill with the user based onthe name
            //load the datagrid
            qry = "select USPUSERID, USPUSERNAME from userprivilege where USPUSERNAME like '" + txtSrchUserName.Text + "%' and uspdeleted='N'";
            dt = MysqlConn.getDataTable(qry);
            dt.Columns[0].Caption = "USER ID";
            dt.Columns[1].Caption = "USER NAME";

            this.dgvView.DataSource = dt.DefaultView;
            dgvView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dr;
            if (DeleteState)
            {
                //get the row no.
                //convert the dgv cell to dgvcheckbox cell and 
                //check if selected / checked
               // DataGridViewCheckBoxCell chkbx = (DataGridViewCheckBoxCell)dgvView.Rows[e.RowIndex].Cells["Selected"];
                //if (chkbx.Selected)
                //{
                    dr = MessageBox.Show("Do you want to delete User " + Convert.ToString(dgvView.Rows[e.RowIndex].Cells["USPUSERNAME"].Value), "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                    //delete user
                    qry = "update userprivilege set USPdeleted = 'Y' where USPUSERID='" + Convert.ToString(dgvView.Rows[e.RowIndex].Cells["USPUSERID"].Value) + "'";
                    MysqlConn.executeQry(qry);
                    updateStatus(this, "User Deleted");
                    LoadDGV();
                //}
                return;
            }                      
            
            // on modify
             dr = MessageBox.Show("Do you want to Modify User " + Convert.ToString(dgvView.Rows[e.RowIndex].Cells["USPUSERNAME"].Value), "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
             if (dr == DialogResult.No)
             {
                 return;
             }

            //add username to text box
            txtUsrname.Text=Convert.ToString(dgvView[1, e.RowIndex].Value);

            qry = "select USPPASSWORD from userprivilege where USPUSERNAME='" + txtUsrname.Text + "'";
            txtConPass.Text = (string)MysqlConn.returnFirstCell(qry);
            txtConPass.Enabled = false;
            txtPass.Text = txtConPass.Text;
            txtPass.Enabled = false;
            
            //select the userid and loadCheckBox
            LoadCheckBox(Convert.ToString(dgvView[0, e.RowIndex].Value));             
            
            //menustate close
            MenuMode(this, false);

            //pnlview 
            pnlUsrView.Visible = false;

            //pnlnew.visible = true
            pnlUsrNew.Visible = true;

            UpdateState = true;
        }

        # endregion PrivateAndProtectedMethods
    }
}
