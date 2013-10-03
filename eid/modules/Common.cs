using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace eid   
{
    class Common
    {
        #region 'PublicMethods
        public void clearcontrol(Control container, Boolean Recurse)
        {
            foreach (Control ctrol in container.Controls)
            {
                switch (ctrol.Name.Substring(0, 3).ToLower())
                {
                    case "txt":
                        TextBox txt = (TextBox)ctrol;
                        txt.Text = "";
                        break;

                    case "chk":
                        CheckBox chkbx = (CheckBox)ctrol;
                        chkbx.Checked = false;
                        break;

                    case "dtp":
                        DateTimePicker dtp = (DateTimePicker)ctrol;
                        dtp.Value = DateTime.Now;
                        break;

                    case "rdb":
                        RadioButton rdb = (RadioButton)ctrol;
                        rdb.Checked = false;
                        break;

                    case "pcb":
                        PictureBox pcb = (PictureBox)ctrol;
                        pcb.ImageLocation = null;
                        pcb.Image = null;
                        break;
                }

                if (Recurse)
                {
                    switch (ctrol.Name.Substring(0, 3).ToLower())
                    {
                        case "tab":
                            TabPage tp = (TabPage)ctrol;
                            clearcontrol(tp, Recurse);
                            break;

                        case "pnl":
                            Panel pnl = (Panel)ctrol;
                            clearcontrol(pnl, Recurse);
                            break;

                        case "grb":
                            GroupBox grbx = (GroupBox)ctrol;
                            clearcontrol(grbx, Recurse);
                            break;
                    }
                }
            }
        }

        public bool controlisinedit(Control controls, bool Recurse)
        {
            foreach (Control ctrol in controls.Controls)
            {
                switch (ctrol.Name.Substring(0,3).ToLower())
                {
                    case "txt":
                        if (ctrol.Text != "")
                            return true;
                        break;
                }
               
                if (Recurse)
                {
                    switch (ctrol.Name.Substring(0, 3).ToLower())
                    {
                        case "tab":
                            TabPage tp = (TabPage)ctrol;
                            if(controlisinedit(tp, Recurse)==true)
                                return true;
                            break;

                        case "pnl":
                            Panel pnl = (Panel)ctrol;
                            if(controlisinedit(pnl, Recurse)==true)
                                return true;
                            break;
                        case "grp":
                            GroupBox grbx = (GroupBox)ctrol;
                            if(controlisinedit(grbx, Recurse)==true)
                                return true;
                            break;
                    }
                }
            }      
            //else
            return false;    
        }

        public string qrytime(String qry, string  str = "")
        {
            if (qry == "ins")
                return "'" + User.UserId + "','" + DateTime.Now.Date.ToString("yyyy/MM/dd") + " " + DateTime.Now.ToString("HH:mm:ss") + "'";

            else if (qry == "upd")
                return str + "MODIFIED_BY='" + User.UserId + "'," + str + "MODIFIED_ON='" + DateTime.Now.Date.ToString("yyyy/MM/dd") + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
            else
                return null;
         }

        /// <summary>
        /// checks if the container sent has any controls with no value
        /// </summary>
        /// <param name="container"></param>
        /// <param name="Recurse">true -> if control has parent container else false </param>
        /// <param name="ExceptionControl">it consists the name of control that has to be treated as an exception by default it has</param>
        /// <returns></returns>
        public bool isempty(Control container, Boolean Recurse,List<string> ExceptionControl=null)
        {          
            foreach (Control ctrol in container.Controls)
            {
                if((ctrol is TextBox || ctrol is RichTextBox) &&(!ExceptionControl.Contains(ctrol.Name)))
                {
                    //if (c.Text == "")
                    if(string.IsNullOrEmpty(ctrol.Text))
                    {
                        MessageBox.Show("Textbox " + ctrol.Name + " is empty." + Environment.NewLine + "Please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ctrol.Focus();
                        return true;
                    }   
                }
                if (ctrol is PictureBox)
                {
                    if (((PictureBox)ctrol).Image==null)
                    {
                        MessageBox.Show("Employee Image is Mandatory and cannot be empty." + Environment.NewLine + "Please insert and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        return true;
                    }
                }
                if (Recurse)
                {
                    switch (ctrol.Name.Substring(0, 3).ToLower())
                    {
                        case "tab":
                            TabPage tp = (TabPage)ctrol;
                            if(isempty(tp, Recurse, ExceptionControl)==true)
                                return true;
                            break;

                        case "pnl":
                            Panel pnl = (Panel)ctrol;
                            if(isempty(pnl, Recurse, ExceptionControl)==true)
                                return true;
                            break;

                        case "grb":
                            GroupBox grbx = (GroupBox)ctrol;
                            if(isempty(grbx, Recurse, ExceptionControl)==true)
                                return true;
                            break;
                    }
                }

                //if (Recurse)
                //{
                //    if (ctrol is TabControl)
                //    {
                //        TabControl tc = (TabControl)ctrol;
                //        if(isempty(tc, Recurse, ExceptionControl)==true)
                //            return true;
                //    }

                //    if (ctrol is Panel)
                //    {
                //        Panel pnl = (Panel)ctrol;
                //        if(isempty(pnl, Recurse, ExceptionControl)==true)
                //            return true;
                //    }

                //    if (ctrol is GroupBox)
                //    {
                //        if (ctrol.Enabled == true)
                //        {
                //            GroupBox grbx = (GroupBox)ctrol;
                //            if(isempty(grbx, Recurse, ExceptionControl)==true)
                //                return true;
                //        }
                //    }
                //}
            }
            return false;
        }

        public void isnumber(System.Windows.Forms.KeyPressEventArgs e)
        {
            //string allowedChars = "0123456789." & ControlChars.Back;
            string allowedChars = "0123456789." + (char)Keys.Back;
            if (allowedChars.IndexOf(e.KeyChar) == -1)
                //invalid character
                e.Handled = true;
        }

        public object RadioCheck(RadioButton Rdb1, RadioButton Rdb2)
        {
            string val;   //check
            if (Rdb1.Checked == true)
                val = Rdb1.Text;
            else
                val = Rdb2.Text;
            return val;
        }

        public bool isalpha(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) != true && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            else
                e.Handled = false;
            return e.Handled;
        }

        public bool isalpha_space(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) != true && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                e.Handled = true;
            else
                e.Handled = false;
            return e.Handled;
        }

        public bool isnumeric(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) == false && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            else
                e.Handled = false;
            return e.Handled;
        }

        public void cleartext(Control.ControlCollection controls)
        {
            int i = 0;
            foreach (Control c in controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    //If CType(c, TextBox).TabIndex = 0 Then CType(c, TextBox).Focus() : i = i + 1
                    if (c.TabIndex == 0)
                    {
                        c.Focus();
                        i = i + 1;
                    }
                    c.Text = "";
                }
            }
        }

        #endregion 'PublicMethods
    }       

}
