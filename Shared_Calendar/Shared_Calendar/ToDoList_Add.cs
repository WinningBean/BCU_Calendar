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
    public partial class ToDoList_Add : Form
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
        string urcd;

        public ToDoList_Add(string urcdOrgrcd)
        {
            InitializeComponent();
            this.urcd = urcdOrgrcd;
            makeColor();
        }

        private void makeColor()
        {
            db.AdapterOpen("select * from COLOR_TB");
            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "COLOR_TB");
            DataTable dt = ds.Tables["COLOR_TB"];
            int loca = 5;
            DBColor dbc = new DBColor();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Panel pan = new Panel();
                pan.Size = new Size(18, 18);
                pan.Location = new Point(loca, 5);
                pan.BorderStyle = BorderStyle.None;
                pan.BackColor = dbc.GetColorInsertCRCD(dr[0].ToString());
                pan.Name = dr[0].ToString();
                pan.Click += new EventHandler(OnColorClick);
                loca += 22;
                m_Color_pan.Controls.Add(pan);
            }
            Random r = new Random();
            int ran = r.Next() % m_Color_pan.Controls.Count;
            ((Panel)m_Color_pan.Controls[ran]).BorderStyle = BorderStyle.FixedSingle;
            selectCD = m_Color_pan.Controls[ran].Name;
        }

        string selectCD;

        private void OnColorClick(object sender, EventArgs e)
        {
            for (int i = 0; i < m_Color_pan.Controls.Count; i++)
            {
                ((Panel)m_Color_pan.Controls[i]).BorderStyle = BorderStyle.None;
            }
            Panel pan = (Panel)sender;
            pan.BorderStyle = BorderStyle.FixedSingle;
            selectCD = pan.Name;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_Date_cb.Checked) // 마감일자 미설정 체크가 되어있으면
            {
                if (urcd[0] == 'U') // 유저면
                {
                    db.ExecuteNonQuery("insert into TODO_TB values('T' || SEQ_TDCD.nextval, '" +
                    textBox2.Text + "', null, 0, '" + selectCD + "', '" + urcd + "', null)");
                }
                else // 그룹이면
                {
                    db.ExecuteNonQuery("insert into TODO_TB values('T' || SEQ_TDCD.nextval, '" +
                    textBox2.Text + "', null, 0, '" + selectCD + "', null, '" + urcd + "')");
                }
            }
            else
            {
                if (urcd[0] == 'U') // 유저면
                {
                    db.ExecuteNonQuery("insert into TODO_TB values('T' || SEQ_TDCD.nextval, '" +
                    textBox2.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                    "', 0, '" + selectCD + "', '" + urcd + "', null)");
                }
                else // 그룹이면
                {
                    db.ExecuteNonQuery("insert into TODO_TB values('T' || SEQ_TDCD.nextval, '" +
                    textBox2.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                    "', 0, '" + selectCD + "', null, '" + urcd + "')");
                }
            }
            MessageBox.Show("할일이 등록되었습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ToDoList_Add_LocationChanged(object sender, EventArgs e)
        {

            if (this.Location.X <= 0)
                this.Location = new Point(0, this.Location.Y);
            if (this.Location.X + this.Width >= System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width)
                this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width, this.Location.Y);
            if (this.Location.Y <= 0)
                this.Location = new Point(this.Location.X, 0);
            if (this.Location.Y + this.Height >= System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height)
                this.Location = new Point(this.Location.X, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }

        private void ToDoList_Add_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToDoList_Add_Load(object sender, EventArgs e)
        {
            if (m_Date_cb.Checked)
                dateTimePicker1.Enabled = false;
            else
                dateTimePicker1.Enabled = true;
        }

        private void m_Date_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Date_cb.Checked)
                dateTimePicker1.Enabled = false;
            else
                dateTimePicker1.Enabled = true;
        }
    }
}
