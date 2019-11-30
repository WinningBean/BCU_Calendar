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
        Login log = null;

        public Main(Login log)
        {
            this.log = log;
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

        private void setCenterMonthPanel()
        { // 센터패널 설정 함수 (월간 폼 가져오기)
            MainCenter_pan.Controls.Clear();
            Month mnt = new Month();
            mnt.TopLevel = false;
            mnt.TopMost = true;

            mnt.Parent = this;
            MainCenter_pan.Controls.Add(mnt);
            mnt.Location = new Point(0, 0);
            mnt.Show();
        }

        private void setCenterWeekPanel()
        { // 센터패널 설정 함수 (주간 폼 가져오기)
            MainCenter_pan.Controls.Clear();
            Login week = new Login();
            week.TopLevel = false;
            week.TopMost = true;

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
            //UserName_txt.Text = db.UR_CD;
            setCenterMonthPanel(); // 월간보기로 기본설정
            m_Today_lbl.Text = DateTime.Now.ToString("yyyy.MM.dd"); // 오늘 날짜(시스템 날짜) 가져오기
            Set_UserProfile();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e) // 메뉴스트립 닫기버튼
        {
            Close();
        }

        private void PictureForm_btn_Click(object sender, EventArgs e) // 사진 폼 띄우기 버튼
        {
            Picture pic = new Picture();
            pic.StartPosition = FormStartPosition.Manual; // 사진 폼 시작 포지션 설정
            pic.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y); // 현재 폼의 X좌표+현재폼의 길이, 현재폼의 Y좌표
            pic.Size = new Size(pic.Size.Width, this.Size.Height); // 메인폼 높이를 같이 설정
            pic.Show();
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
                // 폼 Location 재지정
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

    }
}
