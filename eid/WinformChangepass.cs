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
    public partial class WinformChangepass : Form
    {
        # region 'PublicConstructorsAndMethods
        string qry = "";
        Common com = new Common();
        DataTable dt = new DataTable();
       // MysqlConn objData = new MysqlConn();
      //  WinformChangepass cp = new WinformChangepass();

        public WinformChangepass()
        {
            InitializeComponent();
        }
        # endregion 'PublicConstructorsAndMethods

        # region 'PrivateMethods
        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                com.cleartext(this.Controls);
                this.Close();
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            qry = "select USPPASSWORD from userprivilege where USPUSERID='" + User.UserId + "'";

            if (MysqlConn.returnFirstCell(qry).ToString() == txtCurrent.Text)
            {
                qry = "update userprivilege set USPPASSWORD='" + txtConfirm.Text + "' where USPPASSWORD='" + txtCurrent.Text + "' and USPUSERID='" + User.UserId + "' ";
                MysqlConn.executeQry(qry);
                MessageBox.Show("Password has been successfully changed.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                com.cleartext(this.Controls);
                this.Close();
            }
            else
            {
                MessageBox.Show("The password you typed is incorrect." + Environment.NewLine + "Please retype your current password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrent.Text = "";
                txtCurrent.Focus();
                return;
            }
        }
        
        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm.Text != txtNew.Text)
            {
                MessageBox.Show("New passwords donot match." + Environment.NewLine + "Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNew.Text = "";
                txtConfirm.Text = "";
                txtNew.Focus();
            }
        }

        # endregion 'PrivateMethods
        //leave --> onerror --> msg box --> txt1&2="" -->focus
    }
}
