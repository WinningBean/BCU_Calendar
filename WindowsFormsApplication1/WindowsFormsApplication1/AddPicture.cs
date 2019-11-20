using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class AddPicture : Form
    {
        public AddPicture()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            convert();
        }

        public void convert()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "사진추가";
            ofd.Filter = "JPG 파일 (*.jpg)|*.jpg|PNG 파일 (*.png)|*.png";

            DialogResult dr = ofd.ShowDialog();

            if(dr == DialogResult.OK)
            {
                // 파일명 설정 추가해야함
                string file = @ofd.FileName;
                FileInfo info = new FileInfo(file);

                if(info.Length < 1000000) // 1당 byte
                {
                    MessageBox.Show("사진 용량이 너무 큽니다 \n" + info.Length.ToString() + " byte > " + "1000000 byte");
                }
            }
            
        }
    }
}
