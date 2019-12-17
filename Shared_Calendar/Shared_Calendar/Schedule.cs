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

namespace Shared_Calendar
{
    public partial class Schedule : Form
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

        #region 둥근 모서리
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
          int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        #endregion

        string Code = null;
        bool is_main = false;

        public Schedule(string CD)  // 스케줄 코드를 생성자로 받는다 (수정)
        {
            InitializeComponent();
            this.Code = CD;
            dbs = new DBSchedule();
            dbc = new DBColor();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 15, 15));
        }
        public Schedule(bool is_main = false) //일정 생성시
        {
            InitializeComponent();
            dbs = new DBSchedule();
            dbc = new DBColor();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 15, 15));
            this.is_main = is_main;
            if (is_main == true)
            {
                StrDate = dbs.TODAY;
                EndDate = dbs.TODAY;
            }

        }

        DBConnection db = Program.DB;
        DBSchedule dbs = null;
        DBColor dbc = null;
        string pic_CD=null;
        bool check = false;
        private string scheduleCD = null;

       //프로퍼티
        public string ScheduleCD
        {
            get { return scheduleCD; }
            set { scheduleCD = value; }
        }
        public string NameTxt
        {
            get { return nameTxt.Text; }
            set { nameTxt.Text = value; }
        }
        public string ExTxt
        {
            get { return exTxt.Text; }
            set { exTxt.Text = value; }
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
            get { return Convert.ToInt32(!stateCheck.Checked); }
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
            get
            {
                if (colorCom.Text.Equals("gray"))
                    return null;
                else if (colorCom.Text.Equals(""))
                    return null;
                return dbc.GetColorCode(colorCom.Text);
            }
            set
            {
                colorCom.Text = "";
                colorCom.Text = value;
            }
        }


        private DateTime m_focus_dt; // 현재 포커스 날짜
        public DateTime FOCUS_DT
        { // 현재 포커스날짜 프로퍼티
            set { m_focus_dt = value; }
        }
        public DateTime Get_focus_dt() { return m_focus_dt; }

        private void ModifySchedule_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 15, 15));
            if(is_main==false && Code == null)
            {
                EndDate = m_focus_dt;
                StrDate = m_focus_dt;
            }

            this.StartPosition = FormStartPosition.CenterParent;
            strDate.Format = DateTimePickerFormat.Custom;
            strDate.CustomFormat = "yyyy/MM/dd ddd";

            endDate.Format = DateTimePickerFormat.Custom;
            endDate.CustomFormat = "yyyy/MM/dd ddd";

            button1.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button2.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button3.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button4.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button5.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            deleteBtn.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button1.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button2.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button3.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button4.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button5.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            deleteBtn.MouseEnter += new EventHandler(OnTopPanMouseLeave);

            //콤보박스 초기 설정
            for (int i =0; i < 25; i++)
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


            if (db.GR_CD != null)
            {
                StateCheck = 1;
                stateCheck.Enabled = false;
            }

            if (Code != null) // 일정 코드가 null아니면 데이터 불러오기
            {
                set_Data();
            }
            else// 널이면 삭제버튼 안보이게
            {
                deleteBtn.Enabled = false;
                deleteBtn.Visible = false;
            }

        }

        //수정일시(Code != null) 데이터 불러오기
        private void set_Data()
        {
            string sql = "select * from SCHEDULE_TB where SC_CD = '" + Code + "'";
            db.AdapterOpen(sql);
            DataSet rs = new DataSet();
            db.Adapter.Fill(rs, "search");
            DataTable search = rs.Tables["search"];

            DataRow curr = search.Rows[0];
            DateTime strSC = Convert.ToDateTime(curr[4].ToString());
            DateTime endSC = Convert.ToDateTime(curr[5].ToString());

            NameTxt = curr["SC_NM"].ToString();
            ExTxt = curr["SC_EX"].ToString();
            StrDate = (DateTime)curr["SC_STR_DT"];
            EndDate = (DateTime)curr["SC_END_DT"];
            StrHour = strSC.Hour.ToString();
            StrMin = strSC.Minute.ToString();
            EndHour = endSC.Hour.ToString();
            EndMin = endSC.Minute.ToString();
            StateCheck = Convert.ToInt32(curr["SC_PB_ST"]);
            ScheduleCD = curr[0].ToString();

            if (!(curr[7].Equals(System.DBNull.Value)))
            {
                ColorCom = dbc.GetColorName(curr[7].ToString());
                label11.ForeColor = dbc.GetColorInsertCRCD(ColorCom);
            }
            else
            {
                ColorCom = "gray";
                label11.ForeColor = Color.Gainsboro;
            }

            string command = "select * from PICTURE_TB where PIC_CD = '" + curr["SC_PIC_FK"].ToString() + "'";
            db.ExecuteReader(command);
            if (db.Reader.Read())
            {
                Byte[] b = (Byte[])(db.Reader["PIC_DATA"]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);

                ImagePic = img;
                pic_CD = db.Reader["PIC_CD"].ToString();
            }
            else
            {
                ImagePic = null;
                // ColorCom = null;
            }
        }

        //마우스 이벤트
        private void OnTopPanMouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.SlateGray;
        }
        private void OnTopPanMouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        //컨트롤 값 초기화
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

        //시간 관련 콤보박스
        private void checkBox1_CheckedChanged(object sender, EventArgs e) // 일정 하루종일 클릭시
        {
            if (checkBox1.Checked == true)
            {
                endMin.Text = "0";
                endHour.Text = "0";
                strMin.Text = "0";
                strHour.Text = "0";
                endMin.Enabled = false;
                endMin.Visible = false;
                endHour.Enabled = false;
                endHour.Visible = false;
                strMin.Enabled = false;
                strMin.Enabled = false;
                strHour.Enabled = false;
                strHour.Enabled = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label13.Visible = false;

            }
        }
        private void strHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(strHour.SelectedIndex == 24)
            {
                strHour.Text = "0";
                StrDate = StrDate.AddDays(1);

            }
        } //일정 시간
        private void endHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (endHour.SelectedIndex == 24)
            {
                EndDate = EndDate.AddDays(1);
            }
        }//일정 분

        private void colorCom_SelectedIndexChanged(object sender, EventArgs e) // 색깔 콤보박스 선택시 색깔 나타내기 
        {
            int idx = colorCom.SelectedIndex;
            label11.Text = "●";
            // ColorCom = dbc.ColorDic.ElementAt(idx).Key;
            label11.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label11.ForeColor = dbc.GetColorInsertCRCD(ColorCom);

        }

        //사진
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

                        DateTime dt = StrDate;
                        FileSave(file, dt);
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
        private void button5_Click(object sender, EventArgs e) //이미지 지우기 버튼 
        {
            ImagePic = null;
            imagePic.BorderStyle = BorderStyle.None;

        }
        private void button4_Click(object sender, EventArgs e)//이미지 등록하기 버튼 
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
        private void button3_Click(object sender, EventArgs e) //이미지 불러오기 버튼 
        {
            Picture pic = new Picture();
            pic.ShowDialog();
            pic_CD = pic.selectCD;
            ImagePic = pic.selectImage;

        }

        private bool check_data() //시간 유효성 검사 
        {
            if (NameTxt == "")
            {
                MessageBox.Show("일정명을 등록하세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (EndHour == "" || StrHour == "")
            {
                MessageBox.Show("시간을 설정해주세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (EndDate < StrDate)
            {
                MessageBox.Show("일정 시간을 다시 확인해주세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (EndDate.Date == StrDate.Date && Convert.ToInt32(EndHour) < Convert.ToInt32(StrHour))
                {
                   MessageBox.Show("일정 시간을 다시 확인해주세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (Convert.ToInt32(EndHour) == Convert.ToInt32(StrHour) && Convert.ToInt32(EndMin) < Convert.ToInt32(StrMin))
                    {
                        MessageBox.Show("일정 시간을 다시 확인해주세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
        }
        private void button1_Click(object sender, EventArgs e) // 확인버튼 일정(수정, 등록) 을 누르면 
        {
            if (check_data()) // 유효성 검사하는 함수에서 DB에 넣을 값을 검사 문제 없으면 
            {
                DateTime end_Date = EndDate;
                TimeSpan endts = new TimeSpan(int.Parse(EndHour), int.Parse(EndMin), 0);
                end_Date = end_Date.Date + endts;

                DateTime str_Date = StrDate;
                TimeSpan strts = new TimeSpan(int.Parse(StrHour), int.Parse(StrMin), 0);
                str_Date = str_Date.Date + strts;

                if ( checkBox1.Checked == true )
                    {
                    end_Date =end_Date.AddDays(1); 
                    }

                if (db.GR_CD != null)// 그룹일때 
                {

                    if (scheduleCD == null)
                    {
                        dbs.Insert_Schedule(false, db.GR_CD, NameTxt, ExTxt, StateCheck, str_Date, end_Date, pic_CD, ColorCom);
                        MessageBox.Show("일정을 등록했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Clear_Controls();
                        this.Close();

                    }
                    else//SC_GR_FK
                    {
                        string st_day_str = str_Date.ToString("yyyy/MM/dd H:mm"); // 시작일시 스트링 포맷
                        string end_day_str = end_Date.ToString("yyyy/MM/dd H:mm"); // 종료일시 스트링 포맷

                        string sql = "update SCHEDULE_TB";
                        sql += " set SC_NM = '" + NameTxt + "'";
                        sql += ", SC_EX = '" + ExTxt + "'";
                        sql += ", SC_PB_ST =  '" + StateCheck + "'";
                        sql += ", SC_STR_DT = to_date('" + st_day_str + "', 'yyyy/MM/dd hh24:mi')";
                        sql += ", SC_END_DT = to_date('" + end_day_str + "', 'yyyy/MM/dd hh24:mi')";
                        sql += ",  SC_PIC_FK =  '" + pic_CD + "'";
                        sql += ", SC_CR_FK =  '" + ColorCom + "'";
                        sql += ", SC_GR_FK =  '" + db.GR_CD + "'";
                        sql += " where SC_CD =  '" + ScheduleCD + "'";

                        db.ExecuteNonQuery(sql);
                        MessageBox.Show("일정을 수정했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Clear_Controls();
                        this.Close();

                    }
                }
                else // 개인일때
                {
                    if (scheduleCD == null) // 등록
                    {
                        dbs.Insert_Schedule(true, db.UR_CD, NameTxt, ExTxt, StateCheck, str_Date, end_Date, pic_CD, ColorCom);
                        MessageBox.Show("일정을 등록했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Clear_Controls();
                        this.Close();

                    }
                    else //수정
                    {
                        string st_day_str = str_Date.ToString("yyyy/MM/dd H:mm"); // 시작일시 스트링 포맷
                        string end_day_str = end_Date.ToString("yyyy/MM/dd H:mm"); // 종료일시 스트링 포맷

                        string sql = "update SCHEDULE_TB";
                        sql += " set SC_NM = '" + NameTxt + "'";
                        sql += ", SC_EX = '" + ExTxt + "'";
                        sql += ", SC_PB_ST =  '" + StateCheck + "'";
                        sql += ", SC_STR_DT = to_date('" + st_day_str + "', 'yyyy/MM/dd hh24:mi')";
                        sql += ", SC_END_DT = to_date('" + end_day_str + "', 'yyyy/MM/dd hh24:mi')";
                        sql += ",  SC_PIC_FK =  '" + pic_CD + "'";
                        sql += ", SC_CR_FK =  '" + ColorCom + "'";
                        sql += ", SC_UR_FK =  '" + db.UR_CD + "'";
                        sql += " where SC_CD =  '" + ScheduleCD + "'";

                        db.ExecuteNonQuery(sql);
                        MessageBox.Show("일정을 수정했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Clear_Controls();
                        this.Close();

                    }
                }
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(ScheduleCD == null)
            {
                MessageBox.Show(" 삭제할 일정이 없습니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                dbs.Delete_Schedule(ScheduleCD);
                MessageBox.Show(" 삭제 되었습니다 ", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Clear_Controls();
            }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void strDate_ValueChanged(object sender, EventArgs e)
        {
            StrDate = strDate.Value;
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            EndDate = endDate.Value;
        }
    }
}
