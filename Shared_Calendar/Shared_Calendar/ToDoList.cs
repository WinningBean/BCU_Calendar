using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Shared_Calendar

{
    public partial class ToDoList : Form
    {
        #region 둥근 모서리
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
          int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        #endregion

        Panel insidePan;
        DBConnection db = Program.DB;
        DBColor dbc = null;

        // 체크 기능 추가하기 finish
        // 모든 할일 다 가져오기 finish
        // 시간 표시 finish
        // 삭제기능 구현하기 finish
        // 할일 추가 구현하기 finish
        // 픽처폼 사이즈 줄이기

        public ToDoList()
        {
            InitializeComponent();
            this.AutoScroll = true;
            //this.VerticalScroll.Maximum = 0;
            //this.VerticalScroll.Minimum = 0;
            //this.VerticalScroll.Visible = false;
            dbc = new DBColor();
            tdList = new List<DataRow>();
            this.Size = new Size(this.Size.Width, 689);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 15, 15));
            this.BackColor = Color.White;

            CreateToday();
            insidePan = new Panel();
            insidePan.Location = new Point(0, 50);
            insidePan.Size = new Size(this.Width, 0);
            this.Controls.Add(insidePan);
            CreateToDo();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            defaultColor = Color.Gainsboro;
        }

        public void reset()
        {
            tdList.Clear();
            this.Controls.Clear();

            lastDate = new DateTime();
            CreateToday();
            insidePan = new Panel();
            insidePan.Location = new Point(0, 50);
            insidePan.Size = new Size(this.Width, 0);
            this.Controls.Add(insidePan);
            CreateToDo();
        }

        private void CreateToday()
        {
            Panel todayPan = new Panel();
            todayPan.Location = new Point(0, 0);
            todayPan.Size = new Size(this.Width, 45);
            todayPan.BackColor = Color.Transparent;
            todayPan.Paint += new PaintEventHandler(OnLinePaint);

            Label date = new Label();
            date.AutoSize = true;
            date.BackColor = System.Drawing.Color.Transparent;
            date.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            date.Location = new System.Drawing.Point(5, 10);
            date.Size = new System.Drawing.Size(98, 34);
            date.Text = "ToDoList";

            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label2.Location = new System.Drawing.Point(todayPan.Width - 25, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(27, 25);
            label2.TabIndex = 3;
            label2.Text = "X";
            label2.Click += new System.EventHandler(label2_Click);

            Label label3 = new Label();
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label3.Location = new System.Drawing.Point(92, 15);
            label3.Name = "label2";
            label3.BackColor = Color.Transparent;
            label3.Size = new System.Drawing.Size(27, 8);
            label3.TabIndex = 3;
            label3.Text = "ADD";
            label3.Click += new System.EventHandler(label3_Click);

            todayPan.Controls.Add(label3);
            todayPan.Controls.Add(label2);
            todayPan.Controls.Add(date);
            this.Controls.Add(todayPan);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ToDoList_Add tda = null;
            if (db.GR_CD != null)
                tda = new ToDoList_Add(db.GR_CD);
            else
                tda = new ToDoList_Add(db.UR_CD);

            tda.Location = Cursor.Position;

            if (tda.ShowDialog() == DialogResult.OK)
            {
                reset();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        DateTime lastDate = new DateTime();

        List<DataRow> tdList = null;

        private void CreateToDo()
        {
            DataSet ds = new DataSet("TODO_TB");
            string sql;
            if (db.GR_CD != null) // 그룹이라면 그룹스케줄 표시
                sql = "select * from TODO_TB where TD_COMP_ST = 0 AND TD_GR_FK = '" + db.GR_CD + "'ORDER BY TD_DT";
            else
                sql = "select * from TODO_TB where TD_COMP_ST = 0 AND TD_UR_FK = '" + db.UR_CD + "' ORDER BY TD_DT";
            db.AdapterOpen(sql);
            db.Adapter.Fill(ds, "TODO_TB");
            if (db.GR_CD != null) // 완료된것도 표시해야한다
                sql = "select * from TODO_TB where TD_COMP_ST = 1 AND TD_GR_FK = '" + db.GR_CD + "'ORDER BY TD_DT";
            else
                sql = "select * from TODO_TB where TD_COMP_ST = 1 AND TD_UR_FK = '" + db.UR_CD + "' ORDER BY TD_DT";
            db.AdapterOpen(sql);
            db.Adapter.Fill(ds, "TODO_TB");
            DataTable dt = ds.Tables["TODO_TB"];

            int y = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                tdList.Add(dr);
                if (!(dr[2].Equals(System.DBNull.Value)))
                {
                    DateTime currDate = DateTime.Parse(dr[2].ToString());
                    if (lastDate.ToString("yyyy-MM-dd") != currDate.ToString("yyyy-MM-dd"))
                    {
                        CreateDateLab(currDate, y);
                        insidePan.Size = new Size(insidePan.Width, insidePan.Height + 20);
                        y += 20;
                    }
                }
                else
                {
                    if (lastDate != new DateTime())
                    {
                        CreateNullLab(y);
                        lastDate = new DateTime();
                        insidePan.Size = new Size(insidePan.Width, insidePan.Height + 20);
                        y += 20;
                    }
                }

                Panel todo = new Panel();
                todo.Location = new Point(0, y);
                todo.Size = new Size(this.Width, 60);
                todo.BackColor = Color.Transparent;
                todo.Paint += new PaintEventHandler(OnLinePaint);

                Panel clickPan = new Panel();
                clickPan.Name = i.ToString();
                clickPan.Location = new Point(15, 18);
                clickPan.Size = new Size(30, 30);
                clickPan.BackColor = Color.Transparent;
                clickPan.Paint += new PaintEventHandler(OnButtonPaint);
                clickPan.MouseClick += new MouseEventHandler(OnFinishClick);

                Label txt = new Label();

                //txt.AutoSize = true;
                txt.BackColor = Color.Transparent;
                txt.TextAlign = ContentAlignment.MiddleLeft;
                txt.Size = new Size(this.Width - 65, 60);
                txt.Location = new Point(45, 0);
                txt.Name = i.ToString();
                txt.Text = dr[1].ToString();
                if (dr[3].ToString() == "1")
                    txt.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 14F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                else
                    txt.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                Label deleteLab = new Label();
                deleteLab.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //txt.AutoSize = true;
                deleteLab.BackColor = Color.Transparent;
                deleteLab.TextAlign = ContentAlignment.BottomRight;
                deleteLab.Size = new Size(20, 60);
                deleteLab.Location = new Point(insidePan.Width - 20, 0);
                deleteLab.Name = i.ToString();
                deleteLab.Text = "X";
                deleteLab.Visible = false;
                deleteLab.MouseClick += new MouseEventHandler(OnDeleteClick);


                txt.MouseClick += new MouseEventHandler(OnMouseClick);
                todo.Controls.Add(clickPan);
                todo.Controls.Add(txt);
                todo.Controls.Add(deleteLab);
                insidePan.Size = new Size(insidePan.Width, insidePan.Height + todo.Height);
                insidePan.Controls.Add(todo);

                y += 60;
            }
        }

        Color defaultColor;

        private void OnDeleteClick(object sender, MouseEventArgs e)
        {
            Label lab = (Label)sender;
            db.ExecuteNonQuery("delete FROM TODO_TB where TD_CD = '" + tdList[Int32.Parse(lab.Name)][0].ToString() + "'");
            reset();
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            Label lab = (Label)sender;
            Panel pan = (Panel)lab.Parent;
            if (pan.Controls[2].Visible == true)
                pan.Controls[2].Visible = false;
            else
                pan.Controls[2].Visible = true;
        }



        private void OnFinishClick(object sender, MouseEventArgs e)
        {
            Panel pan = (Panel)sender;
            int num = Int32.Parse(pan.Name);
            DataRow dr = tdList[num];
            if (dr[3].ToString() == "0")
            {
                db.ExecuteNonQuery("UPDATE TODO_TB SET TD_COMP_ST = 1 where TD_CD = '" + dr[0].ToString() + "'");
                dr[3] = "1";
                Panel parent = pan.Parent as Panel;
                parent.Controls[1].Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 14F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                db.ExecuteNonQuery("UPDATE TODO_TB SET TD_COMP_ST = 0 where TD_CD = '" + dr[0].ToString() + "'");
                dr[3] = "0";
                Panel parent = pan.Parent as Panel;
                parent.Controls[1].Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            pan.Invalidate();
            Thread.Sleep(100); // 자꾸 버튼누르면 db에러생겨서 강제로 잠재움
        }

        private void CreateDateLab(DateTime dt, int y)
        {
            Label lab = new Label();
            lab.Location = new Point(10, y + 3);
            lab.Size = new Size(this.Width - 10, 20);
            lab.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lab.BackColor = Color.Transparent;
            lab.TextAlign = ContentAlignment.MiddleLeft;
            lab.Text = dt.ToString("yyyy/MM/dd");
            lastDate = dt;
            insidePan.Controls.Add(lab);
        }

        private void CreateNullLab(int y)
        {
            Label lab = new Label();
            lab.Location = new Point(10, y + 3);
            lab.Size = new Size(this.Width - 10, 20);
            lab.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lab.BackColor = Color.Transparent;
            lab.TextAlign = ContentAlignment.MiddleLeft;
            lab.Text = "마감일자 없음";
            insidePan.Controls.Add(lab);
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
            Thread.Sleep(25);
            db.ExecuteReader("select * from TODO_TB where TD_CD = '" + tdList[Int32.Parse(pan.Name)][0] + "'");
            db.Reader.Read();
            Color c = new Color();

            if (db.Reader[3].ToString().Equals("0"))
            {
                if (tdList[Int32.Parse(pan.Name)][4].ToString() != "")
                    c = dbc.GetColorInsertCRCD(db.Reader[4].ToString());
                else
                    c = defaultColor;
            }
            else
                c = defaultColor;

            db.Reader.Close();//혹시에러날까봐

            Color softC = Color.FromArgb(c.A / 4, c.R, c.G, c.B);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen p = new Pen(c, 2);
            g.FillEllipse(new SolidBrush(softC), new Rectangle(0, 0, 22, 22));
            g.DrawEllipse(p, new Rectangle(0, 0, 22, 22));
            p.Dispose();
        }


    }
}
