using System;
using System.Drawing;
using System.Windows.Forms;
using WCC;

namespace eid
{
    public partial class WinformWebcam : Form
    {
        WCC.clsWC objwcc = new clsWC();
        WinformEmpReg wfempreg = new WinformEmpReg();
        Bitmap fimage;

        public WinformWebcam(WinformEmpReg wfempreg)
        {
            InitializeComponent();
            this.wfempreg = wfempreg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap fimage = imgcap();
            wfempreg.pcbEmpImage.Image = fimage;
            wfempreg.btnCapture.Enabled = true;
            this.Close();
        }

        private Bitmap imgcap()
        {
            objwcc.preparecapture();
            Bitmap functionReturnValue = default(Bitmap);
            IDataObject data = default(IDataObject);
            data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
                functionReturnValue = (Bitmap)data.GetData(typeof(System.Drawing.Bitmap));
            return functionReturnValue;
        }

        private void WinformWebcam_Load(object sender, EventArgs e)
        {
            picCapture.Image = null;
            cmbCameraSelect.Items.Add(objwcc.LoadDeviceList().ToString());
            cmbCameraSelect.SelectedIndex = 0;
            objwcc.OpenPreviewWindow(picCapture.Height, picCapture.Width, long.Parse(picCapture.Handle.ToString()));
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (f % 2 == 0)
            //{
            fimage = imgcap();
            //}
            //f = f + 1;        
        }







    }
}
