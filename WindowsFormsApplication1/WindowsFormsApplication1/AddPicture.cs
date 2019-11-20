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
            PictureSave();
        }

        public void PictureSave()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "사진추가";
            ofd.Filter = "JPG 파일 (*.jpg)|*.jpg|PNG 파일 (*.png)|*.png";

            DialogResult dr = ofd.ShowDialog();

            if(dr == DialogResult.OK)
            {
                try
                {
                    // 파일명 설정 추가해야함
                    string file = @ofd.FileName;
                    FileInfo info = new FileInfo(file);

                    if (info.Length > 1000000) // 1당 byte
                    {
                        MessageBox.Show("사진 용량이 너무 큽니다 \n" + info.Length.ToString() + " byte > " + "1000000 byte");
                        return;
                    }

                    string saveDirectory = @"C:\BCU_SaveDirectory";

                    if (!System.IO.Directory.Exists(saveDirectory)) // 디렉토리가 존재하는지 조사
                        System.IO.Directory.CreateDirectory(saveDirectory); // 없을시 디렉토리 생성

                    PictureBox pb = new PictureBox();

                    pb.Load(file);
                    pb.Image.Save(saveDirectory + "\\test_image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch(Exception e)
                {
                    MessageBox.Show("파일을 불러오는데 실패하였습니다", "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            PictureSave();
        }
    }
}
