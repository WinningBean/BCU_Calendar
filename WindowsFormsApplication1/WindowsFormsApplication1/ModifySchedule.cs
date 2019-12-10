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
        Main main = null;
        public ModifySchedule(Main main ) // 메인에서 호출 
        {
            InitializeComponent();
            db.UR_CD = "U100000";
            this.main = main;
        }
        public ModifySchedule() // 그냥 ?
        {
            InitializeComponent();
            db.UR_CD = "U100000";
        }

        DBConnection db = Program.DB;
        DBSchedule dbs = new DBSchedule();
        DBColor dbc = new DBColor();
        string pic_CD=null;
        bool check = false;
        private string scheduleCD = null;

        public string ScheduleCD
        {
            get { return scheduleCD; }
            set { scheduleCD = value.ToString(); }
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
                    float percent = (float)img.Height / 120;
                    int imgWidth = (int)((float)img.Width / percent);
                    imagePic.Size = new Size(imgWidth, 120);
                    imagePic.SizeMode = PictureBoxSizeMode.Zoom;
                    imagePic.BorderStyle = BorderStyle.None;
                    imagePic.Image = img;
                }
                else
                {
                    imagePic.BorderStyle = BorderStyle.FixedSingle;
                    imagePic.Image = null;
                }
              
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
        public string ColorCom
        {
            get { return dbc.GetColorCode(colorCom.Text); }
            set { colorCom.Text = value; }
        }


        private void ModifySchedule_Load(object sender, EventArgs e)
        {
            label11.ForeColor = dbc.GetColorInsertCRCD(ColorCom);
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

            StrMin= "00";
            EndMin = "00";

            for(int i = 0; i < dbc.ColorDic.Values.Count; i++ )
            { 
                
                colorCom.Items.Add(dbc.ColorDic.ElementAt(i).Value);
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
            else
            {
                strMin.Enabled = true;
            }
        }
        private void Clear_Controls()
        {
            NameTxt = "";
            ExTxt = "";
            StrHour = "0";
            StrMin = "0";
            EndHour = "0";
            EndMin = "0";
            StateCheck = 1;
        }

        private void endHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (endHour.SelectedIndex == 24)
            {
                endMin.Text = "00";
                endMin.Enabled = false;
            }
            else
            {
                endMin.Enabled = true;
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


        public bool PictureSave()
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
                        return false;
                    }

                    if (MessageBox.Show("사진을 올리시겠습니까?", "사진등록", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                    {
                        return true;
                    }

                    Picture_SelectDate ps = new Picture_SelectDate();

                    if (ps.ShowDialog() == DialogResult.OK)
                    {
                        DateTime dt = ps.dt;
                        FileSave(file, dt);
                        return true;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("파일을 불러오는데 실패하였습니다\n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (EndHour == "" || StrHour == "")
            {
                MessageBox.Show("시간을 설정해주세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NameTxt == "")
            {
                MessageBox.Show("일정명을 등록하세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {//EndHour, EndMin
                DateTime end_Date = EndDate;
                TimeSpan endts = new TimeSpan(int.Parse(EndHour), int.Parse(EndMin), 0);
                end_Date = end_Date.Date + endts;

                DateTime str_Date = StrDate;
                TimeSpan strts = new TimeSpan(int.Parse(StrHour), int.Parse(StrMin), 0);
                str_Date = str_Date.Date + strts;

                if (scheduleCD ==  null)
                {
                    dbs.Insert_Schedule(true, db.UR_CD, NameTxt, ExTxt, StateCheck, str_Date, end_Date, pic_CD, ColorCom);
                    MessageBox.Show("일정을 등록했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Clear_Controls();
                }
                else
                {
                    string st_day_str = str_Date.ToString("yyyy/MM/dd H:mm"); // 시작일시 스트링 포맷
                    string end_day_str = end_Date.ToString("yyyy/MM/dd H:mm"); // 시작일시 스트링 포맷
                    string sql = "  update SCHEDULE_TB set SC_NM = '" + NameTxt + "', SC_EX = '" + ExTxt + "', SC_PB_ST =  '" + StateCheck + "', SC_STR_DT = to_date('" + st_day_str + "', 'yyyy/MM/dd hh24:mi'), SC_END_DT = to_date('" + end_day_str + "', 'yyyy/MM/dd hh24:mi'),  SC_PIC_FK =  '" + pic_CD + "', SC_CR_FK =  '" + ColorCom + "' where SC_CD =  '" + ScheduleCD + "'";
                    db.ExecuteNonQuery(sql);
                    MessageBox.Show("일정을 수정했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Clear_Controls();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)//사진 등록하기 버튼 
        {
            check = PictureSave();
            if (check == true)
            {
                string str = "select * from PICTURE_TB where PIC_UR_FK = '" + db.UR_CD + "' ORDER BY PIC_CD DESC";
                db.ExecuteReader(str);
                if (db.Reader.Read())
                {
                    pic_CD = db.Reader["PIC_CD"].ToString(); // PIC_CD 저장 
                }
                Byte[] b = (Byte[])(db.Reader["PIC_DATA"]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);
                ImagePic = img;
            }

        }

        private void colorCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = colorCom.SelectedIndex;
            label11.Text = "●";
           // ColorCom = dbc.ColorDic.ElementAt(idx).Key;
            label11.Font = new System.Drawing.Font("함초롬돋움", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label11.ForeColor = dbc.GetColorInsertCRCD(ColorCom);
      
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // 일정 하루종일 
        {
            if (checkBox1.Checked == true)
            {
                endMin.Text = "00";
                endMin.Enabled = false;
                endHour.Text = "0";
                endHour.Enabled = false;
                strMin.Text = "00";
                strMin.Enabled = false;
                strHour.Text = "0";
                strHour.Enabled = false;
                if(StrDate.Date == EndDate.Date)//하루종일인데 날짜가 같을 경우 +1
                {
                    EndDate = EndDate.AddDays(1) ;
                }
            }
            else
            {
                endMin.Enabled = true;
                endHour.Enabled = true;
                strMin.Enabled = true;
                strHour.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e) // 이미지 지우기 버튼 
        {
            ImagePic = null;
            imagePic.BorderStyle = BorderStyle.None;

        }

        private void button3_Click(object sender, EventArgs e) // 불러오기 버튼 
        {
            Picture pic = new Picture();
            pic.ShowDialog();
            pic_CD = pic.selectCD;
            ImagePic = pic.selectImage;
            string str = "select * from PICTURE_TB where PIC_UR_FK = '" + db.UR_CD + "' ORDER BY PIC_CD DESC";
            db.ExecuteReader(str);
            if (db.Reader.Read())
            {
                pic_CD = db.Reader["PIC_CD"].ToString(); // PIC_CD 저장 
            }
        }
    }
}
