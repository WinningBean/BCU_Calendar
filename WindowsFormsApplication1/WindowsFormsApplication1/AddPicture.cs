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

        DBConnection db = Program.DB;
        DataSet PictureDS = null;
        DataTable PictureDT = null;

        int pictureLocation;
        int rowNum;
        int currWheel;
        int nextWheel;

        public AddPicture()
        {
            InitializeComponent();
            pictureLocation = 0;
            rowNum = 0;
            currWheel = 0;
            nextWheel = -700;
        }

        private void AddPicture_Load(object sender, EventArgs e)
        {
            PictureLoad();
            PictureShow();
        }

        public void PictureSave()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "사진추가";
            ofd.Filter = "모든 사진파일|*.jpg;*.png|JPG 파일 (*.jpg)|*.jpg|PNG 파일 (*.png)|*.png";

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                try
                {
                    // 파일명 설정 추가해야함
                    string file = @ofd.FileName;
                    FileInfo info = new FileInfo(file);

                    if (info.Length > 2000000) // 1당 byte
                    {
                        MessageBox.Show("사진 용량이 너무 큽니다 \n" + info.Length.ToString() + " byte > " + "1000000 byte");
                        return;
                    }

                    if(MessageBox.Show("사진을 올리시겠습니까?" ,"사진등록", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                    {
                        return;
                    }

                    db.FileSave(file);
                    MessageBox.Show("사진이 등록되었습니다", "사진등록", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    PictureClear();
                    PictureLoad();
                    PictureShow();
                    

                }
                catch (Exception e)
                {
                    MessageBox.Show("파일을 불러오는데 실패하였습니다\n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PictureClear()
        {
            Picture_pan.Controls.Clear();
            pictureLocation = 0;
            rowNum = 0;
            currWheel = 0;
        }
        private void PictureLoad()
        {
            db.AdapterOpen("select * from PICTURE_TB where PIC_UR_FK = '" + db.UR_CD + "' ORDER BY PIC_DT DESC");
            PictureDS = new DataSet();
            db.Adapter.Fill(PictureDS, "PICTURE_TB");
            PictureDT = PictureDS.Tables["PICTURE_TB"];
        }

        private void PictureShow()
        {
            int i = 0;
            while(i < 10 && PictureDT.Rows.Count > rowNum)
            {
                DataRow currRow = PictureDT.Rows[rowNum++];
                Byte[] b = (Byte[])(currRow["PIC_DATA"]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);
                CreatePicure(pictureLocation, img);
                i++;
                pictureLocation += 120;
            }
        }

        private void CreatePicure(int location, Image img)
        {
            PictureBox pb = new PictureBox();
            Picture_pan.Controls.Add(pb);
            pb.Size = new Size(250, 120);
            pb.Location = new Point(0, location);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Image = img;
            pb.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            PictureSave();
        }
        
        private void Picture_pan_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (currWheel >= 0)
                    return;
                currWheel += 20;
                for (int i = 0; i < Picture_pan.Controls.Count; i++)
                {
                    Point p = Picture_pan.Controls[i].Location;
                    p.Y = p.Y + 20;
                    Picture_pan.Controls[i].Location = p;
                }
            }
            else
            {
                currWheel -= 20;
                for (int i = 0; i < Picture_pan.Controls.Count; i++)
                {
                    Point p = Picture_pan.Controls[i].Location;
                    p.Y = p.Y - 20;
                    Picture_pan.Controls[i].Location = p;
                }
            }
            if(currWheel > nextWheel)
            {
                PictureShow();
                nextWheel *= 2;
            }
            label5.Text = currWheel.ToString();

        }
    }

}
