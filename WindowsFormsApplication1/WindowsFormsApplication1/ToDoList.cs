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
    public partial class ToDoList : Form
    {
        #region 둥근 모서리
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
          int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        #endregion

        Panel insidePan;
        DateTime m_focus_dt;
        DBConnection db = Program.DB;
        DBColor dbc = null;

        public ToDoList()
        {
            InitializeComponent();
            dbc = new DBColor();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 13, 13));
            this.BackColor = Color.White;

            CreateToday(DateTime.Now);
            insidePan = new Panel();
            insidePan.Location = new Point(0, 50);
            insidePan.Size = new Size(this.Width, 0);
            this.Controls.Add(insidePan);
            CreateToDo(DateTime.Now);
        }

        public ToDoList(DateTime m_focus_dt)
        {
            InitializeComponent();
            this.m_focus_dt = m_focus_dt;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 13, 13));

            insidePan = new Panel();
        }

        private void CreateToday(DateTime today)
        {
            Panel todayPan = new Panel();
            todayPan.Location = new Point(0, 0);
            todayPan.Size = new Size(this.Width, 45);
            todayPan.BackColor = Color.Transparent;
            todayPan.Paint += new PaintEventHandler(OnLinePaint);

            Label date = new Label();
            date.AutoSize = true;
            date.BackColor = System.Drawing.Color.Transparent;
            date.Font = new System.Drawing.Font("Ink Free", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            date.Location = new System.Drawing.Point(10, 10);
            date.Size = new System.Drawing.Size(98, 34);
            if (today.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                date.Text = "Today";
            else
                date.Text = m_focus_dt.ToString("yyyy년 MM월 dd일");

            todayPan.Controls.Add(date);
            this.Controls.Add(todayPan);
        }

        private void CreateToDo(DateTime today)
        {
            DataSet ds = new DataSet("TODO_TB");
            string sql = "select * from TODO_TB where TD_DT >= '" + today.ToString("yyyy-MM-dd") 
                + "' AND TD_DT < '" + today.AddDays(1).ToString("yyyy-MM-dd") 
                + "' AND TD_COMP_ST = 0 ORDER BY TD_DT";
            db.AdapterOpen(sql);
            db.Adapter.Fill(ds, "TODO_TB");
            sql = "select * from TODO_TB where TD_DT >= '" + today.ToString("yyyy-MM-dd")
                + "' AND TD_DT < '" + today.AddDays(1).ToString("yyyy-MM-dd")
                + "' AND TD_COMP_ST = 1 ORDER BY TD_DT";
            db.AdapterOpen(sql);
            db.Adapter.Fill(ds, "TODO_TB");
            DataTable dt = ds.Tables["TODO_TB"];

            int y = 0;
            for(int i = 0; i< dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Panel todo = new Panel();
                todo.Location = new Point(0, y);
                todo.Size = new Size(this.Width, 60);
                todo.BackColor = Color.Transparent;
                todo.Paint += new PaintEventHandler(OnLinePaint);

                Panel clickPan = new Panel();
                clickPan.Name = dr[0].ToString();
                clickPan.Location = new Point(15, 18);
                clickPan.Size = new Size(30, 30);
                clickPan.BackColor = Color.Transparent;
                clickPan.Paint += new PaintEventHandler(OnButtonPaint);

                Label txt = new Label();
                txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //txt.AutoSize = true;
                txt.BackColor = Color.Transparent;
                txt.TextAlign = ContentAlignment.MiddleLeft;
                txt.Size = new Size(this.Width - 45, 60);
                txt.Location = new Point(45, 0);
                txt.Text = dr[1].ToString();

                todo.Controls.Add(clickPan);
                todo.Controls.Add(txt);
                insidePan.Size = new Size(insidePan.Width, insidePan.Height + todo.Height);
                insidePan.Controls.Add(todo);

                y += 60;
            }
        }

        private void OnLinePaint(object sender, PaintEventArgs e)
        {
            Panel pan = (Panel)sender;
            Pen p = new Pen(Color.LightGray, 2);
            e.Graphics.DrawLine(p, 0, pan.Height, pan.Width, pan.Height);
            p.Dispose();
        }

        private void OnButtonPaint(object sender, PaintEventArgs e)
        {
            Panel pan = (Panel)sender;
            db.ExecuteReader("select * from TODO_TB where TD_CD = '" + pan.Name + "'");
            db.Reader.Read();
            Color c = new Color();
            if (db.Reader[3].ToString().Equals("0"))
                c = dbc.GetColorInsertCRCD(db.Reader[4].ToString());
            else
                c = dbc.GetColorInsertName("GRAY");
            Color softC = Color.FromArgb(c.A - 200, c.R, c.G, c.B);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen p = new Pen(c, 2);
            g.FillEllipse(new SolidBrush(softC), new Rectangle(0, 0, 22, 22));
            g.DrawEllipse(p, new Rectangle(0, 0, 22, 22));
            p.Dispose();
        }
    }
}
