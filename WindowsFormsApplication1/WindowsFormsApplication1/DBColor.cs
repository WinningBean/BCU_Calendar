using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{

    class DBColor
    {
        DBConnection db = Program.DB;
        Dictionary<string, string> colorDic;

        public DBColor() {
            colorDic = new Dictionary<string, string>();
            db.ExecuteReader("select * from COLOR_TB");
            while (db.Reader.Read())
            {
                colorDic.Add(db.Reader[0].ToString(), db.Reader[1].ToString());
            }
        }

        public Dictionary<string, string> ColorDic
        {
            get { return colorDic; }
        }

        public Color randomColor(int alpha) // 색을 랜덤으로 만들어줌
        {
            Random r = new Random();
            db.ExecuteReader("select * from COLOR_TB");
            int num = r.Next() % db.Reader.FieldCount;
            for (int i = 0; i <= num; i++)
                db.Reader.Read();

            return Color.FromArgb(alpha, Int32.Parse(db.Reader[2].ToString()), Int32.Parse(db.Reader[3].ToString()), Int32.Parse(db.Reader[4].ToString()));
        }

        public string GetColorCode(string str) // 컬러코드 리턴
        {
            db.ExecuteReader("select * from COLOR_TB where CR_NM = '" + str + "'");
            if (!db.Reader.Read())
                return "Do not exist";
            return db.Reader[0].ToString();
        }

        public string GetColorName(string str) // 컬명 리턴
        {
            db.ExecuteReader("select * from COLOR_TB where CR_CD = '" + str + "'");
            if (!db.Reader.Read())
                return "Do not exist";
            return db.Reader[1].ToString();
        }

        public Color GetColorInsertCRCD(string CR_CD, int alpha = 255) // 지정한 색을 리턴
        {
            db.ExecuteReader("select * from COLOR_TB where CR_CD = '" + CR_CD + "'");
            if (!db.Reader.Read())
                return new Color();

            return Color.FromArgb(alpha, Int32.Parse(db.Reader[2].ToString()), Int32.Parse(db.Reader[3].ToString()), Int32.Parse(db.Reader[4].ToString()));
        }

        public Color GetColorInsertName(string colorName, int alpha = 255) // 지정한 색을 리턴
        {
            db.ExecuteReader("select * from COLOR_TB where CR_NM = '" + colorName + "'");
            if (!db.Reader.Read())
                return new Color();

            return Color.FromArgb(alpha, Int32.Parse(db.Reader[2].ToString()), Int32.Parse(db.Reader[3].ToString()), Int32.Parse(db.Reader[4].ToString()));

        }
    }

}
