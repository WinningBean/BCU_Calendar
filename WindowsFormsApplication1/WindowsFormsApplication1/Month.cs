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
    public partial class Month : Form
    {
        private DBConnection db = Program.DB;
        private DBSchedule sc_db = new DBSchedule();
        private DBColor cr_db = new DBColor();

        private DateTime m_focus_dt; // 현재 포커스 날짜
        public DateTime FOCUS_DT { // 현재 포커스날짜 프로퍼티
            set { m_focus_dt = value; }
        }
        public DateTime Get_focus_dt() { return m_focus_dt; }

        public Month()
        {
            InitializeComponent();
            AutoScrollMinSize = new Size(int.MinValue, int.MinValue);

            Set_bs_Control();
        }

        private void Set_bs_Control() {
            for (int i = 1; i < 7; i++)
            {
                string w_Panel_nm = "Week" + i.ToString() + "_panel";
                Panel WeekPanel = (Panel)this.Controls.Find(w_Panel_nm, true)[0];
                WeekPanel.VerticalScroll.Minimum = 0;
                WeekPanel.VerticalScroll.Maximum = 0;
                WeekPanel.VerticalScroll.Visible = false;
                WeekPanel.HorizontalScroll.Minimum = 0;
                WeekPanel.HorizontalScroll.Maximum = 0;
                WeekPanel.HorizontalScroll.Visible = false;
                WeekPanel.AutoSize = false;
                WeekPanel.AutoScroll = true;

                WeekPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Week_panel_MouseClick);
                for (int j = 1; j < 8; j++)
                {
                    string m_Panel_nm = "MonthDay" + ((i - 1) * 7 + j).ToString() + "_panel";
                    Panel MonthPanel = (Panel)this.Controls.Find(m_Panel_nm, true)[0];
                    MonthPanel.Click += new System.EventHandler(this.dm_pan_Click);
                }
            }
        }

        private void clear_lbl_cr() {
            for (int i = 1; i < 43; i++)
            {
                string Panel_nm = "MonthDay" + i.ToString() + "_panel"; // 해당 패널에 삽입
                Panel MonthPanel = (Panel)this.Controls.Find(Panel_nm, true)[0];
                if (MonthPanel.Controls.Count > 0)
                {
                    MonthPanel.Controls[0].BackColor = Color.Transparent;
                }
            }
        }

        private Label Add_SC_btn; // 일정추가 버튼
        private void Set_Add_SC_btn() { // 일정 추가 폼 동적 생성
            Add_SC_btn = new System.Windows.Forms.Label(); // 일정 추가 버튼
            Add_SC_btn.Location = new System.Drawing.Point(109, 2);
            Add_SC_btn.Name = "Add_SC_btn";
            Add_SC_btn.Size = new System.Drawing.Size(21, 21);
            Add_SC_btn.Text = "+";
            Add_SC_btn.TextAlign = ContentAlignment.MiddleCenter;
            Add_SC_btn.BackColor = Color.WhiteSmoke;
            Add_SC_btn.Cursor = Cursors.Hand;

            var btn_path = new System.Drawing.Drawing2D.GraphicsPath();
            btn_path.AddEllipse(0, 0, Add_SC_btn.Width, Add_SC_btn.Height);
            Add_SC_btn.Region = new Region(btn_path);

            Add_SC_btn.Click += new System.EventHandler(this.Add_SC_btn_Click);
        }

        private void set_pass_Month(Panel fc_pan, int fc_pan_n)
        {
            if (fc_pan.Controls.Count > 0)
            {
                clear_lbl_cr();
                m_focus_dt = new DateTime(m_nowYear, m_nowMonth, Convert.ToInt32(fc_pan.Controls[0].Text));
                fc_pan.Controls[0].BackColor = Color.Gainsboro;
            }
            else
            {
                if (fc_pan_n < 8) // 저번달 해당 패널을 눌렀다면 강제 이벤트 호출
                {
                    LastMonth_btn.PerformClick();
                    if (LastWeek_btn.Visible == true) // 6주치 월이라면
                    {
                        MonthSC_pan.Location = new Point(0, -78);
                        LastWeek_btn.Visible = false;
                        FirstWeek_btn.Visible = true;
                        fc_pan = (Panel)this.Controls.Find("MonthDay" + (fc_pan_n + 35).ToString() + "_panel", true)[0]; // 해당월의 마지막 주
                    }
                    else fc_pan = (Panel)this.Controls.Find("MonthDay" + (fc_pan_n + 28).ToString() + "_panel", true)[0]; // 해당월의 마지막 주
                }
                else if (fc_pan_n > 28) // 다음달 해당 패널을 눌렀다면 강제 이벤트 호출
                {
                    if (FirstWeek_btn.Visible == true) // 6주치 월이라면
                    {
                        MonthSC_pan.Location = new Point(0, -78);
                        FirstWeek_btn.Visible = false;
                        LastWeek_btn.Visible = true;
                        fc_pan = (Panel)this.Controls.Find("MonthDay" + (fc_pan_n - 35).ToString() + "_panel", true)[0]; // 해당월의 첫째 주
                    }
                    else fc_pan = (Panel)this.Controls.Find("MonthDay" + (fc_pan_n - 28).ToString() + "_panel", true)[0]; // 해당월의 첫째 주
                    NextMonth_btn.PerformClick();
                }
                clear_lbl_cr();
                m_focus_dt = new DateTime(m_nowYear, m_nowMonth, Convert.ToInt32(fc_pan.Controls[0].Text));
                fc_pan.Controls[0].BackColor = Color.Gainsboro;
            }

            if (db.FR_CD == null)
            {
                ((Label)this.Controls.Find("Add_SC_btn", true)[0]).Dispose();
                Add_SC_btn.Dispose();
                Set_Add_SC_btn();
                fc_pan.Controls.Add(Add_SC_btn);
            }
        }

        private void Week_panel_MouseClick(object sender, MouseEventArgs e)
        {
            int dt_x = e.X / 135 + 1;
            int dt_y = (((Panel)sender).Location.Y - 25) / 100;
            int fc_pan_n = dt_x + (dt_y * 7);

            Panel fc_pan = (Panel)this.Controls.Find("MonthDay" + fc_pan_n.ToString() + "_panel", true)[0];
            set_pass_Month(fc_pan, fc_pan_n);
        }

        private void dm_pan_Click(object sender, EventArgs e) // 일정 패널 클릭시 이벤트 처리
        {
            int fc_pan_n = Convert.ToInt32(((Panel)sender).Name.Substring(8, ((Panel)sender).Name.Length - 6 - 8));

            set_pass_Month((Panel)sender, fc_pan_n);
        }

        private void dm_sc_Click(object sender, EventArgs e)// 일정 클릭시 이벤트 처리
        {
            int dt_x = ((Label)sender).Location.X / 135 + 1;
            int dt_y = (((Panel)((Label)sender).Parent).Location.Y - 25) / 100;
            int fc_pan_n = dt_x + (dt_y * 7);

            Panel fc_pan = (Panel)this.Controls.Find("MonthDay" + fc_pan_n.ToString() + "_panel", true)[0];
            set_pass_Month(fc_pan, fc_pan_n);

            bool grp_modi_possible = false;

            if (db.GR_CD != null)
            {
                string sql = "select UR_CD from USER_TB where UR_CD = (";
                sql += "select SC_UR_FK from SCHEDULE_TB";
                sql += " where SC_CD = '" + ((Label)sender).Tag.ToString() + "'";
                sql += ") or UR_CD = (";
                sql += "select GR_MST_UR_FK from GROUP_TB";
                sql += " where GR_CD = '" + db.GR_CD + "')";
                db.ExecuteReader(sql);
                while (db.Reader.Read())
                {
                    if (db.UR_CD == db.Reader.GetString(0))
                    {
                        grp_modi_possible = true;
                        break;
                    }
                }
            }

            if (db.FR_CD == null || grp_modi_possible)
            {
                Schedule_Modify modiSche = new Schedule_Modify(((Label)sender).Tag.ToString()); // 일정 수정 폼 띄우기
                int f_loX = (this.Parent.Parent.Location.X + 243 + this.Width / 2) - modiSche.Width / 2;
                int f_loY = (this.Parent.Parent.Location.Y + 92 + this.Height / 2) - modiSche.Height / 2;
                modiSche.Location = new Point(f_loX, f_loY);
                modiSche.ShowDialog();

                Set_Month_Today();
            }
        }

        private Day day = new Day(); // 일간 폼 띄우기
        private void dm_dt_Click(object sender, EventArgs e)// 날짜 클릭시 이벤트 처리
        {
            clear_lbl_cr();
            ((Label)sender).BackColor = Color.Gainsboro;
            m_focus_dt = new DateTime(m_nowYear, m_nowMonth, Convert.ToInt32(((Label)sender).Text.ToString()));
            Panel fc_pan = (Panel)((Label)sender).Parent;

            if (db.FR_CD == null)
            {
                ((Label)this.Controls.Find("Add_SC_btn", true)[0]).Dispose();
                Add_SC_btn.Dispose();
                Set_Add_SC_btn();
                fc_pan.Controls.Add(Add_SC_btn);
            }

            int f_loX = (this.Parent.Parent.Location.X + 243 + this.Width / 2) - day.Width / 2;
            int f_loY = (this.Parent.Parent.Location.Y + 92 + this.Height / 2) - day.Height / 2;
            day.Location = new Point(f_loX, f_loY);
            day.FOCUS_DT = m_focus_dt;
            day.ShowDialog();

            m_focus_dt = day.Get_focus_dt();
            Set_Month_Today();
        }
        
        // 클릭 되어 있는 날짜 설정
        private int m_nowYear; // 현재 연도
        private int m_nowMonth; // 현재 월
        private int m_nowDay; // 현재 일자
        private int m_nowWeek; // 현재 요일

        private DateTime m_FirstDay; // 현재 월의 1일
        private int m_LastDay; // 현재 월의 마지막 날
        private int m_FirstWeek; // 현재 월의 1일 요일

        public void SET_MONTH() { Set_Month_Today(); } // 다른 폼에서 Set_Month_Today(); 부르고 싶을 때

        private void Set_Month_Today()
        {
            // 오늘날짜(시스템날짜)에 맞게 월간 설정 함수
            clear_lbl_cr();

            for (int i = 1; i < 7; i++)
            {
                string w_Panel_nm = "Week" + i.ToString() + "_panel";
                Panel WeekPanel = (Panel)this.Controls.Find(w_Panel_nm, true)[0];
                WeekPanel.Controls.Clear();
                for (int j = 1; j < 8; j++)
                {
                    string m_Panel_nm = "MonthDay" + ((i - 1) * 7 + j).ToString() + "_panel";
                    Panel MonthPanel = (Panel)this.Controls.Find(m_Panel_nm, true)[0];
                    MonthPanel.Controls.Clear();
                }
            }

            m_nowYear = m_focus_dt.Year; // 현재 연도
            m_nowMonth = m_focus_dt.Month; // 현재 월
            m_nowDay = m_focus_dt.Day; // 현재 일자
            m_nowWeek = (int)m_focus_dt.DayOfWeek; // 현재 요일

            m_LastDay = DateTime.DaysInMonth(m_nowYear, m_nowMonth); // 현재 월의 마지막 날
            m_FirstDay = new DateTime(m_nowYear, m_nowMonth, 1);
            m_FirstWeek = (int)m_FirstDay.DayOfWeek; // 현재 월의 1일 요일

            m_Year_txt.Text = m_nowYear.ToString();
            m_MonthNum.Text = m_nowMonth.ToString();

            Set_Month_Days();
        }
        
        private Label Day_n_lbl; // 날짜 레이블
        private void Set_Month_Days()
        {
            LastWeek_btn.Visible = false;
            FirstWeek_btn.Visible = false;
            MonthSC_pan.Location = new Point(0,22);
            // 월의 모든 날짜 설정 함수
            for (int i = 1; i < m_LastDay + 1; i++)
            {
                int DayPenel_num = m_FirstWeek + i;
                string Panel_nm = "MonthDay" + DayPenel_num.ToString() + "_panel"; // 해당 패널에 삽입
                Panel MonthPanel = (Panel)this.Controls.Find(Panel_nm, true)[0];

                if (DayPenel_num > 35) LastWeek_btn.Visible = true;

                Day_n_lbl = new System.Windows.Forms.Label(); // 날짜 레이블 동적 생성
                Day_n_lbl.Location = new System.Drawing.Point(5, 1);
                Day_n_lbl.Name = "Day" + i.ToString() + "_lbl";
                Day_n_lbl.Size = new System.Drawing.Size(23, 23);
                Day_n_lbl.Text = i.ToString();
                Day_n_lbl.TextAlign = ContentAlignment.MiddleCenter;
                Day_n_lbl.Cursor = Cursors.Hand;

                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, Day_n_lbl.Width, Day_n_lbl.Height);
                Day_n_lbl.Region = new Region(path);

                Day_n_lbl.Click += new System.EventHandler(this.dm_dt_Click);

                if (DayPenel_num % 7 == 0)
                {
                    Day_n_lbl.ForeColor = Color.RoyalBlue;
                }
                else if ((DayPenel_num - 1) % 7 == 0)
                {
                    Day_n_lbl.ForeColor = Color.Red;
                }

                // 날짜 추가
                MonthPanel.Controls.Add(Day_n_lbl);
                if (i == m_nowDay)
                {
                    Day_n_lbl.BackColor = Color.Gainsboro;
                    if (db.FR_CD == null)
                    {
                        Set_Add_SC_btn();
                        MonthPanel.Controls.Add(Add_SC_btn);
                    }
                }

                // 베이스 일정
                Get_bsWeek(m_FirstDay.AddDays(i - 1), DayPenel_num);
            }

        }

        private void Get_bsWeek(DateTime NowDay, int DayPenel_num)
        {
            // base 일정, 위크패널 구하기 함수
            int now_loX = 135 * ((DayPenel_num % 7) - 1); // 현재 X좌표
            if (now_loX == -135) now_loX = 810;

            int w_n; // 위크패널 넘버
            switch ((DayPenel_num - 1) / 7)
            {
                case 0:
                    w_n = 1;
                    break;
                case 1:
                    w_n = 2;
                    break;
                case 2:
                    w_n = 3;
                    break;
                case 3:
                    w_n = 4;
                    break;
                default:
                    w_n = 5;
                    break;
            }

            string Panel_nm = "Week" + w_n.ToString() + "_panel"; // 해당 패널에 삽입
            Panel WeekPanel = (Panel)this.Controls.Find(Panel_nm, true)[0];
            List<int> bs_lo = new List<int>(); // 비어있는 로케이션 리스트
            
            int lastY = 0;
            List<int> nowSc_Y_lst = new List<int>(); // 현재 Y좌표 레이블
            
            for (int i = 0; i < WeekPanel.Controls.Count; i++)
            {
                if (WeekPanel.Controls[i].Location.X == now_loX) // 현재 X로케이션에 존재하는 레이블만
                {
                    nowSc_Y_lst.Add(WeekPanel.Controls[i].Location.Y);
                    lastY = WeekPanel.Controls[i].Location.Y + 25;
                    //bs_sc++;
                }
            }

            if (nowSc_Y_lst.Count > 0)
            {
                int lst_cnt = 0;
                for (int i = 0; i < lastY; i += 25)
                {
                    if (i != nowSc_Y_lst[lst_cnt]) bs_lo.Add(i);
                    else lst_cnt++;
                }
                if (lst_cnt == 1 && nowSc_Y_lst[0] == 0 && bs_lo.Count == 0) bs_lo.Add(25);
            }
            // 일정 추가
            Set_Schedule(NowDay, WeekPanel, bs_lo, now_loX);
        }

        private void Set_Schedule(DateTime NowDay, Panel WeekPanel, List<int> bs_lo, int now_loX)
        {
            // 일정 표시 함수
            DataTable sc_day_tb;
            if (NowDay.Day == 1) {
                if (db.FR_CD != null) // 친구 코드가 있다면 친구 일정 보여주기
                {
                    sc_day_tb = sc_db.Get_DayAll_Schedule(true, db.FR_CD, NowDay, 1); ; // 친구일정은 공개일정만
                }
                else if (db.GR_CD != null) // 그룹 코드가 있다면 그룹 일정 보여주기
                {
                    sc_day_tb = sc_db.Get_DayAll_Schedule(false, db.GR_CD, NowDay, 1); // 그룹일정은 공개일정만
                }
                else // 사용자의 일정 보여주기
                {
                    sc_day_tb = sc_db.Get_DayAll_Schedule(true, db.UR_CD, NowDay, db.IS_PB);
                }
            }
            else
            {
                if (db.FR_CD != null) // 친구 코드가 있다면 친구 일정 보여주기
                {
                    sc_day_tb = sc_db.Get_Day_Schedule(true, db.FR_CD, NowDay, 1); // 친구일정은 공개일정만
                }
                else if (db.GR_CD != null) // 그룹 코드가 있다면 그룹 일정 보여주기
                {
                    sc_day_tb = sc_db.Get_Day_Schedule(false, db.GR_CD, NowDay, 1); // 그룹일정은 공개일정만
                }
                else // 사용자의 일정 보여주기
                {
                    sc_day_tb = sc_db.Get_Day_Schedule(true, db.UR_CD, NowDay, db.IS_PB);
                }
            }
            
            DataRow[] rows = sc_day_tb.Select();
            int lbl_nm = (int)NowDay.Day; // 현재 일자
            int lo_y = -25; // 이어지는 일정 뒤의 로케이션
            int bs_sc = 0;

            System.Windows.Forms.Label label;
            for (int i = 0; i < rows.Length; i++)
            { 

                label = new System.Windows.Forms.Label(); // 레이블 동적 생성
                label.Name = "sc" + lbl_nm.ToString() + "_lbl" + (i+1).ToString();
                label.Size = new System.Drawing.Size(135, 25);
                label.Padding = new Padding(5, 0, 5, 0);
                label.Text = rows[i]["SC_NM"].ToString();
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Tag = rows[i]["SC_CD"].ToString();

                label.Click += new System.EventHandler(this.dm_sc_Click);

                if (bs_lo.Count > i) lo_y = bs_lo[i];
                else lo_y += 25;
                label.Location = new System.Drawing.Point(now_loX, lo_y); // 이어지는 일정 밑에 삽입

                Color sc_cr_bs; // 일정의 SC_CR_FK - 베이스컬러
                Color sc_cr_ft; // 일정의 SC_CR_FK - 글자컬러

                if (rows[i]["SC_CR_FK"] != DBNull.Value) // CR_FK이 있다면 해당 컬러 설정
                {
                    sc_cr_bs = cr_db.GetColorInsertCRCD(rows[i]["SC_CR_FK"].ToString());
                    sc_cr_ft = Color.Black;
                }
                else // CR_FR이 없다면 기본 컬러 설정
                {
                    sc_cr_bs = Color.Gainsboro;
                    sc_cr_ft = Color.Black;
                }

                if (lbl_nm < Convert.ToDateTime(rows[i]["SC_END_DT"]).Day || Convert.ToDateTime(rows[i]["SC_STR_DT"]).Month < Convert.ToDateTime(rows[i]["SC_END_DT"]).Month) // 하루종일 이상의 일정이라면 백컬러 지정
                {
                    TimeSpan df_time = Convert.ToDateTime(rows[i]["SC_END_DT"]) - Convert.ToDateTime(rows[i]["SC_STR_DT"]);
                    if (df_time.Days == 0)
                    {
                        if (Convert.ToDateTime(rows[i]["SC_STR_DT"]).Month < Convert.ToDateTime(rows[i]["SC_END_DT"]).Month)
                        {
                            label.BackColor = sc_cr_bs;
                            label.ForeColor = Color.Black;
                        }
                        else
                        {
                            label.BackColor = Color.Transparent;
                            label.ForeColor = sc_cr_bs;
                        }
                    }
                    else
                    {
                        label.BackColor = sc_cr_bs;
                        label.ForeColor = Color.Black;
                        df_time = Convert.ToDateTime(rows[i]["SC_END_DT"]) - NowDay;
                        bs_sc++;
                        Add_Set_Schedule(label.Tag.ToString(), NowDay.Day, df_time, WeekPanel, lbl_nm, now_loX, lo_y, bs_sc, sc_cr_bs);
                    }
                }
                else
                {
                    label.BackColor = Color.Transparent;
                    label.ForeColor = sc_cr_bs;
                }

                WeekPanel.Controls.Add(label); // 패널에 레이블 추가
            }
            
        }

        private void Add_Set_Schedule(string SC_CD, int NowDay, TimeSpan df_time, Panel WeekPanel, int lbl_nm, int now_loX, int lo_y, int bs_sc, Color sc_cr_bs)
        {
            int add_lbl_now = 0;

            if (df_time.Hours > 0 || df_time.Days > 1) // 다음날까지 이어지는 일정이라면 다음 패널에도 레이블 추가
            {
                if (df_time.Hours > 0) { df_time = df_time.Add(TimeSpan.FromDays(1)); } // 시간이 넘는다면 패널을 하나 더 생성

                int add_loX = now_loX;
                for (int j = 1; j < df_time.Days; j++) // 차이나는 일자만큼 해당 패널에 추가레이블 생성
                {
                    if (m_LastDay - NowDay < j) return;

                    int add_day = lbl_nm + j;

                    int add_w_n = ((add_day - 1) / 7) + 1;
                    string add_wpan_nm = "Week" + add_w_n.ToString() + "_panel";
                    Panel add_wpan = (Panel)this.Controls.Find(add_wpan_nm, true)[0];

                    add_loX += 135;
                    if (WeekPanel.Name != add_wpan.Name)
                    {
                        add_loX = 135 * ((add_day % 7) - 1);
                        if (add_loX == -135) add_loX = 810;
                    }

                    if (j == 1) add_lbl_now += 1;
                    System.Windows.Forms.Label add_label;
                    add_label = new System.Windows.Forms.Label();
                    add_label.Location = new System.Drawing.Point(add_loX, lo_y);
                    add_label.Name = "add_sc" + add_day.ToString() + "_lbl" + (bs_sc).ToString();
                    add_label.Size = new System.Drawing.Size(135, 25);
                    add_label.BackColor = sc_cr_bs;
                    add_label.Tag = SC_CD;

                    add_label.Click += new System.EventHandler(this.dm_sc_Click);

                    add_wpan.Controls.Add(add_label);
                }
            }
        }

        private void LastMonth_btn_Click(object sender, EventArgs e) // 전 달 보기
        {
            m_focus_dt = m_focus_dt.AddMonths(-1);
            Set_Month_Today();
        }

        private void NextMonth_btn_Click(object sender, EventArgs e) // 후 달 보기
        {
            m_focus_dt = m_focus_dt.AddMonths(1);
            Set_Month_Today();
        }
        
        private void TodayBtn_Click(object sender, EventArgs e)
        {
            m_focus_dt = sc_db.TODAY;
            Set_Month_Today();
        }

        private void m_Year_txt_TextChanged(object sender, EventArgs e)
        {
            int df_year = Convert.ToInt32(m_Year_txt.Text) - m_focus_dt.Year;
            m_focus_dt = m_focus_dt.AddYears(df_year);
            Set_Month_Today();
        }

        private void LastWeek_btn_Click(object sender, EventArgs e)
        {
            MonthSC_pan.Location = new Point(0, -78);
            LastWeek_btn.Visible = false;
            FirstWeek_btn.Visible = true;
        }

        private void FirstWeek_btn_Click(object sender, EventArgs e)
        {
            MonthSC_pan.Location = new Point(0, 22);
            FirstWeek_btn.Visible = false;
            LastWeek_btn.Visible = true;
        }

        private void Add_SC_btn_Click(object sender, EventArgs e)// 일정 클릭시 이벤트 처리
        {
            Schedule_Modify modiSche = new Schedule_Modify(); // 일정 추가 폼 띄우기
            int f_loX = (this.Parent.Parent.Location.X + 243 + this.Width / 2) - modiSche.Width / 2;
            int f_loY = (this.Parent.Parent.Location.Y + 92 + this.Height / 2) - modiSche.Height / 2;
            modiSche.Location = new Point(f_loX, f_loY);
            modiSche.FOCUS_DT = m_focus_dt;
            modiSche.ShowDialog();
            m_focus_dt = modiSche.StrDate;

            Set_Month_Today();
        }

        private void Month_Load(object sender, EventArgs e)
        {
            Set_Month_Today();
        }
    }
}
