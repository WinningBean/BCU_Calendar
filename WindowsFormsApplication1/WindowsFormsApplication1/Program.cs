using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        /// 
        
        [STAThread]
        static void Main()
        {
            DBOpen();  //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AddPicture());
        }

        private static DBConnection db = null; // static db 참조변수 선언

        private static void DBOpen() // 데이터베이스 연결 메서드
        {
            try
            {
                db = new DBConnection();
            }
            catch (Exception e) // 연결에 실패했을때 오류메세지 출력
            {
                MessageBox.Show("데이터베이스 연결 실패\n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DBConnection DB {get { return db; }} // db 프로퍼티

    }
}
