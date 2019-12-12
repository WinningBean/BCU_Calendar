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
        DateTime nowDate;

        public Diary(DateTime nowDate)
        {
            InitializeComponent();
            //this.nowDate = nowDate;

            NowDate = nowDate;
        }
        public Diary()
        {
            InitializeComponent();

        }
        public DateTime NowDate
        {
            get { return date.Value; }
            set { date.Value= value; }
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
            string date = NowDate.ToString("yyyy/MM/dd 00:00");
 
            string sql;
            try
            {
                sql = "insert into DIARY_TB values('" + textBox1.Text + "' , to_date('" + date + "', 'yyyy/MM/dd hh24:mi'),'" + db.UR_CD + "', '" + StateCheck + "')";
                db.ExecuteNonQuery(sql);
                MessageBox.Show("일기를 등록했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception)
            {
                MessageBox.Show("오늘자 일기를 이미 작성하셨습니다." , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Text = "";
        }

        private void Diary_Load(object sender, EventArgs e)
        {
            if(date.Value != null)
            {
                string date = NowDate.ToString("yyyy/MM/dd 00:00");
                string sql = " select  * from DIARY_TB where DR_DT =to_date('" + date + "', 'yyyy/MM/dd hh24:mi')";
                db.ExecuteReader(sql);
                if(db.Reader.Read())
                {
                    textBox1.Text = db.Reader[0].ToString();
                }
                else
                {
                    if (MessageBox.Show("등록된 일기가없습니다 .일기를 쓰시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Close();
                    }
 
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
