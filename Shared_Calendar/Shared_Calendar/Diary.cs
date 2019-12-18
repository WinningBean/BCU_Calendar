using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared_Calendar
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
            set { date.Value = value; }
        }

        public string DiaryCD
        {
            get { return diaryCD; }
            set { diaryCD = value.ToString(); }
        }

        // DateTime 

        // DateTime nowDate = new DateTime();


        private void Diary_Load(object sender, EventArgs e)
        {
            stateCheck.Enabled= false;

            if (db.IS_PB == 0)
            {
                stateCheck.Checked = true;
            }
            else
            {
                stateCheck.Checked = false;
            }

            if (date.Value != null)
            {
                if (db.IS_PB == 0)
                {
                    checkpivate();
                }
                else
                {
                    checkPublic();
                }

            }
            button4.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button4.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button5.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button5.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button6.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button6.MouseEnter += new EventHandler(OnTopPanMouseLeave);


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
            if (date.Value != null)
            {
                if (db.IS_PB == 0)
                {
                    checkpivate();
                }
                else
                {
                    checkPublic();
                }

            }

        }
        private void checkPublic()
        {
            textBox1.Text = "";
            NowDate = date.Value;
            string dateFormat = NowDate.ToString("yyyy/MM/dd 00:00");
            string sql = "select * from DIARY_TB where DR_UR_FK ='" + db.UR_CD + "' and DR_DT = to_date('" + dateFormat + "', 'yyyy/MM/dd hh24:mi') and DR_PB_EX is not null";
            db.ExecuteReader(sql);
            if (db.Reader.Read())
            {
                string nowdate = db.Reader[1].ToString();
                int year = Convert.ToInt32(nowdate.Substring(0, 4));
                int month = Convert.ToInt32(nowdate.Substring(5, 2));
                int day = Convert.ToInt32(nowdate.Substring(8, 2));
                DateTime currDate = new DateTime(year, month, day);

                stateCheck.Enabled = false;
                textBox1.Text = db.Reader[2].ToString();
                button6.Tag = currDate;
                button4.Enabled = false;
                button4.Visible = false;
                button5.Enabled = false;
                button5.Visible = false;
                button4.Enabled = true;
                button4.Visible = true;
                button6.Enabled = true;
                button6.Visible = true;
            }
            else
            {
                button5.Enabled = true;
                button5.Visible = true;
                button4.Enabled = false;
                button4.Visible = false;
                button6.Enabled = false;
                button6.Visible = false;

            }
        }
        private void checkpivate()
        {
            textBox1.Text = "";
            NowDate = date.Value;
            string dateFormat = NowDate.ToString("yyyy/MM/dd 00:00");
            string sql = "select * from DIARY_TB where DR_UR_FK ='" + db.UR_CD + "' DR_DT = to_date('" + dateFormat + "', 'yyyy/MM/dd hh24:mi') and DR_PV_EX is not null";
            db.ExecuteReader(sql);
            if (db.Reader.Read())
            {
                string nowdate = db.Reader[1].ToString();
                int year = Convert.ToInt32(nowdate.Substring(0, 4));
                int month = Convert.ToInt32(nowdate.Substring(5, 2));
                int day = Convert.ToInt32(nowdate.Substring(8, 2));
                DateTime currDate = new DateTime(year, month, day);

                stateCheck.Enabled = false;
                textBox1.Text = db.Reader[3].ToString();
                button6.Tag = currDate;
                button5.Enabled = false;
                button5.Visible = false;
                button4.Enabled = true;
                button4.Visible = true;
                button6.Enabled = true;
                button6.Visible = true;
            }
            else
            {
                button5.Enabled = true;
                button5.Visible = true;
                button4.Enabled = false;
                button4.Visible = false;
                button6.Enabled = false;
                button6.Visible = false;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NowDate = date.Value;
            string dateFormat = NowDate.ToString("yyyy/MM/dd 00:00");

            try
            {

                if (db.IS_PB == 0)// 비공개 
                {
                    string sql = "update DIARY_TB  set ";
                    sql += " DR_PV_EX = '" + textBox1.Text + "'";
                    sql += " where DR_DT = to_date('" + dateFormat + "', 'yyyy/MM/dd hh24:mi')";
                    sql += " and DR_PB_EX is not null";
                    db.ExecuteNonQuery(sql);
                }
                else
                {
                    string sql = "update DIARY_TB  set ";
                    sql += " DR_PB_EX = '" + textBox1.Text + "'";
                    sql += " where DR_DT = to_date('" + dateFormat + "', 'yyyy/MM/dd hh24:mi')";
                    sql += " and DR_PV_EX is not null";
                    db.ExecuteNonQuery(sql);
                }

                MessageBox.Show("수정이 완료 되었습니다", "완료", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("해당 날짜의 (공개/비공개) 일기가 이미 있습니다.\n              공개상태를 확인해 주세요" + E.Message, "완료", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string date = NowDate.ToString("yyyy/MM/dd 00:00");
            string sql;

            if (db.IS_PB == 0)
            {
                try
                {
                    sql = "insert into DIARY_TB values('" + db.UR_CD + "' , to_date('" + date + "', 'yyyy/MM/dd hh24:mi'), null '" + textBox1.Text + "')";
                    db.ExecuteNonQuery(sql);
                    MessageBox.Show("일기를 등록했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox1.Text = "";
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("오늘자 비공개 일기를 이미 작성하셨습니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                try//
                {
                    sql = "insert into DIARY_TB values('" + db.UR_CD + "' , to_date('" + date + "', 'yyyy/MM/dd hh24:mi'),'" + textBox1.Text + "', null)";
                    db.ExecuteNonQuery(sql);
                    MessageBox.Show("일기를 등록했습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox1.Text = "";
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("오늘자 공개 일기를 이미 작성하셨습니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            DateTime currDate = (DateTime)bt.Tag;
            string date = currDate.ToString("yyyy/MM/dd H:mm");
            if (db.IS_PB == 0)
            {
                if (MessageBox.Show("일기가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from DIARY_TB";
                    sql += " where DR_DT = to_date('" + date + "', 'yyyy/MM/dd hh24:mi')";
                    sql += " and DR_UR_FK='" + db.UR_CD + "'";
                    sql += " DR_PV_EX is not null";
                    db.ExecuteNonQuery(sql);
                    MessageBox.Show("삭제 완료 되었습니다", "완료", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
            {
                if (MessageBox.Show("일기가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from DIARY_TB";
                    sql += " where DR_DT = to_date('" + date + "', 'yyyy/MM/dd hh24:mi')";
                    sql += " and DR_UR_FK='" + db.UR_CD + "'";
                    sql += " and DR_PB_EX is not null";
                    db.ExecuteNonQuery(sql);
                    MessageBox.Show("삭제 완료 되었습니다", "완료", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }
    }

  }

   
