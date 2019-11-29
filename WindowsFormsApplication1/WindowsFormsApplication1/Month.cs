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

        private int m_LastDay; // 현재 월의 마지막 날
        private int m_FirstWeek; // 현재 월의 1일 요일

        private void Set_Month_Today()
        {   
            // 오늘날짜(시스템날짜)에 맞게 월간 설정 함수
            DateTime m_today = DateTime.Now;

            m_nowYear = (int)m_today.Year; // 현재 연도
            m_nowMonth = (int)m_today.Month; // 현재 월
            m_nowDay = (int)m_today.Day; // 현재 일자
            m_nowWeek = (int)m_today.DayOfWeek; // 현재 요일

            m_LastDay = (int)DateTime.DaysInMonth(m_nowYear, m_nowMonth); // 현재 월의 마지막 날
            m_FirstWeek = (int)new DateTime(m_nowYear, m_nowMonth, 1).DayOfWeek; // 현재 월의 1일 요일

            m_Year_btn.Text = m_nowYear.ToString() + "년";
            m_MonthNum.Text = m_nowMonth.ToString();

            Set_Month_Days(m_LastDay, m_FirstWeek);
        }

        private void Set_Month_Days(int m_LastDay, int m_FirstWeek)
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

                // 일정 추가

                string Panel_nm = "MonthDay" + DayPenel_nm.ToString() + "_panel"; // 해당 패널에 삽입
                Panel MonthPanel = (Panel)this.Controls.Find(Panel_nm, true)[0];
                MonthPanel.Controls.Add(label);
            }

        }

        private void Set_Schedule(int NowDay)
        {
            // 일정 표시 함수
            string sql = "select * from SCHEDULE_TB";
            sql += " where SC_UR_FK = 'U100000'"; //+ db.UR_CD;
            sql += " and SC_STR_DT >= '2019-11-13'";
            sql += " and SC_STR_DT < '2019-11-14'";

            db.ExecuteReader(sql);

            System.Windows.Forms.Label label;
            if(db.Reader.Read())
            {
                label = new System.Windows.Forms.Label(); // 레이블 동적 생성
                label.Location = new System.Drawing.Point(50, 50);
                label.Name = "test_lbl";
                label.Size = new System.Drawing.Size(50, 20);
                label.Text = db.Reader["SC_NM"].ToString();

                MonthDay1_panel.Controls.Add(label);
            }

        }

    private void Month_Load(object sender, EventArgs e)
        {
            Set_Month_Today(); // 오늘 날짜 세팅
            Set_Schedule(1);
        }
    }
}
