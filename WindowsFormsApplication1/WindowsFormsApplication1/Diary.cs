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
        string nowdate;
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
            get { return Convert.ToInt32(!stateCheck.Checked); }
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
                textBox1.Text = "";
                this.Close();
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
                check();
                
            }
            button1.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button1.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button2.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button2.MouseEnter += new EventHandler(OnTopPanMouseLeave);
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
            check();

        }
        private void check()
        {
            textBox1.Text = "";
            NowDate = date.Value;
            string dateFormat = NowDate.ToString("yyyy/MM/dd 00:00");
            string sql = "select * from DIARY_TB where DR_DT = to_date('" + dateFormat + "', 'yyyy/MM/dd hh24:mi') and DR_PB_ST = '" + db.IS_PB + "'";
            db.ExecuteReader(sql);
            if (db.Reader.Read())
            {
                textBox1.Text = db.Reader[0].ToString();
                StateCheck = db.IS_PB;
                button3.Tag = db.Reader[1];
                button1.Enabled = false;
                button1.Visible = false;
                button2.Enabled = true;
                button2.Visible = true;
                button3.Enabled = true;
                button3.Visible = true;
            }
            else
            {
                StateCheck = db.IS_PB;
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = false;
                button2.Visible = false;
                button3.Enabled = false;
                button3.Visible = false;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NowDate = date.Value;
            string dateFormat = NowDate.ToString("yyyy/MM/dd 00:00");
            string sql = "update DIARY_TB set DR_EX = '" + textBox1.Text + "' DR_DT = to_date('" + dateFormat + "', 'yyyy/MM/dd hh24:mi') and DR_PB_ST = '" + db.IS_PB + "' where DR_DT = to_date('" + dateFormat + "', 'yyyy/MM/dd hh24:mi') and DR_PB_ST = '" + db.IS_PB+ "'";
            try
            {
                db.ExecuteNonQuery(sql);
                MessageBox.Show("수정이 완료 되었습니다", "완료", MessageBoxButtons.OK);
                this.Close();
            }
            catch
            {
                MessageBox.Show("해당 날짜의 (공개/비공개) 일기가 이미 있습니다.\n              공개상태를 확인해 주세요", "완료", MessageBoxButtons.OK);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // Button btn = (Button)sender;
           // string nowdate = ((DateTime)btn.Tag).ToString("yyyy/MM/dd H:mm");
           //;
           // if (MessageBox.Show("일기가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
           // {
           //    // string command = "delete from DIARY_TB where DR_DT = to_date('" + nowdate + "', 'yyyy/MM/dd hh24:mi') and DR_PB_ST = '" + check + "' and DR_UR_FK='" + db.UR_CD + "'";
           //     db.ExecuteNonQuery(command);
           //     this.Close();
           // }
        }
    }
}
