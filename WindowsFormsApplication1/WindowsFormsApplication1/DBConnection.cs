using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;

namespace WindowsFormsApplication1
{
    class DBConnection
    {
        private OracleConnection conn = null;
        private OracleCommand comd = null;
        private OracleDataReader reader = null;
        private OracleDataAdapter adapter = null;

        public OracleConnection Connection { get { return Connection; }}
        public OracleCommand Command { get { return comd; } }
        public OracleDataReader Reader { get { return reader; } }
        public OracleDataAdapter Adapter {get { return adapter; }}

        // 전역 데이터 설정
        private string ur_cd;

        public string UR_CD {
            get { return ur_cd; }
            set { ur_cd = value; }
        }

        public DBConnection()
        {
            try
            {
                conn = new OracleConnection();
                conn.ConnectionString = "User Id = CHARMJO; Password = CHARMJO; Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); ";
                comd = new OracleCommand();
                comd.Connection = conn;
                conn.Open();
            }
            catch(Exception e)
            {
                throw; 
            }
        }

        public void ExecuteReader(string command)
        {
            comd.CommandText = command;
            reader = comd.ExecuteReader();
        }

        public int ExecuteNonQuery(string command)
        {
            comd.CommandText = command;
            return comd.ExecuteNonQuery();
        }

        public void AdapterOpen(string command)
        {
            adapter = new OracleDataAdapter(command, conn);
        }


        public void Close()
        {
            conn.Close();
        }
    }
}
