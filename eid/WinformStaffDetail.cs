using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace eid
{
    public partial class WinformEmpReg : WinformAbstract
    {
        #region 'PropertiesAndVariables
        string qry = "", EmpPicext = ".JPG", DOBext, NOChildext, PermAddext, PresAddext, EduQualext, OthrQualext;

        Common com = new Common();
        ErrorDump ed = new ErrorDump();
        DataTable dt = new DataTable();

        MySql.Data.MySqlClient.MySqlDataReader myReader = null;

        WinformAbstract wfAbs = new WinformAbstract();
        WinformMainmenu wfMain = new WinformMainmenu();

        #region pathini
        string EmpPicPath = Application.StartupPath + ConfigurationManager.AppSettings["EmpPicProof"];
        string DobPath = Application.StartupPath + ConfigurationManager.AppSettings["DOBProof"];
        string NoChildPath = Application.StartupPath + ConfigurationManager.AppSettings["NoChild"];
        string PermAddPath = Application.StartupPath + ConfigurationManager.AppSettings["PermAdd"];
        string PresAddPath = Application.StartupPath + ConfigurationManager.AppSettings["PresAdd"];
        string EduQualPath = Application.StartupPath + ConfigurationManager.AppSettings["EduQual"];
        string OthrQualPath = Application.StartupPath + ConfigurationManager.AppSettings["OthrQual"];
        #endregion pathini

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

        private bool mPrint;
        private bool PrintState
        {
            get
            {
                return mPrint;
            }
            set
            {
                mPrint = value;
            }
        }

        #endregion 'PropertiesAndVariables

        public WinformEmpReg()
        {
            InitializeComponent();
        }

        #region 'PrivateAndProtectedmethods
        private void WinformStaffDetail_Load(object sender, EventArgs e)
        {
            this.tabControl1.Visible = false;
            this.pnlUsrView.Visible = false;

            this.Location = new Point(this.Location.X + 300, this.Location.Y);

            pnlUsrView.Location = new Point(0, 75);
            this.Size = new Size(785, 683);
            dgvView.Width += 150;
            pnlUsrView.Width += 150;

            List<string> imageDir = new List<string> { EmpPicPath, DobPath, NoChildPath, PermAddPath, PresAddPath, EduQualPath, OthrQualPath };
            foreach (string imgPath in imageDir)
            {
                if (!Directory.Exists(imgPath))
                    Directory.CreateDirectory(imgPath);
            };
        }

        # region FunctionMethods
        protected override void btnnew_Click(object sender, EventArgs e)
        {
            MenuMode(this, false);
            this.tabControl1.Visible = true;
            this.pnlUsrView.Visible = false;
            txtEmpNo.Enabled = true;
            txtEmpNo.Focus();

            //updating the status bar
            updateStatus(this, "Waiting for User's Input....");
        }

        protected override void btnmodify_Click(object sender, EventArgs e)
        {
            //MenuMode(this, false);
            DeleteState = false;
            PrintState = false;
            txtSrchEmpName.Text = "";
            this.tabControl1.Visible = false;
            this.pnlUsrView.Visible = true;
            txtEmpNo.Enabled = false;

            lblMessage.Text = "Double Click the Employee Name to Modify the Employee Details.";

            LoadDGV();
        }

        protected override void btndelete_Click(object sender, EventArgs e)
        {
            DeleteState = true;
            txtSrchEmpName.Text = "";
            this.tabControl1.Visible = false;
            this.pnlUsrView.Visible = true;

            lblMessage.Text = "Double Click the Username to delete the User.";

            //make text red

            //load the datagrid with checkboxes
            LoadDGV();
        }

        protected override void btnsave_Click(object sender, EventArgs e)
        {
            string[] Dest_Image_ImagePath = { };

            if (rdbSingle.Checked == false && rdbMarried.Checked == false)
            {
                MessageBox.Show("Please enter your Marital Status", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string val = txtEmpNo.Text;
            List<string> exception_Control_List = new List<string> { "txtNoOfChildProof", "txtOthrQualProof" };
            if (rdbSingle.Checked == true)
            {
                //list of controls not to be considered on check                
                exception_Control_List.Add("txtWifeName");
                exception_Control_List.Add("txtNoOfChild");
            }

            //check if textbox is empty or not
            if (com.isempty(tabControl1, true, exception_Control_List) == true)
                return;

            List<string> StrocProcKey = new List<string> { "pER_EMP_NO", "pER_EMP_NAME", "pER_FATHER_NAME", "pER_EMP_DOB", "pER_EMP_READ", "pER_EMP_WRITE", "pER_EMP_SPEAK", "pER_EMP_PER_ADDRESS", "pER_EMP_PRES_ADDRESS", "pER_EMP_PHONE_NO", "pER_EMP_MOBILE_NO", "pER_EMP_EDU_QUAL", "pER_EMP_OTHR_QUAL", "pER_EMP_EXPERIENCE_SEC_SER", "pER_REF1_NAME", "pER_REF1_HOUSE_NO", "pER_REF1_STREET_NO", "pER_REF1_POST_OFFICE", "pER_REF1_DISTRICT", "pER_REF1_STATE", "pER_REF1_TELEPHONE", "pER_REF1_PINCODE", "pER_REF1_OCCUPATION", "pER_REF2_NAME", "pER_REF2_HOUSE_NO", "pER_REF2_STREET_NO", "pER_REF2_POST_OFFICE", "pER_REF2_DISTRICT", "pER_REF2_STATE", "pER_REF2_TELEPHONE", "pER_REF2_PINCODE", "pER_REF2_OCCUPATION", "pER_EMP_ABOUT", "pER_EMP_MARITAL_STATUS", "pER_EMP_DOM", "pER_WIFE_NAME", "pER_EMP_NOCHILD" };

            List<object> StroProcVal = new List<object> { txtEmpNo.Text, txtName.Text, txtFthrName.Text, dtpDob.Value.ToString("yyyy-MM-dd"), txtRead.Text, txtWrite.Text, txtSpeak.Text, txtPermAdd.Text, txtPresAdd.Text, txtPhoneNo.Text, txtMobNo.Text, txtEduQual.Text, txtOthrQual.Text, txtExpInSec.Text, txtNameRef1.Text, txtHouseNoRef1.Text, txtStreetNoRef1.Text, txtPostOffRef1.Text, txtDistRef1.Text, txtStateRef1.Text, txtTeleRef1.Text, txtPincodeRef1.Text, txtOccRef1.Text, txtNameRef2.Text, txtHouseNoRef2.Text, txtStreetNoRef2.Text, txtPostOffRef2.Text, txtDistRef2.Text, txtStateRef2.Text, txtTeleRef2.Text, txtPincodeRef2.Text, txtOccRef2.Text, txtAbout.Text, rdbMarried.Checked ? "Married" : "Single", rdbSingle.Checked ? null : dtpDom.Value.ToString("yyyy-MM-dd"), string.IsNullOrEmpty(txtWifeName.Text) ? null : txtWifeName.Text, string.IsNullOrEmpty(txtNoOfChild.Text) ? null : txtNoOfChild.Text, (User.UserId).ToString(), DateTime.Now.Date.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss") };

            if (UpdateState != true)
            {
                StrocProcKey.Add("pER_CREATED_BY");
                StrocProcKey.Add("pER_CREATED_ON");

                Dictionary<String, Object> dict = new Dictionary<String, Object>();
                for (int i = 0; i < StroProcVal.Count; i++)
                {
                    dict.Add(StrocProcKey[i], StroProcVal[i]);
                }

                if (MysqlConn.dictionaryToTable(dict, "insert_Emp_Details") >= 1)
                {
                    updateStatus(this, "Values Saved");

                    if (rdbSingle.Checked == true)
                        com.clearcontrol(grbMarital, true);

                    Dest_Image_ImagePath = transfer_Images(val);

                    qry = "insert into employee_proof(EP_EMP_NO, EP_EMP_PIC, EP_EMP_DOB_PROOF, EP_EMP_PER_ADDRESS_PROOF, EP_EMP_PRES_ADDRESS_PROOF, EP_EMP_EDU_QUAL_PROOF,EP_EMP_NOCHILD_PROOF,EP_EMP_OTHR_QUAL_PROOF) values ('" + txtEmpNo.Text + "',";

                    for (int i = 0; i < Dest_Image_ImagePath.Length - 2; i++)
                        qry += "'" + Dest_Image_ImagePath[i].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "',";

                    qry += ((rdbMarried.Checked == true) && (!string.IsNullOrEmpty(txtNoOfChildProof.Text))) ? "'" + Dest_Image_ImagePath[6].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "'," : "NULL,";

                    qry += (string.IsNullOrEmpty(txtOthrQualProof.Text) == false) ? "'" + Dest_Image_ImagePath[5].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "')" : "NULL)";
                    MysqlConn.executeQry(qry);
                }
            }
            else
            {
                StrocProcKey.Add("pER_MODIFIED_BY");
                StrocProcKey.Add("pER_MODIFIED_ON");

                Dictionary<String, Object> dict = new Dictionary<String, Object>();
                for (int i = 0; i < StroProcVal.Count; i++)
                {
                    dict.Add(StrocProcKey[i], StroProcVal[i]);
                }

                if (MysqlConn.dictionaryToTable(dict, "update_Emp_Details") >= 1)
                {
                    // make grpMarital empty
                    if (rdbSingle.Checked == true)
                        com.clearcontrol(grbMarital, true);


                    Dest_Image_ImagePath = transfer_Images(val);
                    if (Path.GetExtension(Dest_Image_ImagePath[0]) == "")
                        Dest_Image_ImagePath[0] = Dest_Image_ImagePath[0] + ".jpg";

                    string[] updsource = { "EP_EMP_PIC", "EP_EMP_DOB_PROOF", "EP_EMP_PER_ADDRESS_PROOF", "EP_EMP_PRES_ADDRESS_PROOF", "EP_EMP_EDU_QUAL_PROOF" };

                    qry = "update employee_proof set ";
                    for (int i = 0; i < Dest_Image_ImagePath.Length - 2; i++)
                        qry += "" + updsource[i] + "='" + Dest_Image_ImagePath[i].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "',";

                    if ((rdbMarried.Checked) && (!string.IsNullOrEmpty(txtNoOfChildProof.Text)))
                        qry += "EP_EMP_NOCHILD_PROOF='" + Dest_Image_ImagePath[6].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "',";
                    else
                        qry += "EP_EMP_NOCHILD_PROOF=NULL,";

                    qry += (string.IsNullOrEmpty(txtOthrQualProof.Text) == false) ? "EP_EMP_OTHR_QUAL_PROOF='" + Dest_Image_ImagePath[5].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "'" : "EP_EMP_OTHR_QUAL_PROOF=NULL";
                    qry += " where EP_EMP_NO='" + txtEmpNo.Text + "'";
                    MysqlConn.executeQry(qry);
                }
                txtEmpNo.Enabled = true;
                UpdateState = false;
            }
            //clear the form
            com.clearcontrol(tabControl1, true);
            txtEmpNo.Focus();
        }

        protected override void btncancel_Click(object sender, EventArgs e)
        {
            //check if on edit
            if (com.controlisinedit(tabControl1, true))
            {
                if (DialogResult.No == MessageBox.Show("Do you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;

                //if yes
                com.clearcontrol(tabControl1, true);
            }

            MenuMode(this, true);
            tabControl1.Visible = false;
        }

        protected override void btnPrint_Click(object sender, EventArgs e)
        {
            DeleteState = false;
            PrintState = true;
            txtSrchEmpName.Text = "";
            this.tabControl1.Visible = false;
            this.pnlUsrView.Visible = true;

            lblMessage.Text = "Double Click the Username to Print the User Data.";

            //load the datagrid 
            LoadDGV();
        }

        protected override void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            WinformWebcam wfWebcam = new WinformWebcam(this);
            wfWebcam.ShowDialog();
        }
        # endregion FunctionMethods

        #region ValidationMethods
        private void grbMarital_Enter(object sender, EventArgs e)
        {
            grbMarital.Enabled = (rdbMarried.Checked) ? true : false;
        }

        private void txtName_TextChanged(object sender, KeyPressEventArgs e)
        {
            //updating the status bar
            updateStatus(this, "Entering the Employee Details....");

            com.isalpha_space(e);
        }

        private void txtNoOfChild_TextChanged(object sender, KeyPressEventArgs e)
        {
            //updating the status bar
            updateStatus(this, "Entering the Employee Details....");

            com.isnumeric(e);
        }

        private void btnAttachProof(object sender, EventArgs e)
        {
            string btnName;
            var button = (Button)sender;
            btnName = button.Name;
            OpenFileDialog OfdDob = new OpenFileDialog();
            OfdDob.Title = "Open Document";
            OfdDob.Filter = "jpg files(*.jpg)|*.jpg|Gif files(*.gif)|*.gif|JPEG files(*.jpeg)|*.jpeg|Bitmap files(*.bmp)|*.bmp";
            OfdDob.InitialDirectory = @"C:\";

            if (OfdDob.ShowDialog() == DialogResult.OK)
                switch (btnName)
                {
                    case "btnUpload":
                        pcbEmpImage.ImageLocation = OfdDob.FileName;
                        EmpPicext = Path.GetExtension(OfdDob.FileName);
                        break;
                    case "btnDobProof":
                        txtDobProof.Text = OfdDob.FileName;
                        DOBext = Path.GetExtension(OfdDob.FileName);
                        break;
                    case "btnNoOfChildProof":
                        txtNoOfChildProof.Text = OfdDob.FileName;
                        NOChildext = Path.GetExtension(OfdDob.FileName);
                        break;
                    case "btnPerAddressProof":
                        txtPerAddressProof.Text = OfdDob.FileName;
                        PermAddext = Path.GetExtension(OfdDob.FileName);
                        break;
                    case "btnPresAddressProof":
                        txtPresAddressProof.Text = OfdDob.FileName;
                        PresAddext = Path.GetExtension(OfdDob.FileName);
                        break;
                    case "btnEduProof":
                        txtEduProof.Text = OfdDob.FileName;
                        EduQualext = Path.GetExtension(OfdDob.FileName);
                        break;
                    case "btnOthrQualProof":
                        txtOthrQualProof.Text = OfdDob.FileName;
                        OthrQualext = Path.GetExtension(OfdDob.FileName);
                        break;
                }
        }

        private void checkEmpNo(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpNo.Text))
            {
                return;
            }

            if (UpdateState != true)
            {
                qry = "select count(*) from employee_registry where ER_EMP_NO='" + txtEmpNo.Text + "'";
                if (Convert.ToInt16(MysqlConn.returnFirstCell(qry)) != 0)
                {
                    MessageBox.Show("Employee Number already exists." + Environment.NewLine + "Please enter a different number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmpNo.Text = "";
                    txtEmpNo.Focus();
                }
            }
        }
        #endregion ValidationMethods

        #region ViewModule_Methods
        private void LoadDGV()
        {
            //load the datagrid
            qry = "select ER_EMP_NO, ER_EMP_NAME from employee_registry where ER_DELETED='N'";
            dt = MysqlConn.getDataTable(qry);

            dt.Columns.Add("EMPLOYEE_ID");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dt.Rows[i]["EMPLOYEE_ID"] = i + 1;
            }
            dt.Columns["EMPLOYEE_ID"].SetOrdinal(0);

            this.dgvView.DataSource = dt.DefaultView;
            dgvView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //If delete state is active then 2 else 1
            //int x = DeleteState ? 2 : 1;
            // dgvView.Columns[0].HeaderText = "EMPLOYEE_ID";
            dgvView.Columns[1].HeaderText = "EMPLOYEE_NO";
            dgvView.Columns[2].HeaderText = "EMPLOYEE_NAME";
        }

        private void txtlSrchEmpName_TextChanged(object sender, EventArgs e)
        {
            //load the datagrid
            qry = "select  ER_EMP_NO as EMPLOYEE_NO,ER_EMP_NAME as EMPLOYEE_NAME from employee_registry where ER_DELETED='N' ";

            //the following loops work for both txtempname and txtempno 
            //to search among the datagridview
            if (!string.IsNullOrEmpty(txtSrchEmpName.Text))
                qry += "and ER_EMP_NAME like '" + txtSrchEmpName.Text + "%'";
            if (!string.IsNullOrEmpty(txtSrchEmpNo.Text))
                qry += "and ER_EMP_NO like '" + txtSrchEmpNo.Text + "%'";

            dt = MysqlConn.getDataTable(qry);

            dt.Columns.Add("EMPLOYEE_ID");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dt.Rows[i]["EMPLOYEE_ID"] = i + 1;
            }
            dt.Columns["EMPLOYEE_ID"].SetOrdinal(0);

            dt.Columns[0].Caption = "EMPLOYEE ID";
            dt.Columns[1].Caption = "EMPLOYEE NO.";
            dt.Columns[2].Caption = "EMPLOYEE NAME";

            this.dgvView.DataSource = dt.DefaultView;
            dgvView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dr;

            # region DeleteUser
            if (DeleteState)
            {
                //get the row no.
                //convert the dgv cell to dgvcheckbox cell and 
                //check if selected / checked
                // DataGridViewCheckBoxCell chkbx = (DataGridViewCheckBoxCell)dgvView.Rows[e.RowIndex].Cells["Selected"];
                //if (chkbx.Selected)
                //{
                dr = MessageBox.Show("Do you want to delete the details of Employee " + Convert.ToString(dgvView.Rows[e.RowIndex].Cells["ER_EMP_NAME"].Value), "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                //delete user
                qry = "update employee_registry set ER_DELETED = 'Y' where ER_EMP_NO='" + Convert.ToString(dgvView.Rows[e.RowIndex].Cells["ER_EMP_NO"].Value) + "'";
                MysqlConn.executeQry(qry);

                qry = "update employee_proof set EP_DELETED = 'Y' where EP_EMP_NO='" + Convert.ToString(dgvView.Rows[e.RowIndex].Cells["ER_EMP_NO"].Value) + "'";
                MysqlConn.executeQry(qry);

                updateStatus(this, "User Deleted");
                LoadDGV();
                return;
            }
            # endregion delete

            # region PrintUser
            if (PrintState && e.RowIndex != -1)
            {
                WinformPdfViewer wfPdfView = new WinformPdfViewer(Convert.ToString(dgvView.Rows[e.RowIndex].Cells["ER_EMP_NO"].Value));
                wfPdfView.ShowDialog();
                this.Cursor = Cursors.Default;
                return;
            }
            # endregion PrintUser

            # region Modify/User
            // on modify
            dr = MessageBox.Show("Do you want to Modify the details of Employee " + Convert.ToString(dgvView.Rows[e.RowIndex].Cells[2].Value), "Modify Employee Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            //add employee number and name to text box
            txtEmpNo.Text = Convert.ToString(dgvView[1, e.RowIndex].Value);
            txtName.Text = Convert.ToString(dgvView[2, e.RowIndex].Value);

            qry = "select * from employee_registry as er,employee_proof as ep where ER_EMP_NO='" + txtEmpNo.Text + "' AND er.ER_EMP_NO=ep.EP_EMP_NO";
            myReader = MysqlConn.GetSQLDataReader(qry);

            while (myReader.Read())
            {
                txtFthrName.Text = (myReader["ER_FATHER_NAME"].ToString());
                dtpDob.Value = ((DateTime)myReader["ER_EMP_DOB"]);

                txtRead.Text = (myReader["ER_EMP_READ"].ToString());
                txtWrite.Text = (myReader["ER_EMP_WRITE"].ToString());
                txtSpeak.Text = (myReader["ER_EMP_SPEAK"].ToString());

                txtPermAdd.Text = (myReader["ER_EMP_PER_ADDRESS"].ToString());
                txtPhoneNo.Text = (myReader["ER_EMP_PHONE_NO"].ToString());
                txtPresAdd.Text = (myReader["ER_EMP_PRES_ADDRESS"].ToString());
                txtMobNo.Text = (myReader["ER_EMP_MOBILE_NO"].ToString());

                txtEduQual.Text = (myReader["ER_EMP_EDU_QUAL"].ToString());
                txtOthrQual.Text = (myReader["ER_EMP_OTHR_QUAL"].ToString());
                txtExpInSec.Text = (myReader["ER_EMP_EXPERIENCE_SEC_SER"].ToString());
                txtAbout.Text = (myReader["ER_EMP_ABOUT"].ToString());

                txtNameRef1.Text = (myReader["ER_REF1_NAME"].ToString());
                txtHouseNoRef1.Text = (myReader["ER_REF1_HOUSE_NO"].ToString());
                txtStreetNoRef1.Text = (myReader["ER_REF1_STREET_NO"].ToString());
                txtPostOffRef1.Text = (myReader["ER_REF1_POST_OFFICE"].ToString());
                txtDistRef1.Text = (myReader["ER_REF1_DISTRICT"].ToString());
                txtStateRef1.Text = (myReader["ER_REF1_STATE"].ToString());
                txtTeleRef1.Text = (myReader["ER_REF1_TELEPHONE"].ToString());
                txtPincodeRef1.Text = (myReader["ER_REF1_PINCODE"].ToString());
                txtOccRef1.Text = (myReader["ER_REF1_OCCUPATION"].ToString());

                txtNameRef2.Text = (myReader["ER_REF2_NAME"].ToString());
                txtHouseNoRef2.Text = (myReader["ER_REF2_HOUSE_NO"].ToString());
                txtStreetNoRef2.Text = (myReader["ER_REF2_STREET_NO"].ToString());
                txtPostOffRef2.Text = (myReader["ER_REF2_POST_OFFICE"].ToString());
                txtDistRef2.Text = (myReader["ER_REF2_DISTRICT"].ToString());
                txtStateRef2.Text = (myReader["ER_REF2_STATE"].ToString());
                txtTeleRef2.Text = (myReader["ER_REF2_TELEPHONE"].ToString());
                txtPincodeRef2.Text = (myReader["ER_REF2_PINCODE"].ToString());
                txtOccRef2.Text = (myReader["ER_REF2_OCCUPATION"].ToString());

                if (myReader["ER_EMP_MARITAL_STATUS"].ToString() == "Single")
                {
                    rdbSingle.Checked = true;
                    grbMarital.Enabled = false;
                }
                else
                {
                    rdbMarried.Checked = true;
                    txtWifeName.Text = (myReader["ER_WIFE_NAME"].ToString());
                    txtNoOfChild.Text = (myReader["ER_EMP_NOCHILD"].ToString());
                    if (File.Exists(myReader["EP_EMP_NOCHILD_PROOF"].ToString()))
                        txtNoOfChildProof.Text = (myReader["EP_EMP_NOCHILD_PROOF"].ToString());
                }

                pcbEmpImage.ImageLocation = (myReader["EP_EMP_PIC"].ToString());
                txtDobProof.Text = (myReader["EP_EMP_DOB_PROOF"].ToString());
                txtPerAddressProof.Text = (myReader["EP_EMP_PER_ADDRESS_PROOF"].ToString());
                txtPresAddressProof.Text = (myReader["EP_EMP_PRES_ADDRESS_PROOF"].ToString());
                txtEduProof.Text = (myReader["EP_EMP_EDU_QUAL_PROOF"].ToString());
                if (File.Exists(myReader["EP_EMP_OTHR_QUAL_PROOF"].ToString()))
                    txtOthrQualProof.Text = (myReader["EP_EMP_OTHR_QUAL_PROOF"].ToString());

                EmpPicext = Path.GetExtension(pcbEmpImage.ImageLocation);
                DOBext = Path.GetExtension(txtDobProof.Text);
                PermAddext = Path.GetExtension(txtPerAddressProof.Text);
                PresAddext = Path.GetExtension(txtPresAddressProof.Text);
                EduQualext = Path.GetExtension(txtEduProof.Text);

                if (!string.IsNullOrEmpty(txtNoOfChildProof.Text))
                {
                    NOChildext = Path.GetExtension(txtNoOfChildProof.Text);
                }

                if (!string.IsNullOrEmpty(txtOthrQualProof.Text))
                {
                    OthrQualext = Path.GetExtension(txtOthrQualProof.Text);
                }
            }

            //menustate close
            MenuMode(this, false);

            //pnlview 
            pnlUsrView.Visible = false;

            //pnlnew.visible = true
            tabControl1.Visible = true;

            UpdateState = true;
            this.Cursor = Cursors.Default;
            # endregion ModifyUser
        }

        private void btnClear(object sender, EventArgs e)
        {
            string btnName;
            var button = (Button)sender;
            btnName = button.Name;

            switch (btnName)
            {
                case "btnDOBClear":
                    txtDobProof.Text = "";
                    break;
                case "btnNOChildClear":
                    txtNoOfChildProof.Text = "";
                    break;
                case "btnPermAddClear":
                    txtPerAddressProof.Text = "";
                    break;
                case "btnPresAddClear":
                    txtPresAddressProof.Text = "";
                    break;
                case "btnEduQualClear":
                    txtEduProof.Text = "";
                    break;
                case "btnOthrQualClear":
                    txtOthrQualProof.Text = "";
                    break;
            }
        }

        /// <summary>
        /// val has the Employee Id
        /// /*save all image file to respective folders 
        /// if file doesnot exist 
        /// add new file    
        /// else
        /// delete previous and add add new 
        /// else if pres is empty and prev file exist
        /// delete prev*/
        /// </summary>
        /// <param name="val"></param>
        /// <returns>list of transferred files path</returns>
        private string[] transfer_Images(string val)
        {
            //when image is captured and not uploaded.
            if (pcbEmpImage.ImageLocation == null || pcbEmpImage.Image != null || File.Exists(pcbEmpImage.ImageLocation))
            {
                pcbEmpImage.Image.Save(EmpPicPath + "\\_EmpPicPath_" + val + "" + ".jpg");
                pcbEmpImage.ImageLocation = EmpPicPath + "\\_EmpPicPath_" + val + "" + ".jpg";
            }

            string[] Source_Image_ImagePath = 
            {
                pcbEmpImage.ImageLocation, txtDobProof.Text, 
                txtPerAddressProof.Text  , txtPresAddressProof.Text,
                txtEduProof.Text         , txtOthrQualProof.Text, txtNoOfChildProof.Text
            };

            string[] Dest_Image_ImagePath = 
            {  
                EmpPicPath   + "\\EmpPicPath_"   + val + "" + EmpPicext,
                DobPath      + "\\DobPath_"      + val + "" + DOBext,
                PermAddPath  + "\\PermAddpath_"  + val + "" + PermAddext,
                PresAddPath  + "\\PresAddPath_"  + val + "" + PresAddext,
                EduQualPath  + "\\EduQualPath_"  + val + "" + EduQualext,
                OthrQualPath + "\\OthrQualPath_" + val + "" + OthrQualext,
                NoChildPath  + "\\NoChildPath_"  + val + "" + NOChildext
            };

            for (int i = 0; i <= Dest_Image_ImagePath.Length - 2; i++)
            {
                if (!string.IsNullOrEmpty(Source_Image_ImagePath[i]))
                {
                    if (!File.Exists(Dest_Image_ImagePath[i]))
                        //add new file
                        File.Copy(Source_Image_ImagePath[i], Dest_Image_ImagePath[i]);

                    else if (string.Equals(Source_Image_ImagePath[i], Dest_Image_ImagePath[i]) == false && (File.Exists(Dest_Image_ImagePath[i])))
                    {
                        //update the file
                        File.Delete(Dest_Image_ImagePath[i]);
                        File.Copy(Source_Image_ImagePath[i], Dest_Image_ImagePath[i]);
                    }
                }

                else if (string.IsNullOrEmpty(Source_Image_ImagePath[i]) && File.Exists(Dest_Image_ImagePath[i]))
                    File.Delete(Dest_Image_ImagePath[i]);
            }

            if (rdbMarried.Checked == true && string.IsNullOrEmpty(txtNoOfChildProof.Text) != true)
            {
                if (!File.Exists(Dest_Image_ImagePath[6]))
                    //add new file
                    File.Copy(Source_Image_ImagePath[6], Dest_Image_ImagePath[6]);

                else if (File.Equals(Source_Image_ImagePath[6], Dest_Image_ImagePath[6]) == false && File.Exists(Dest_Image_ImagePath[6]))
                {
                    //update the file
                    File.Delete(Dest_Image_ImagePath[6]);
                    File.Copy(txtNoOfChildProof.Text, Dest_Image_ImagePath[6]);
                }
            }
            else if (string.IsNullOrEmpty(Source_Image_ImagePath[6]) && File.Exists(Dest_Image_ImagePath[6]))
                File.Delete(Dest_Image_ImagePath[6]);

            return Dest_Image_ImagePath;
        }

        #endregion ViewModule_Methods

        #endregion 'PrivateAndProtectedMethods
    }
}
