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

        #region 폼 그림자 생성
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

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

                string sql = "select * from DIARY_TB where DR_DT = to_date('" + date + "', 'yyyy/MM/dd hh24:mi')";

                db.ExecuteReader(sql);
                if (db.Reader.Read())
                {
                    textBox1.Text = db.Reader[0].ToString();
                }
                else
                {
                    if (MessageBox.Show("오늘 작성한 일기가 없습니다 . 일기를 작성하기겠습니까? ", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
            button1.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button1.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button3.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button3.MouseEnter += new EventHandler(OnTopPanMouseEnter);

        }

  

        private void OnTopPanMouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.SlateGray;
        }
        private void OnTopPanMouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            NowDate = date.Value;
        }
    }
}
