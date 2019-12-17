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


namespace Shared_Calendar
{
    public partial class UserInfo_Picture : Form
    {

        #region 폼 그림자 생성
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        DBConnection db = Program.DB;
        public Image defaultImage;
        public Image img;
        public bool isImg;

        public UserInfo_Picture(Image img, bool isImg)
        {
            InitializeComponent();
            defaultImage = pictureBox1.Image;
            if (isImg)
            {
                pictureBox1.Image = img;
                this.img = img;
            }else
                img = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            img = null;
            pictureBox1.Image = defaultImage;
            isImg = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Picture pic = new Picture();
            pic.ShowDialog();
            string selectCD = pic.selectCD;
            Image selectImage = pic.selectImage;
            pictureBox1.Image = selectImage;
            img = pictureBox1.Image;
            isImg = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureSave();
            img = pictureBox1.Image;
            isImg = true;
        }

        public void PictureSave()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "사진추가";
            ofd.Filter = "모든 사진파일|*.jpg;*.png|JPG 파일 (*.jpg)|*.jpg|PNG 파일 (*.png)|*.png"; // 필터 형식

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK) // 대화상자에서 OK를 누르면
            {
                try
                {
                    // 파일명 설정 추가해야함
                    string file = @ofd.FileName; // 눌러진 사진의 path
                    FileInfo info = new FileInfo(file);

                    if (info.Length > 2000000) // 1당 byte, 바이트가 너무 큰 사진은 막음
                    {
                        MessageBox.Show("사진 용량이 너무 큽니다 \n" + info.Length.ToString() + " byte > " + "1000000 byte");
                        return;
                    }

                    if (MessageBox.Show("사진을 올리시겠습니까?", "사진등록", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                    {
                        return;
                    }

                    FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                    byte[] b = new byte[fs.Length - 1];
                    fs.Read(b, 0, b.Length);
                    MemoryStream stmBlobData = new MemoryStream(b);
                    Image img = Image.FromStream(stmBlobData);
                    pictureBox1.Image = img;
                    MessageBox.Show("사진이 등록되었습니다", "사진등록", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    isImg = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("파일을 불러오는데 실패하였습니다\n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if(img == null)
            //{
            //    //db.ExecuteNonQuery("UPDATE USER_TB SET UR_PIC = null WHERE UR_CD = '" + db.UR_CD + "'");
            //    this.DialogResult = DialogResult.OK;
            //    Close();
            //}

            //MemoryStream ms = new MemoryStream();
            //Image imgA = pictureBox1.Image;
            //imgA.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            //byte[] b = ms.ToArray();

            //OracleParameter op = new OracleParameter();
            //op.ParameterName = ":BINARYFILE";
            //op.OracleDbType = Oracle.DataAccess.Client.OracleDbType.Blob;
            //op.Direction = ParameterDirection.Input;
            //op.Size = b.Length;
            //op.Value = b;
            //db.Command.CommandType = CommandType.Text;
            //db.Command.Parameters.Add(op); // 커맨드에 이 파라미터를 추가시켜서 db에 보낼때 같이 보낼수있게 함

            //db.ExecuteNonQuery("UPDATE USER_TB SET UR_PIC = :BINARYFILE WHERE UR_CD = '" + db.UR_CD + "'");
            //db.Command.Parameters.Remove(op); // 삭제를 꼭 시켜야한다 안하면 사진생성을 두번이상 실행안됨
            //MessageBox.Show("사진이 적용되었습니다", "사진적용", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
