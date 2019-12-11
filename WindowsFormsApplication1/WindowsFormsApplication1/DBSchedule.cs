using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class DBSchedule
    {

        public DBSchedule()
        {
            // DBSchedule 생성자
            db.ExecuteReader("select SYSDATE from dual"); // 오라클 서버 시간 가져오기
            db.Reader.Read();
            s_today = db.Reader.GetDateTime(0);
        }

        DBConnection db = Program.DB;
        private string sql;
        private DataSet DS;

        private static DateTime s_today; // 오늘 시간
        public DateTime TODAY
        {
            get { return s_today; }
        }

        // DB상 Schedule 가져오기 클래스

        public DataTable Get_Schedule(Boolean is_UR, string m_URorGR_CD)
        {
            // 해당 사용자에 대한 모든 일정 테이블 함수
            if (is_UR == true) // 회원이라면
            {
                sql = "select * from SCHEDULE_TB where SC_UR_FK = '" + m_URorGR_CD + "'";
            }
            else // 그룹이라면
            {
                sql = "select * from SCHEDULE_TB where SC_GR_FK = '" + m_URorGR_CD + "'";
            }
            sql += " order by SC_STR_DT ASC";

            DS = new DataSet();
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "GET_SC_TB");

            DataTable GET_SC_TB = new DataTable();
            GET_SC_TB = DS.Tables["GET_SC_TB"];

            return GET_SC_TB;
        }
        
        public DataTable Get_Day_Schedule(Boolean is_UR, string m_URorGR_CD, DateTime day)
        {
            // 해당 날짜에 대한 해당 사용자의 일정 테이블 함수
            if (is_UR == true) // 회원이라면
            {
                sql = "select * from SCHEDULE_TB where SC_UR_FK = '" + m_URorGR_CD + "'";
            }
            else // 그룹이라면
            {
                sql = "select * from SCHEDULE_TB where SC_GR_FK = '" + m_URorGR_CD + "'";
            }
            sql += " and SC_STR_DT >= '" + day.ToString("yyyy-MM-dd") + "'";
            sql += " and SC_STR_DT < '" + day.AddDays(1).ToString("yyyy-MM-dd") + "'";
            sql += " order by SC_STR_DT ASC";

            DS = new DataSet();
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "GET_DAY_SC_TB");

            DataTable GET_DAY_SC_TB = new DataTable();
            GET_DAY_SC_TB = DS.Tables["GET_DAY_SC_TB"];

            return GET_DAY_SC_TB;
        }

        public DataTable Get_Week_Schedule(Boolean is_UR, string m_URorGR_CD, DateTime day, int turm) // day + turm
        {
            // 해당 날짜에 대한 해당 사용자의 일정 테이블 함수
            if (is_UR == true) // 회원이라면
            {
                sql = "select * from SCHEDULE_TB where SC_UR_FK = '" + m_URorGR_CD + "'";
            }
            else // 그룹이라면
            {
                sql = "select * from SCHEDULE_TB where SC_GR_FK = '" + m_URorGR_CD + "'";
            }
            sql += " and SC_END_DT > '" + day.ToString("yyyy-MM-dd") + "'";
            sql += " and SC_STR_DT < '" + day.AddDays(turm).ToString("yyyy-MM-dd") + "'";
            sql += " order by  SC_STR_DT ASC"; // 일주일 범위 안에 들어오면 무조건

            DS = new DataSet();
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "GET_DAY_SC_TB");

            DataTable GET_DAY_SC_TB = new DataTable();
            GET_DAY_SC_TB = DS.Tables["GET_DAY_SC_TB"];

            return GET_DAY_SC_TB;
        }

        public void Insert_Schedule(Boolean is_UR, string m_URorGR_CD, string title, string ex, int st, DateTime st_day, DateTime end_day, string p_fk , string cr_fk)
        {
            // Insert_Schedule(사용자/그룹구분, 사용자/그룹 코드, 일정제목, 일정내용, 공개상태, 시작일시, 종료일시, 사진fk, 컬러fk)

            string st_day_str = st_day.ToString("yyyy/MM/dd H:mm"); // 시작일시 스트링 포맷
            string end_day_str = end_day.ToString("yyyy/MM/dd H:mm"); // 시작일시 스트링 포맷

            sql = "insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL), '" + title + "', ";

            if (ex == null) { sql += "null, "; } // 일정설명
            else { sql += "'" + ex + "', "; }

            sql += st.ToString() + ", to_date('" + st_day_str + "', 'yyyy/MM/dd hh24:mi'), to_date('" + end_day_str + "', 'yyyy/MM/dd hh24:mi'), ";

            if (p_fk == null) { sql += "null, "; } // 사진코드
            else { sql += "'" + p_fk + "', "; }
            if (cr_fk == null) { sql += "null, "; } // 컬러코드
            else { sql += "'" + cr_fk + "', "; }
            if (is_UR == true){sql += "'" + m_URorGR_CD + "', null)";} // 회원일시
            else {sql += "null, '" + m_URorGR_CD + "')";} // 그룹일시

            db.ExecuteNonQuery(sql);
        }

        public void Delete_Schedule(string sc_cd)
        {
            // Delete_Schedule(스케줄코드)
            sql = "delete from SCHEDULE_TB where SC_CD = '" + sc_cd + "'";
            db.ExecuteNonQuery(sql);
        }

        public void Update_Schedule(string sc_cd, string column_name, string sc_data)
        {
            // Update_Schedule(스케줄코드, 업데이트될 컬럼명, 업데이트 데이터)
            sql = "update SCHEDULE_TB set " + column_name + " = '" + sc_data + "' where SC_CD = '" + sc_cd + "'";
            db.ExecuteNonQuery(sql);
        }

        public void Update_Schedule(string sc_cd, string column_name, DateTime sc_data)
        {
            // Update_Schedule overloading - 시작일시, 종료일시 업데이트
            // Update_Schedule(스케줄코드, 업데이트될 컬럼명, 업데이트 데이터)
            string sc_data_str = sc_data.ToString("yyyy/MM/dd H:mm");
            sql = "update SCHEDULE_TB set " + column_name + " = to_date('" + sc_data + "', 'yyyy/MM/dd hh24:mi') where SC_CD = '" + sc_cd + "'";
            db.ExecuteNonQuery(sql);
        }
    }
}
