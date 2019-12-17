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
    public partial class Main : Form
    {
        public Main(Login log) // 로그인에서 메인 폼이 만들어졌으므로 로그인 객체를 가지고있다가 종료시 같이 삭제
        {                      // 이렇게 안할시 메인폼은 종료되어도 로그인폼은 계속 프로세스에 남아있음
            this.log = log;    // 로그인 폼 종료 코드는 Dispose (Main.Designer.cs) 메서드에 정의되어있음

            InitializeComponent();
            Set_BS_ctr();
        }

        // ---------- VARIABLE ----------

        private DBConnection db = Program.DB;
        private DBSchedule sc_db = new DBSchedule();

        private Picture pic = null;
        private Login log = null;
        private bool isShowPic;
        private bool isShowToDo;

        private DateTime m_focus_dt; // 현재 포커스 날짜

        // ---------- PROPERTY ----------

        public DateTime FOCUS_DT
        {  //프로퍼티
            get { return m_focus_dt; }
            set { m_focus_dt = value; }
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

        // ---------- LeftTab ----------

        LeftTab bs_leftTab = new LeftTab();
        private void setLeftBasicPanel()
        { // 왼쪽 패널 설정 함수 (베이스 왼쪽 폼 가져오기)
            fr_tab.Hide();

            bs_leftTab.PUBLIC_BTN.Click += new System.EventHandler(this.Public_SC_btn_Click);
            bs_leftTab.PRIVATE_BTN.Click += new System.EventHandler(this.Private_SC_btn_Click);
            bs_leftTab.GROUP_lstbox.SelectedIndexChanged += new System.EventHandler(this.Group_lstbox_SelectedIndexChanged);
            bs_leftTab.SchGROUP_lstbox.SelectedIndexChanged += new System.EventHandler(this.SchGroup_lstbox_SelectedIndexChanged);

            MainLeft_pan.Controls.Add(bs_leftTab);
            bs_leftTab.Show();
        }

        private void Public_SC_btn_Click(object sender, EventArgs e)
        {
            db.IS_PB = 1;
            mnt.SET_MONTH();
            week.resetSchedual();
            if (isShowToDo)
                tdl.reset();
            if (isShowPic)
                pic.reset();
        }

        private void Private_SC_btn_Click(object sender, EventArgs e)
        {
            db.IS_PB = 0;
            mnt.SET_MONTH();
            week.resetSchedual();
            if (isShowToDo)
                tdl.reset();
            if (isShowPic)
                pic.reset();
        }

        private void Group_lstbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.GR_CD = bs_leftTab.GROUP_CD_lst[((ListBox)sender).SelectedIndex];
            grp = new Group();
            grp.TopLevel = false;
            grp.TopMost = true;
            grp.Parent = this;
            grp.Location = new Point(0, 0);

            MemProf_lst = new List<UserCustomControl.Profile>();
            MemCD_lst = new List<string>();

            MainLeft_pan.Controls.Add(grp);
            grp.Show();
            bs_leftTab.Hide();

            if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
            else setCenterWeekPanel();

            if (isShowToDo)
                tdl.reset();
            if (isShowPic)
                pic.reset();

            bs_leftTab.reset();

            MemProf_lst = grp.MEMBER_PROF_lst;
            MemCD_lst = grp.MEMBER_CD_lst;

            grp.CLOSE_btn.Click += new System.EventHandler(this.Close_btn_Click);
            grp.GROUP_NM_lbl.Click += new System.EventHandler(this.GR_nm_lbl_Click);
            grp.MODI_GR_btn.Click += new System.EventHandler(this.Modi_GR_btn_Click);

            for (int i = 0; i < MemProf_lst.Count; i++)
            {
                MemProf_lst[i].Click += new System.EventHandler(this.Mem_prof_Click);
                MemProf_lst[i].USERNAME.Click += new System.EventHandler(this.Mem_prof_lbl_Click);
                MemProf_lst[i].USERPIC.Click += new System.EventHandler(this.Mem_prof_pic_Click);
            }
        }

        private void SchGroup_lstbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.GR_CD = bs_leftTab.SchGROUP_CD_lst[((ListBox)sender).SelectedIndex];
            grp = new Group();
            grp.TopLevel = false;
            grp.TopMost = true;
            grp.Parent = this;
            grp.Location = new Point(0, 0);

            MemProf_lst = new List<UserCustomControl.Profile>();
            MemCD_lst = new List<string>();

            MainLeft_pan.Controls.Add(grp);
            grp.Show();
            bs_leftTab.Hide();

            if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
            else setCenterWeekPanel();

            if (isShowToDo)
                tdl.reset();
            if (isShowPic)
                pic.reset();

            bs_leftTab.reset();

            MemProf_lst = grp.MEMBER_PROF_lst;
            MemCD_lst = grp.MEMBER_CD_lst;

            grp.CLOSE_btn.Click += new System.EventHandler(this.Close_btn_Click);
            grp.GROUP_NM_lbl.Click += new System.EventHandler(this.GR_nm_lbl_Click);
            grp.MODI_GR_btn.Click += new System.EventHandler(this.Modi_GR_btn_Click);

            for (int i = 0; i < MemProf_lst.Count; i++)
            {
                MemProf_lst[i].Click += new System.EventHandler(this.Mem_prof_Click);
                MemProf_lst[i].USERNAME.Click += new System.EventHandler(this.Mem_prof_lbl_Click);
                MemProf_lst[i].USERPIC.Click += new System.EventHandler(this.Mem_prof_pic_Click);
            }
        }

        // ---------- Group ----------

        private List<UserCustomControl.Profile> MemProf_lst;
        private List<string> MemCD_lst;
        private Group grp;

        private void GR_nm_lbl_Click(object sender, EventArgs e)
        {
            db.FR_CD = null;
            if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
            else setCenterWeekPanel();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            db.GR_CD = null;
            db.FR_CD = null;

            if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
            else setCenterWeekPanel();

            bs_leftTab.reset();
            bs_leftTab.Show();
            ((Group)((Label)sender).Parent).Close();
        }

        private void Modi_GR_btn_Click(object sender, EventArgs e)
        {
            Group parentGrp = (Group)((Label)sender).Parent;

            Group_Modify modiGR = new Group_Modify(1);
            modiGR.Location = Cursor.Position;
            modiGR.StartPosition = FormStartPosition.Manual;
            modiGR.GRNM_txt = parentGrp.GROUP_NM_lbl.Text;
            if (parentGrp.GROUP_EX_lbl.Text != parentGrp.BS_GREX) modiGR.GREX_txt = parentGrp.GROUP_EX_lbl.Text;

            modiGR.ShowDialog();
            if (db.GR_CD == null)
            {
                parentGrp.Close();
                bs_leftTab.reset();
                bs_leftTab.Show();
                mnt.SET_MONTH();
            }
            parentGrp.SET_GROUPBS();
        }

        private void Mem_prof_Click(object sender, EventArgs e)
        {
            string prof_nm = ((UserCustomControl.Profile)sender).Name;
            int prof_lst_n = Convert.ToInt32(prof_nm.Substring(10, prof_nm.Length - 10));
            db.FR_CD = MemCD_lst[prof_lst_n];
            if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
            else setCenterWeekPanel();
        }

        private void Mem_prof_lbl_Click(object sender, EventArgs e)
        {
            string prof_nm = ((UserCustomControl.Profile)((Label)sender).Parent).Name;
            int prof_lst_n = Convert.ToInt32(prof_nm.Substring(10, prof_nm.Length - 10));
            db.FR_CD = MemCD_lst[prof_lst_n];
            if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
            else setCenterWeekPanel();
        }

        private void Mem_prof_pic_Click(object sender, EventArgs e)
        {
            string prof_nm = ((UserCustomControl.Profile)((UserCustomControl.RoundPictureBox)sender).Parent).Name;
            int prof_lst_n = Convert.ToInt32(prof_nm.Substring(10, prof_nm.Length - 10));
            db.FR_CD = MemCD_lst[prof_lst_n];
            if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
            else setCenterWeekPanel();
        }

        // ---------- FriendList ----------

        private List<UserCustomControl.Profile> FrProf_lst;

        private FriendList fr_tab = new FriendList();
        private void setLeftFriendPanel()
        { // 왼쪽 패널 설정 함수 (친구목록 폼 가져오기)
            bs_leftTab.Hide();
            MainLeft_pan.Controls.Add(fr_tab);
            fr_tab.Show();

            FrProf_lst = new List<UserCustomControl.Profile>();
            FrProf_lst = fr_tab.FRIEND_PROF_lst;

            for (int i = 0; i < FrProf_lst.Count; i++)
            {

                FrProf_lst[i].MouseClick += new System.Windows.Forms.MouseEventHandler(this.Frd_prof_MouseClick);
                FrProf_lst[i].USERNAME.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Frd_prof_lbl_MouseClick);
                FrProf_lst[i].USERPIC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Frd_prof_pic_MouseClick);
            }
        }

        private void Frd_prof_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string prof_nm = ((UserCustomControl.Profile)sender).Name;
                db.FR_CD = prof_nm;
                if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
                else setCenterWeekPanel();
            }
        }

        private void Frd_prof_lbl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string prof_nm = ((UserCustomControl.Profile)((Label)sender).Parent).Name;
                db.FR_CD = prof_nm;
                if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
                else setCenterWeekPanel();
            }
        }

        private void Frd_prof_pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string prof_nm = ((UserCustomControl.Profile)((UserCustomControl.Profile)sender).Parent).Name;
                db.FR_CD = prof_nm;
                if (MonthForm_btn.Enabled == false) setCenterMonthPanel(); // 월간버튼이 비활성화 되어있다면 -> 지금 월간폼을 보고 있다면
                else setCenterWeekPanel();
            }
        }

        // ---------- Month ----------

        private Month mnt = new Month();
        private void setCenterMonthPanel()
        { // 센터패널 설정 함수 (월간 폼 가져오기)

            m_focus_dt = week.Get_focus_dt();
            MainCenter_pan.Controls.Clear();
            mnt.FOCUS_DT = m_focus_dt;

            MainCenter_pan.Controls.Add(mnt);
            mnt.SET_MONTH();
            mnt.Show();
        }

        // ---------- Week ----------

        private Week week = new Week();
        private void setCenterWeekPanel()
        { // 센터패널 설정 함수 (주간 폼 가져오기)

            m_focus_dt = mnt.Get_focus_dt();
            MainCenter_pan.Controls.Clear();
            week.FOCUS_DT = m_focus_dt;

            MainCenter_pan.Controls.Add(week);
            week.resetSchedual();
            week.Show();
        }

        // ---------- FUNCTION ----------

        private void Set_BS_ctr()
        {
            mnt.TopLevel = false;
            mnt.TopMost = true;
            mnt.Parent = this;
            mnt.Location = new Point(0, 0);

            week.TopLevel = false;
            week.TopMost = true;
            week.Parent = this;
            week.Location = new Point(0, 0);

            bs_leftTab.TopLevel = false;
            bs_leftTab.TopMost = true;
            bs_leftTab.Parent = this;
            bs_leftTab.Location = new Point(0, 0);

            fr_tab.TopLevel = false;
            fr_tab.TopMost = true;
            fr_tab.Parent = this;
            fr_tab.Location = new Point(0, 0);

        }

        private void Set_UserProfile()
        {
            // UserProfile_pro 초기 설정 함수
            UserProfile_prof.Set_Profile_Size(FontStyle.Bold);
            UserProfile_prof.Width = UserProfile_prof.USERPIC.Width + 5 + UserProfile_prof.USERNAME.Width;
            UserProfile_prof.Left = (MainUser_pan.Width - UserProfile_prof.Width) / 2;
            UserProfile_prof.Top = (MainUser_pan.Height - UserProfile_prof.Height) / 2;
        }

        private void Check_FriendRequest() // 메인이 실행 될때 친구신청 온게 있는지 확인 - CJE 
        {
            string command = "select * from FRIEND_TB where FR_FR_FK ='" + db.UR_CD + "' and FR_ACEP_ST = 0";
            db.ExecuteReader(command);
            if (db.Reader.Read())
            {
                if (MessageBox.Show("친구 신청이 왔습니다 확인 하시겠습나까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Friend_Check friendCheck = new Friend_Check();
                    friendCheck.ShowDialog();
                }
            }
            db.Reader.Close();
        }

        private void Check_GroupMem()
        {
            string sql = "select * from GROUP_MEMBER_TB";
            sql += " where GRMB_MBR_UR_FK = '" + db.UR_CD + "'";
            sql += " and GRMB_ACEP_ST = 0";
            db.ExecuteReader(sql);

            if (db.Reader.Read())
            {
                if (MessageBox.Show("그룹원 신청이 왔습니다 확인 하시겠습나까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GroupMember_Check GroupMem_check = new GroupMember_Check();
                    GroupMem_check.ShowDialog();
                }
            }
            db.Reader.Close();
            bs_leftTab.reset();
        }

        // ---------- EVENT ----------

        private Point fPt; // 폼 위치
        private bool isMove; // 마우스 눌림 상태

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
                    pic.Location = new Point(pic.Left - (fPt.X - e.X), pic.Top - (fPt.Y - e.Y));
                if (isShowToDo)
                    tdl.Location = new Point(tdl.Left - (fPt.X - e.X), tdl.Top - (fPt.Y - e.Y));
            }
        }

        private void MainHeader_menustp_MouseUp(object sender, MouseEventArgs e)
        {
            // 마무스 떼었을 때
            isMove = false; // 마우스 떼었을 때 움직이지 않도록
        }

        private void Main_Load(object sender, EventArgs e)
        {
            isShowPic = false; // 사진폼 띄우지않음
            isShowToDo = false; // 할일폼 띄우지않음

            m_Today_lbl.Text = sc_db.TODAY.ToString("yyyy.MM.dd"); // 오늘 날짜 설정
            mnt.FOCUS_DT = week.FOCUS_DT = m_focus_dt = sc_db.TODAY;

            setCenterMonthPanel(); // 월간보기로 기본설정
            setLeftBasicPanel(); // LeftTab으로 기본설정
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
            if (pic != null && pic.DialogResult == DialogResult.Cancel) // 자체적으로 X를눌러 폼을 종료했으면
                isShowPic = false;
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

        private void 일기쓰기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diary diary = new Diary();
            diary.ShowDialog();
        }

        private void 일정추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule modiSche = new Schedule(true);
            modiSche.ShowDialog();
            if(WeekForm_btn.Enabled == false)
                week.resetSchedual();
            mnt.SET_MONTH();
        }

        private void 최소화toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 할일모두완료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (db.GR_CD != null)
                db.ExecuteNonQuery("Update TODO_TB SET TD_COMP_ST = 1 WHERE TD_GR_FK = '" + db.GR_CD + "'");
            else
                db.ExecuteNonQuery("Update TODO_TB SET TD_COMP_ST = 1 WHERE TD_UR_FK = '" + db.UR_CD + "'");

            if (isShowToDo)
                tdl.reset();
        }

        private void 할일모두삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (db.GR_CD != null)
                db.ExecuteNonQuery("delete From TODO_TB WHERE TD_GR_FK = '" + db.GR_CD + "'");
            else
                db.ExecuteNonQuery("delete From TODO_TB WHERE TD_UR_FK = '" + db.UR_CD + "'");

            if (isShowToDo)
                tdl.reset();
        }

        private void 할일추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToDoList_Add tda = null;
            if (db.GR_CD != null)
                tda = new ToDoList_Add(db.GR_CD);
            else
                tda = new ToDoList_Add(db.UR_CD);

            tda.Location = Cursor.Position;

            if (tda.ShowDialog() == DialogResult.OK)
            {
                if (isShowToDo)
                    tdl.reset();
            }
        }

        ToDoList tdl = null;

        private void TodoForm_btn_Click(object sender, EventArgs e)
        {
            if (tdl != null && tdl.DialogResult == DialogResult.Cancel) // 자체적으로 X를눌러 폼을 종료했으면
                isShowToDo = false;
            if (isShowToDo) // 열려있으면
            {
                tdl.Close();
                tdl.Dispose();
                isShowToDo = false;

            }
            else // 닫혀있으면
            {
                tdl = new ToDoList();

                tdl.StartPosition = FormStartPosition.Manual; // 사진 폼 시작 포지션 설정
                tdl.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y); // 현재 폼의 X좌표+현재폼의 길이, 현재폼의 Y좌표

                tdl.Show();
                isShowToDo = true;
            }
        }
        private void FreindForm_btn_Click(object sender, EventArgs e)
        {
            db.FR_CD = null;
            FreindForm_btn.Visible = false;
            setLeftFriendPanel();
            LeftTabForm_btn.Visible = true;
            db.GR_CD = null;
            mnt.SET_MONTH();
        }

        private void LeftTabForm_btn_Click(object sender, EventArgs e)
        {
            LeftTabForm_btn.Visible = false;
            setLeftBasicPanel();
            FreindForm_btn.Visible = true;
            db.FR_CD = null;
            mnt.SET_MONTH();
        }

        private void 오늘일정보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Day day = new Day();
            day.StartPosition = FormStartPosition.CenterParent;
            day.FOCUS_DT = m_focus_dt;
            day.ShowDialog();
            mnt.SET_MONTH();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void 친구추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Friend_Add addfr = new Friend_Add();
            addfr.StartPosition = FormStartPosition.CenterParent;
            addfr.ShowDialog();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            Check_FriendRequest();
            Check_GroupMem();
        }


        private void 일기리스트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiaryList diaryList = new DiaryList();
            diaryList.ShowDialog();
        }

        private void 사진추가ToolStripMenuItem_Click(object sender, EventArgs e)
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

                    if (ps.ShowDialog() != DialogResult.OK)
                        return;
                    DateTime dt = ps.DT;

                    FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                    byte[] b = new byte[fs.Length - 1];
                    fs.Read(b, 0, b.Length);
                    fs.Close();

                    OracleParameter op = new OracleParameter();
                    op.ParameterName = ":BINARYFILE";
                    op.OracleDbType = Oracle.DataAccess.Client.OracleDbType.Blob;
                    op.Direction = ParameterDirection.Input;
                    op.Size = b.Length;
                    op.Value = b;
                    db.Command.CommandType = CommandType.Text;
                    db.Command.Parameters.Add(op); // 커맨드에 이 파라미터를 추가시켜서 db에 보낼때 같이 보낼수있게 함

                    int pbSc = MessageBox.Show("사진을 공개하시겠습니까?", "사진공개", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK ? 1 : 0;

                    if (db.GR_CD != null)
                        db.ExecuteNonQuery("insert into PICTURE_TB values('P'||SEQ_PICCD.nextval," + pbSc + ",'" + dt.ToString("yyyy-MM-dd") + "' , null,'" + db.GR_CD + "', :BINARYFILE)");
                    else
                        db.ExecuteNonQuery("insert into PICTURE_TB values('P'||SEQ_PICCD.nextval," + pbSc + ",'" + dt.ToString("yyyy-MM-dd") + "' , '" + db.UR_CD + "', null, :BINARYFILE)");
                    db.Command.Parameters.Remove(op); // 삭제를 꼭 시켜야한다 안하면 사진생성을 두번이상 실행안됨
                    MessageBox.Show("사진추가 되었습니다!", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (isShowPic)
                        pic.reset();

                }
                catch (Exception ec)
                {
                    MessageBox.Show("파일을 불러오는데 실패하였습니다\n" + ec.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void 친구그룹추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Friend_Group friendGroup = new Friend_Group();
            friendGroup.ShowDialog();

        }

        private void 사용자정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo ui = new UserInfo(db.UR_CD);
            ui.Location = Cursor.Position;
            ui.StartPosition = FormStartPosition.Manual;
            if (ui.ShowDialog() == DialogResult.OK)
            {
                db.AdapterOpen("select * from USER_TB where UR_CD = '" + db.UR_CD + "'");
                DataSet ds = new DataSet("USER_TB");
                db.Adapter.Fill(ds, "USER_TB");
                if (ds.Tables["USER_TB"].Rows[0][4].Equals(System.DBNull.Value))
                {
                    UserProfile_prof.USERPIC.Image = global::Shared_Calendar.Properties.Resources.user_null;
                    this.DialogResult = DialogResult.OK;
                    return;
                }

                Byte[] b = (Byte[])(ds.Tables["USER_TB"].Rows[0][4]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);
                UserProfile_prof.USERPIC.Image = img; // 프로퍼티로 PIC값 넘겨줌
                UserProfile_prof.USERNAME.Text = ui.ur_name;
                Set_UserProfile();
            }
        }

        private void 그룹추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group_Modify grpAdd = new Group_Modify();
            grpAdd.ShowDialog();
            bs_leftTab.reset();
        }
    }
}
