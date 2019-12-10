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

    public partial class Diary : Form
    {
        DBConnection db = Program.DB;
        private string diaryCD = null;

        public Diary(DateTime nowDate)
        {
            InitializeComponent();
            //this.nowDate = nowDate;
        }
        public Diary()
        {
            InitializeComponent();

        }
        public DateTime EndDate
        {
            get { return date.Value; }
            set { date.Value = value; }
        }

        public string DiaryCD
        {
            get { return diaryCD; }
            set { diaryCD = value.ToString(); }
        }

        public int StateCheck
        {
            get { return Convert.ToInt32(stateCheck.Checked); }
            set
            {
                int check = value;
                if (check == 0)
                {
                    stateCheck.Checked = true;
                }
                else
                {
                    stateCheck.Checked = false;
                }
            }

        }
        // DateTime 

        // DateTime nowDate = new DateTime();

        private void button1_Click(object sender, EventArgs e)
        {
            string date = EndDate.ToString("yyyy/MM/dd 00:00");
            string sql;
            try
            {
                sql = "insert into DIARY_TB values('D'||to_char(seq_drcd.NEXTVAL),'" + textBox1.Text + "' , to_date('" + date + "', 'yyyy/MM/dd hh24:mi'),'" + db.UR_CD + "', null )";
                db.ExecuteNonQuery(sql);
                MessageBox.Show("일기를 등록했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception E)
            {
                MessageBox.Show("데이터베이스 오류!! \n" + E.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Text = "";
        }

        private void Diary_Load(object sender, EventArgs e)
        {

        }
    }
}
