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
        private DataTable USER_SC_TB = new DataTable();
        // DB상 Schedule 가져오기 클래스

        public DataTable Get_User_Schedule(string m_UR_CD)
        {
            // 해당 사용자에 대한 모든 일정 테이블 함수
            sql = "select * from SCHEDULE_TB where SC_UR_FK = '" + m_UR_CD + "'";
            
            //db.Command.CommandText = sql;
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "USER_SC_TB");

            USER_SC_TB = DS.Tables["USER_SC_TB"];

            return USER_SC_TB;
        }

        public DataTable Get_Day_Schedule(string m_UR_CD, DateTime day) {
            // 해당 날짜에 대한 해당 사용자의 일정 테이블 함수
            sql = "select * from SCHEDULE_TB where SC_UR_FK = '" + m_UR_CD + "'";
            sql += " and SC_STR_DT >= '" + day.ToString("yyyy-MM-dd") + "'";
            sql += " and SC_STR_DT < '" + day.AddDays(1).ToString("yyyy-MM-dd") + "'";
            //db.Command.CommandText = sql;
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "USER_SC_DAY_TB");

            USER_SC_TB = DS.Tables["USER_SC_DAY_TB"];

            return USER_SC_TB;
        }
    }
}
