using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ModifySchedule : Form
    {
        public ModifySchedule()
        {
            InitializeComponent();
        }

        public string NameTxt
        {
            get { return nameTxt.Text; }
            set { nameTxt.Text = value.ToString(); }
        }
        public string ExTxt
        {
            get { return exTxt.Text; }
            set { exTxt.Text = value.ToString(); }
        }
        public DateTime StrDate
        {
            get { return strDate.Value; }
            set { strDate.Value = value; }
        }
        public DateTime EndDate
        {
            get { return endDate.Value; }
            set { endDate.Value = value; }
        }
        public Image ImagePic
        {
            get { return imagePic.Image; }
            set {
                Image img = value;
                if (img != null)
                {
                    float percent = (float)img.Height / 130;
                    int imgWidth = (int)((float)img.Width / percent);
                    imagePic.Size = new Size(imgWidth, 130);
                    imagePic.SizeMode = PictureBoxSizeMode.Zoom;
                }
                imagePic.Image = img;
            }
        }
        public int StateCheck
        {
            get { return StateCheck; }
            set
            {
                int check = value;
                if(check == 0)
                {
                    stateCheck.Checked = true;
                }
                else
                {
                    stateCheck.Checked = false;
                }
            }
        }


        private void ModifySchedule_Load(object sender, EventArgs e)
        {
            //stateCheck.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
