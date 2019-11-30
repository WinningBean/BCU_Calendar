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
        }

        DBConnection db = Program.DB;
        private string sql;
        private DataSet DS = new DataSet();

        // DB상 Schedule 가져오기 클래스

        public DataTable Get_Schedule(string UrOrGr, string m_URorGR_CD)
        {
            // 해당 사용자에 대한 모든 일정 테이블 함수
            if (UrOrGr == "U") // 회원이라면
            {
                sql = "select * from SCHEDULE_TB where SC_UR_FK = '" + m_URorGR_CD + "'";
            }
            else if(UrOrGr == "G") // 그룹이라면
            {
                sql = "select * from SCHEDULE_TB where SC_GR_FK = '" + m_URorGR_CD + "'";
            }
            
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "GET_SC_TB");

            DataTable GET_SC_TB = new DataTable();
            GET_SC_TB = DS.Tables["GET_SC_TB"];

            return GET_SC_TB;
        }
        
        public DataTable Get_Day_Schedule(string UrOrGr, string m_URorGR_CD, DateTime day)
        {
            // 해당 날짜에 대한 해당 사용자의 일정 테이블 함수
            if (UrOrGr == "U") // 회원이라면
            {
                sql = "select * from SCHEDULE_TB where SC_UR_FK = '" + m_URorGR_CD + "'";
            }
            else if (UrOrGr == "G") // 그룹이라면
            {
                sql = "select * from SCHEDULE_TB where SC_GR_FK = '" + m_URorGR_CD + "'";
            }
            sql += " and SC_STR_DT >= '" + day.ToString("yyyy-MM-dd") + "'";
            sql += " and SC_STR_DT < '" + day.AddDays(1).ToString("yyyy-MM-dd") + "'";
            
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "GET_DAY_SC_TB");

            DataTable GET_DAY_SC_TB = new DataTable();
            GET_DAY_SC_TB = DS.Tables["GET_DAY_SC_TB"];

            return GET_DAY_SC_TB;
        }
    }
}
