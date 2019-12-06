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
        private DBSchedule sch_db = new DBSchedule();

        public Month()
        {
            InitializeComponent();
            AutoScrollMinSize = new Size(int.MinValue, int.MinValue);
        }

        // 클릭 되어 있는 날짜 설정
        private int m_nowYear; // 현재 연도
        private int m_nowMonth; // 현재 월
        private int m_nowDay; // 현재 일자
        private int m_nowWeek; // 현재 요일

        private DateTime m_FirstDay; // 현재 월의 1일
        private int m_LastDay; // 현재 월의 마지막 날
        private int m_FirstWeek; // 현재 월의 1일 요일

        private void Set_Month_Today()
        {   
            // 오늘날짜(시스템날짜)에 맞게 월간 설정 함수
            DateTime m_today = DateTime.Now;

            m_nowYear = m_today.Year; // 현재 연도
            m_nowMonth = m_today.Month; // 현재 월
            m_nowDay = m_today.Day; // 현재 일자
            m_nowWeek = (int)m_today.DayOfWeek; // 현재 요일

            m_LastDay = DateTime.DaysInMonth(m_nowYear, m_nowMonth); // 현재 월의 마지막 날
            m_FirstDay = new DateTime(m_nowYear, m_nowMonth, 1);
            m_FirstWeek = (int)m_FirstDay.DayOfWeek; // 현재 월의 1일 요일

            m_Year_btn.Text = m_nowYear.ToString() + "년";
            m_MonthNum.Text = m_nowMonth.ToString();

            Set_Month_Days(m_LastDay, m_FirstWeek, m_FirstDay);
        }

        private void Set_Month_Days(int m_LastDay, int m_FirstWeek, DateTime m_day)
        {
            // 월의 모든 날짜 설정 함수
            System.Windows.Forms.Label label;
            for (int i = 1; i < m_LastDay+1; i++)
            {
                label = new System.Windows.Forms.Label(); // 레이블 동적 생성
                label.Location = new System.Drawing.Point(5, 5);
                label.Name = "Day" + i.ToString() + "_lbl";
                label.Size = new System.Drawing.Size(25, 15);
                label.Text = i.ToString();

                int DayPenel_nm = m_FirstWeek + i;
                if (DayPenel_nm % 7 == 0)
                {
                    label.ForeColor = Color.RoyalBlue;
                }
                else if ((DayPenel_nm-1) % 7 == 0)
                {
                    label.ForeColor = Color.Red;
                }

                // 날짜 추가

                string Panel_nm = "MonthDay" + DayPenel_nm.ToString() + "_panel"; // 해당 패널에 삽입
                Panel MonthPanel = (Panel)this.Controls.Find(Panel_nm, true)[0];
                MonthPanel.Controls.Add(label);

                // 일정 추가
                Set_Schedule(m_day.AddDays(i-1), MonthPanel);
            }

        }

        private void Set_Schedule(DateTime NowDay, Panel m_panel)
        {
            // 일정 표시 함수
            DataTable sc_day_tb = sch_db.Get_Day_Schedule(true, db.UR_CD, NowDay);
            DataRow[] rows = sc_day_tb.Select();
            int lbl_nm = (int)NowDay.Day; // 현재 일자

            System.Windows.Forms.Label label;
            for (int i = 0; i < rows.Length; i++)
            {
                label = new System.Windows.Forms.Label(); // 레이블 동적 생성
                label.Location = new System.Drawing.Point(0, 15*(i+1));
                label.Name = "day" + lbl_nm.ToString() + "_sc" + i.ToString();
                label.Size = new System.Drawing.Size(m_panel.Width, 30);
                label.Text = rows[i]["SC_NM"].ToString();

                m_panel.Controls.Add(label);
            }

        }

    private void Month_Load(object sender, EventArgs e)
        {
            Set_Month_Today(); // 오늘 날짜 세팅
        }
    }
}
