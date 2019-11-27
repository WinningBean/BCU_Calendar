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

    public partial class Picture : Form
    {

        DBConnection db = Program.DB;
        DataSet PictureDS = null;
        DataTable PictureDT = null;
        DateTime preDate;

        int pictureLocation;
        int rowNum;
        int currWheel;
        Point lastPicture;

        Panel insidePan;

        public Picture()
        {
            InitializeComponent();
            pictureLocation = 0;
            rowNum = 0;
            currWheel = 0;
            insidePan = ClonePan(Picture_pan);
            Picture_pan.Controls.Add(insidePan);
        }

        private Panel ClonePan(Panel p)
        {
            Panel another = new Panel();
            another.Size = new Size(p.Size.Width, 999999);
            another.Location = new Point(0, 0); 
            return another;
        }

        private void AddPicture_Load(object sender, EventArgs e)
        {
            PictureLoad();
            preDate = new DateTime();
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
            insidePan.Controls.Clear();
            insidePan.Location = new Point(0, 0);
            pictureLocation = 0;
            rowNum = 0;
            currWheel = 0;
            preDate = new DateTime();
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
            while (i < 10 && rowNum < PictureDT.Rows.Count)
            {
                DataRow currRow = PictureDT.Rows[rowNum++]; // 행 하나씩 받아옴
                string date = currRow["PIC_DT"].ToString();
                int year = Convert.ToInt32(date.Substring(0, 4));
                int month = Convert.ToInt32(date.Substring(5, 2));
                int day = Convert.ToInt32(date.Substring(8, 2));
                DateTime currDate = new DateTime(year, month, day);

                if (!preDate.Equals(currDate)) // 날짜를 추가하는 부분
                {
                    preDate = currDate;
                    Label lb = new Label();
                    insidePan.Controls.Add(lb);
                    lb.Text = preDate.ToShortDateString();
                    lb.Location = new Point(10, pictureLocation);
                    lb.AutoSize = true;
                    lb.Size = new System.Drawing.Size(60, 24);
                    lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lb.Show();

                    pictureLocation += 34; // 라벨 y값 + y 10 띄우기 해서 34
                 }
                Byte[] b = (Byte[])(currRow["PIC_DATA"]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);
                pictureLocation = CreatePicure(pictureLocation, img);
                i++;
                lastPicture = insidePan.Controls[insidePan.Controls.Count - 1].Location;
            }
        }

        private int CreatePicure(int location, Image img)
        {
            PictureBox pb = new PictureBox();
            insidePan.Controls.Add(pb);

            float percent = (float)img.Width / 250;
            int imgHeight = (int)((float)img.Height / percent);

            pb.Size = new Size(250, imgHeight);
            pb.Location = new Point(0, location);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            //pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Image = img;
            pb.Show();
            return location + imgHeight + 10; // 기본 y + 사진 y + 띄울공간 10
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            PictureSave();
        }
        
        private void Picture_pan_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (currWheel <= (pictureLocation * -1) + Picture_pan.Height)
                    return;
                currWheel -= 10;
                insidePan.Location = new Point(insidePan.Location.X, insidePan.Location.Y - 10);
                
            }
            else
            {
                if (currWheel >= 0)
                    return;
                currWheel += 10;
                insidePan.Location = new Point(insidePan.Location.X, insidePan.Location.Y + 10);

            }
            if(currWheel - 10 < lastPicture.Y)
            {
                PictureShow();
            }
            label7.Text = pictureLocation.ToString();
            label5.Text = currWheel.ToString();
            label6.Text = lastPicture.Y.ToString();
        }
    }

}
