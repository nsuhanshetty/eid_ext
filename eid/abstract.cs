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
    public partial class WinformAbstract : Form
    {
        # region 'PublicConstructorAndVariables
        public WinformAbstract()
        {
            InitializeComponent();
        }       

        public enum State 
        {        
            Menu=0, Search =1 , Save=2
        }       

        private bool _MenuState;
        public bool MenuState
        {
            get
            {
                return _MenuState;
            }
            set
            {
                _MenuState = value;
            }
        }
        
        # endregion 'PublicConstructorAndVariables

        #region 'Public Methods
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnnew_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnmodify_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btndelete_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnsave_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btncancel_Click(object sender, EventArgs e)
        {

        }

        public void updateStatus(WinformAbstract frm, string Status)
        {
            frm.StatusStripLabel.Text = Status;
        }

        protected void MenuMode(WinformAbstract frm , bool value)
        {
            ///
            /// The btn's in the tool strip and the Menustrip is enabled / disabled based on the value.
            /// Bool : True/ False based on the state required by the form
            /// frm : the child form
            ///

            frm.btnnew.Enabled = value;
            frm.btnmodify.Enabled = value;
            frm.btndelete.Enabled = value;

            frm.btnsave.Enabled = (!value);
            frm.btncancel.Enabled = (!value);

            frm.NewToolStripMenuItem.Enabled = value;
            frm.ModifyToolStripMenuItem.Enabled = value;
            frm.DeleteToolStripMenuItem.Enabled = value;
            MenuState= value;
        }

        #endregion 'Public Methods

        protected virtual void btnexit_Click(object sender, EventArgs e)
        {

        }
    }
}
