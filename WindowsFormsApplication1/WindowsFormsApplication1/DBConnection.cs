using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using System.IO;

namespace WindowsFormsApplication1
{
    class DBConnection
    {
        private OracleConnection conn = null;
        private OracleCommand comd = null;
        private OracleDataReader reader = null;
        private OracleDataAdapter adapter = null;

        public OracleConnection Connection { get { return Connection; } }
        public OracleCommand Command { get { return comd; } }
        public OracleDataReader Reader { get { return reader; } }
        public OracleDataAdapter Adapter { get { return adapter; } }

        // 전역 데이터 설정
        private string ur_cd = "aa";

        public string UR_CD
        {
            get { return ur_cd; }
            set { ur_cd = value; }
        }

        public DBConnection()
        {// 굳이 try catch에 throw 넣지 않아도 예외발생시 알아서 호출된곳으로 넘기게됨
            conn = new OracleConnection();
            conn.ConnectionString = "User Id = CHARMJO; Password = CHARMJO; Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl))); ";
            comd = new OracleCommand();
            comd.Connection = conn;
            conn.Open();
        }

        public void ExecuteReader(string command)
        {
            comd.CommandText = command;
            reader = comd.ExecuteReader();
        }

        public int ExecuteNonQuery(string command)
        {
            comd.CommandText = command;
            int result = comd.ExecuteNonQuery();
            return result;
        }

        public void AdapterOpen(string command)
        {
            adapter = new OracleDataAdapter(command, conn);
        }

        public void FileSave(string filePath)
        {
            // 입력받은 파일을 바이트 배열에 저장
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fs.Length - 1];
            fs.Read(b, 0, b.Length);
            fs.Close();

            // 배열에 있는 데이터를 보낼 정보를 담는다
            OracleParameter op = new OracleParameter();
            op.ParameterName = ":BINARYFILE";
            op.OracleDbType = Oracle.DataAccess.Client.OracleDbType.Blob;
            op.Direction = ParameterDirection.Input;
            op.Size = b.Length;
            op.Value = b;
            comd.CommandType = CommandType.Text;
            comd.Parameters.Add(op);

            ExecuteReader("select TO_CHAR(SEQ_PICCD.nextval) from dual"); // 다음 시퀀스 값 불러오기
            string currSeq = null;
            if (Reader.Read())
                currSeq = Reader.GetString(0);

            ExecuteNonQuery("insert into PICTURE_TB values('P'||SEQ_PICCD.currval, '1', sysdate, '" + UR_CD + "', null, :BINARYFILE)");
            comd.Parameters.Remove(op);
        }

        public void Close()
        {
            conn.Close();
        }
    }
}