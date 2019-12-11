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
    public partial class Main : Form
    {
        DBConnection db = Program.DB;
        DBSchedule sc_db = new DBSchedule();

        Picture pic = null;
        Login log = null;
        bool isShowPic;

        private DateTime m_focus_dt; // 현재 포커스 날짜
        public DateTime FOCUS_DT
        {  //프로퍼티
            get { return m_focus_dt; }
            set { m_focus_dt = value; }
        }

        public Main(Login log) // 로그인에서 메인 폼이 만들어졌으므로 로그인 객체를 가지고있다가 종료시 같이 삭제
        {                      // 이렇게 안할시 메인폼은 종료되어도 로그인폼은 계속 프로세스에 남아있음
            this.log = log;    // 로그인 폼 종료 코드는 Dispose (Main.Designer.cs) 메서드에 정의되어있음
            InitializeComponent();
        }

        public UserCustomControl.Profile USERPROFILE
        { 
            // Userprofile 프로퍼티 -> login에서 값 넘겨줌
            get { return UserProfile_prof; }
            set { UserProfile_prof = value; }
        }

        public string USERID
        {
            // userid 프로퍼티 -> login에서 값 넘겨줌
            get { return 사용자ToolStripMenuItem.Text; }
            set { 사용자ToolStripMenuItem.Text = value; }
        }


        Month mnt = new Month();
        private void setCenterMonthPanel()
        { // 센터패널 설정 함수 (월간 폼 가져오기)
            MainCenter_pan.Controls.Clear();

            mnt.TopLevel = false;
            mnt.TopMost = true;

            m_focus_dt = week.FOCUS_DT;
            mnt.FOCUS_DT = m_focus_dt;

            mnt.Parent = this;
            MainCenter_pan.Controls.Add(mnt);
            mnt.Location = new Point(0, 0);
            mnt.Show();

            Check_FriendRequest(); // -----------------------------어디다가 넣어야 메인이 띄워지고 메세지 박스가 뜰까?????
        }


        Week week = new Week();
        private void setCenterWeekPanel()
        { // 센터패널 설정 함수 (주간 폼 가져오기)
            MainCenter_pan.Controls.Clear();

            week.TopLevel = false;
            week.TopMost = true;

            //m_focus_dt = mnt.FOCUS_DT;
            m_focus_dt = sc_db.TODAY;
            week.FOCUS_DT = m_focus_dt;

            week.Parent = this;
            MainCenter_pan.Controls.Add(week);
            week.Location = new Point(0, 0);
            week.Show();
        }

        private void Set_UserProfile()
        {
            // UserProfile_pro 초기 설정 함수
            UserProfile_prof.Set_Profile_Size(UserProfile_prof.Height, FontStyle.Bold);
            UserProfile_prof.Left = (MainUser_pan.Width - UserProfile_prof.Width) / 2;
            UserProfile_prof.Top = (MainUser_pan.Height - UserProfile_prof.Height) / 2;
        }
        
        //abcabc hello
        private void Main_Load(object sender, EventArgs e)
        {
            isShowPic = false; // 사진폼 띄우지않음

            //m_Today_lbl.Text = sc_db.TODAY.ToString("yyyy.MM.dd"); // 오늘 날짜 설정
            //mnt.FOCUS_DT = week.FOCUS_DT = m_focus_dt = sc_db.TODAY;

            setCenterMonthPanel(); // 월간보기로 기본설정
            Set_UserProfile();
           
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e) // 메뉴스트립 닫기버튼
        {
            if (pic != null)
                pic.Dispose();
            Close();
        }

        private void PictureForm_btn_Click(object sender, EventArgs e) // 사진 폼 띄우기 버튼
        {
            if (!isShowPic)
            {
                pic = new Picture(this);
                pic.StartPosition = FormStartPosition.Manual; // 사진 폼 시작 포지션 설정
                pic.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y); // 현재 폼의 X좌표+현재폼의 길이, 현재폼의 Y좌표
                pic.Show();

                isShowPic = true;
                return;
            }
            else
            {
                pic.Dispose();  
                isShowPic = false;
            }
        }


        Point fPt; // 폼 위치
        bool isMove; // 마우스 눌림 상태

        private void MainHeader_menustp_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 눌렀을 때
            isMove = true; // 버튼을 누르면 움직이게
            fPt = new Point(e.X, e.Y); // 버튼을 눌렀을 때 위치
        }

        private void MainHeader_menustp_MouseMove(object sender, MouseEventArgs e)
        {
            // 마우스 움직였을 때
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            { // 마우스가 눌려지고, 왼쪽 버튼일 경우에 수행
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
                if (isShowPic) // 사진폼이 띄어져있으면 사진폼도 이동
                {
                    pic.Location = new Point(pic.Left - (fPt.X - e.X), pic.Top - (fPt.Y - e.Y));
                }// 폼 Location 재지정
            }
        }

        private void MainHeader_menustp_MouseUp(object sender, MouseEventArgs e)
        {
            // 마무스 떼었을 때
            isMove = false; // 마우스 떼었을 때 움직이지 않도록
        }

        private void MonthForm_btn_Click(object sender, EventArgs e) // 월간 일정 보기 클릭 시
        {
            MonthForm_btn.Enabled = false; // 월간 보기 버튼 비활성화
            WeekForm_btn.Enabled = true; // 주간 보기 버튼 활성화
            MonthForm_btn.BackColor = Color.Gainsboro;
            WeekForm_btn.BackColor = Color.White;
            setCenterMonthPanel(); // 월간 폼 띄우기
        }

        private void WeekForm_btn_Click(object sender, EventArgs e)
        {
            WeekForm_btn.Enabled = false; // 주간 보기 버튼 비활성화
            MonthForm_btn.Enabled = true; // 월간 보기 버튼 활성화
            WeekForm_btn.BackColor = Color.Gainsboro;
            MonthForm_btn.BackColor = Color.White;
            setCenterWeekPanel(); // 주간 폼 띄우기
        }


       private void Check_FriendRequest() // 메인이 실행 될때 친구친청 온게 있는지 확인 - CJE 
       {
            string command = "select * from FRIEND_TB where FR_FR_FK ='" + db.UR_CD + "' and FR_ACEP_ST = 0";
            db.ExecuteReader(command);
            if(db.Reader.Read())
            {
                if (MessageBox.Show("친구 신청이 왔습니다 확인 하시겠습나까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FriendCheck friendCheck = new FriendCheck();
                    friendCheck.ShowDialog();
                }
            }

       }

        private void 일정추가ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModifySchedule modifySchedule = new ModifySchedule();
            modifySchedule.ShowDialog();
        }
    }
}
