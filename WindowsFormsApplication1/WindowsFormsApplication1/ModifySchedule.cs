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
using Oracle.DataAccess.Client;

namespace WindowsFormsApplication1
{
    public partial class ModifySchedule : Form
    {
        public ModifySchedule()
        {
            InitializeComponent();
            db.UR_CD = "U100000";
        }

        DBConnection db = Program.DB;
        DBSchedule dbs = new DBSchedule();
        string pic_CD=null;
        

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
        public string StrHour
        {
            get { return strHour.Text; }
            set { strHour.Text = value; }
        }
        public string StrMin
        {
            get { return strMin.Text; }
            set { strMin.Text = value; }
        }
        public string EndHour
        {
            get { return endHour.Text; }
            set { endHour.Text = value; }
        }
        public string EndMin
        {
            get { return endMin.Text; }
            set { endMin.Text = value; }
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
            get { return Convert.ToInt32(stateCheck.Checked); }
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

            strDate.Format = DateTimePickerFormat.Custom;
            strDate.CustomFormat = "yyyy/MM/dd ddd";

            endDate.Format = DateTimePickerFormat.Custom;
            endDate.CustomFormat = "yyyy/MM/dd ddd";

            for(int i =0; i < 25; i++)
            {
                strHour.Items.Add(i);
                endHour.Items.Add(i);
            }
            for (int i = 0; i < 60; i+= 10)
            {
                strMin.Items.Add(i);
                endMin.Items.Add(i);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void strHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(strHour.SelectedIndex == 24)
            {
                strMin.Text = "00";
                strMin.Enabled = false;
            }
        }

        private void endHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (endHour.SelectedIndex == 24)
            {
                endMin.Text = "00";
                endMin.Enabled = false;
            }
        }
        private void FileSave(string filePath, DateTime dt)
        {
            // 입력받은 파일을 바이트 배열에 저장
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fs.Length - 1];
            fs.Read(b, 0, b.Length);
            fs.Close();


            // 배열에 있는 데이터를 보낼 정보를 담는다
            OracleParameter op = new OracleParameter();
            op.ParameterName = ":BINARYFILE";
            op.OracleDbType = Oracle.DataAccess.Client.OracleDbType.Blob;
            op.Direction = ParameterDirection.Input;
            op.Size = b.Length;
            op.Value = b;
            db.Command.CommandType = CommandType.Text;
            db.Command.Parameters.Add(op); // 커맨드에 이 파라미터를 추가시켜서 db에 보낼때 같이 보낼수있게 함

            db.ExecuteReader("select TO_CHAR(SEQ_PICCD.nextval) from dual"); // 다음 시퀀스 값 불러오기
            string currSeq = null;
            if (db.Reader.Read())
                currSeq = db.Reader.GetString(0);

            db.ExecuteNonQuery("insert into PICTURE_TB values('P'||SEQ_PICCD.currval, '1', '" + dt.ToString("yyyy-MM-dd") + "' , '" + db.UR_CD + "', null, :BINARYFILE)");
            db.Command.Parameters.Remove(op); // 삭제를 꼭 시켜야한다 안하면 사진생성을 두번이상 실행안됨
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

                    Picture_SelectDate ps = new Picture_SelectDate();

                    if (ps.ShowDialog() == DialogResult.OK)
                    {
                        DateTime dt = ps.dt;
                        FileSave(file, dt);

                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("파일을 불러오는데 실패하였습니다\n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(ImagePic != null)
            //{
            //    string str = "insert ";
            //    db.ExecuteNonQuery(str);

            //    str = "select CD form __ where data ";
            //    db.ExecuteReader(str);
                
            //}
            DateTime end_Date = EndDate;
            TimeSpan endts = new TimeSpan(int.Parse(EndHour), int.Parse( EndMin), 0);
            end_Date=end_Date += endts;

            DateTime str_Date = StrDate;
            TimeSpan strts = new TimeSpan(int.Parse(StrHour), int.Parse(StrMin), 0);
            str_Date = str_Date.Date + strts;
        

            dbs.Insert_Schedule(true, db.UR_CD, NameTxt, ExTxt, StateCheck, str_Date, end_Date, null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PictureSave();
            string str = "select * from PICTURE_TB where PIC_UR_FK = '" + db.UR_CD + "' ORDER BY PIC_CD DESC";
            db.ExecuteReader(str);
            if(db.Reader.Read())
            {
                pic_CD = db.Reader["PIC_CD"].ToString();
            }
            Byte[] b = (Byte[])(db.Reader["PIC_DATA"]);
            MemoryStream stmBlobData = new MemoryStream(b);
            Image img = Image.FromStream(stmBlobData);
            ImagePic = img;
        }
    }
}
