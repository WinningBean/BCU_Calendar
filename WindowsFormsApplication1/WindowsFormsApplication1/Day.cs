using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Day : Form
    {
        DBConnection db = Program.DB;
        DBSchedule dbs =null;
        DBColor dbc = null;

        Panel paintPan;
        Panel day;
        Panel pre;

        DataTable GET_DAY_SC_TB = null;

        private DateTime m_focus_dt; // 현재 포커스 날짜
        public DateTime FOCUS_DT
        { // 현재 포커스날짜 프로퍼티
            set { m_focus_dt = value; }
        }
        public DateTime Get_focus_dt() { return m_focus_dt; }


        int checkHeight;
        int[,] location;

       
       DateTime nowDate;

        public Day()//DateTime date
        {
            InitializeComponent();
            pre = null;
            checkHeight = 0;
            day = new Panel();
            pre = new Panel();
            paintPan = new Panel();
            checkHeight = 0;
            location = new int[15, 2];
        }
 
        
        private void Get_chedule()
        {
            if(db.GR_CD == null)
            {
                GET_DAY_SC_TB = dbs.Get_Day_Schedule(true, db.UR_CD, nowDate, db.IS_PB);
                location = new int[15, 2];

                for (int i = 0; i < GET_DAY_SC_TB.Rows.Count; i++)
                {
                    DataRow currRow = GET_DAY_SC_TB.Rows[i];
                    Create_Day(currRow, i);
                }
            }
            else
            {
                GET_DAY_SC_TB = dbs.Get_Day_Schedule(false, db.GR_CD, nowDate, db.IS_PB);
                location = new int[15, 2];

                for (int i = 0; i < GET_DAY_SC_TB.Rows.Count; i++)
                {
                    DataRow currRow = GET_DAY_SC_TB.Rows[i];
                    Create_Day(currRow, i);
                }
            }
          
            // dt.Clear();
            //그룹이라면 
            //GET_DAY_SC_TB = dbs.Get_Day_Schedule(false, db.UR_CD, nowDate, db.IS_PB);
        }

        private void Check(Panel curr, Label name, Label color) // 일정 위치 검사 겹치면 내림 !! 
        {
            if (location[curr.TabIndex,1] != 0) // 같은 열에 이미 값이 들어 있으면 비교하고
            {
                // location[curr.TabIndex,1]    curr.TabIndex은  깊이 확인용
                // location[curr.TabIndex,1]    0왼쪽 X값
                // location[curr.TabIndex,1]    1은 오는쪽 X값

                if (location[curr.TabIndex,0] == curr.Left || location[curr.TabIndex,1] > curr.Left) //겹치는 조건 
                {
                    //겹치면 Y값을 조정 
                    curr.Location = new Point(curr.Location.X, curr.Location.Y + 110);
                    name.Location = new Point(name.Location.X, name.Location.Y + 110);
                    color.Location = new Point(color.Location.X, color.Location.Y + 110);
                    curr.TabIndex++;
                    Check(curr, name, color);

                }
                else // 아니면 저장 
                {
                    location[curr.TabIndex,0] = curr.Left;
                    location[curr.TabIndex,1] = curr.Right;
                }
            }
            else// 깉은 열에 아직 값이 없으면 저장 
            {
                location[curr.TabIndex,0] = curr.Left;
                location[curr.TabIndex,1] = curr.Right;

                if (pre.TabIndex < curr.TabIndex)
                {
                    // 버튼으로 일정을 내리기 위해서 일정이 몇개가 겹치는지 알아야함
                    checkHeight = curr.TabIndex;
                }
               
            }
            pre = curr;
        }

        private void Create_Day(DataRow dr, int i) // 하루 일정 생성
        {
            int y = 0;

            Color color = dbc.GetColorInsertCRCD(dr[7].ToString());
            DateTime strSC = Convert.ToDateTime(dr[4].ToString()); 
            DateTime endSC = Convert.ToDateTime(dr[5].ToString());

            int scheduleTimeSize;

            if (endSC.Hour == 0 )
            {
                scheduleTimeSize = (24 * 120 + endSC.Minute * 2) - (strSC.Hour * 120 + strSC.Minute * 2);
            }
            else if(strSC.Day != endSC.Day)
            {
                scheduleTimeSize = (25 * 120 ) - (strSC.Hour * 120 + strSC.Minute * 2);
            }
            else
            {
               scheduleTimeSize = (endSC.Hour * 120 + endSC.Minute * 2) - (strSC.Hour * 120 + strSC.Minute * 2);
            }



            Panel cre = new Panel();
            cre.Size = new System.Drawing.Size(scheduleTimeSize,80);
            cre.Location = new System.Drawing.Point(strSC.Hour * 120 + strSC.Minute * 2 + 30, y);
           // cre.BorderStyle = BorderStyle.FixedSingle;
            cre.TabIndex = 0;
            cre.Tag = i;
            cre.BackColor = color;
           // cre.Click += new EventHandler(Schedule_Click);


            Label scheduleNameColor = new Label();
            scheduleNameColor.ForeColor = color;
            scheduleNameColor.Text = "●";
            scheduleNameColor.Size = new System.Drawing.Size(30, 25);
            scheduleNameColor.Location = new System.Drawing.Point(cre.Location.X, cre.Location.Y + 80);
           // scheduleNameColor.BackColor = Color.Black;
            scheduleNameColor.Font=new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            Label scheduleName = new Label();
            scheduleName.Text = dr[1].ToString();
            scheduleName.Size = new System.Drawing.Size(scheduleTimeSize - 30, 20);
            scheduleName.Location = new System.Drawing.Point(scheduleNameColor.Location.X + 30, scheduleNameColor.Location.Y +3);
            scheduleName.Font = new System.Drawing.Font("Microsoft Sans Serif",12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            Label label = new Label();
            label.Text = dr[2].ToString();
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label.Size = new System.Drawing.Size(scheduleTimeSize, 80);
            label.TabIndex = i;
            label.Click += new EventHandler(Label_Click);
            label.Padding = new Padding(5, 5, 5, 5);
            if (!(dr[6].ToString().Equals(System.DBNull.Value)) && cre.Size.Width > 119) // 1시간 이상 일정에 사진이 있는경우
            {
                string sql = "select * from PICTURE_TB where PIC_CD = '" + dr[6].ToString() + "'";
                db.ExecuteReader(sql);

                if (db.Reader.Read())
                {
                    Byte[] b = (Byte[])(db.Reader["PIC_DATA"]);
                    MemoryStream stmBlobData = new MemoryStream(b);
                    Image img = Image.FromStream(stmBlobData);
                    //Image img = FineImage(db.Reader.Read, i);
                    Create_Picure(scheduleNameColor.Location.X , scheduleNameColor.Location.Y, img,cre, i);

                    label.Size = new Size(scheduleTimeSize-120, 80);
                    label.Location = new Point(120, 0);
                    cre.Controls.Add(label);

                    if (cre.Size.Width == 120) // 사진이 있는데 일정이 1시간 일정인 경우
                    {
                        cre.Controls.Remove(label);
                        
                    }
                }
            }


            day.Controls.Add(cre);
            day.Controls.Add(scheduleName);
            day.Controls.Add(scheduleNameColor);
            cre.Controls.Add(label);

            if (pre == null)
            {
                pre = cre;
                checkHeight = pre.TabIndex;

            }
            else
            {
                Check(cre, scheduleName, scheduleNameColor);
            }

        }

        private Image FineImage(DataRow dr, int i)
        {
            Byte[] b = (Byte[])(db.Reader["PIC_DATA"]);
            MemoryStream stmBlobData = new MemoryStream(b);
            Image img = Image.FromStream(stmBlobData);

            return img;
        }


        private void Create_Picure(int xLocation,int yLocation, Image img,Panel panel,int i)
        {
            PictureBox pb = new PictureBox();
            panel.Controls.Add(pb);

            //float wpercent = (float)img.Width / 120;
            //float hpercent = (float)img.Width / 120;
            //int imgHeight = (int)((float)img.Height / hpercent);
            //int imgWidth = (int)((float)img.Width / wpercent);

            pb.Size = new Size(115, 80);
            pb.Location = new Point(5,0);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.TabIndex = i;
            pb.Image = img;
            pb.Click += new EventHandler(PictureBox_Click);
            pb.Show();
        }


        private void Draw_Line(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int x = 40;
            int y = 100;
           Button label = new Button();
            label.Size = new System.Drawing.Size(30, 70);
            paintPan.Controls.Add(label);
            label.Location = new System.Drawing.Point(0, 0);
            label.Text = "◀";
            label.Click += new System.EventHandler(preDay_Click);
            label.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label.FlatAppearance.BorderSize = 0;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < 25; i++)
            {
                Panel pan = new Panel();
                graphics.DrawLine(pen, x, 0, x, 30);
                x += 120;
               // paintPan.Controls.Add(pan);
            }
            for (int i = 0; i < 24; i++)
            {
                Panel pan = new Panel();
                graphics.DrawLine(pen, y, 0, y, 15);
                y += 120;
               // paintPan.Controls.Add(pan);
            }

            Button label1 = new Button();
            label1.Size = new System.Drawing.Size(30, 70);
            paintPan.Controls.Add(label1);
            label1.Location = new System.Drawing.Point(2940, 0);
            label1.Text = "▶";
            label1.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label1.FlatAppearance.BorderSize = 0;
            label1.Click += new System.EventHandler(nextDay_Click);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        }
        private void Draw_Time()
        {
            int x = 31;
            for (int i = 0; i < 25; i++)
            {
                Label timeLable = new Label();
                timeLable.Text = (i).ToString();


                timeLable.AutoSize = true;
                timeLable.Location = new Point(x, 40);

                //pan.BorderStyle = BorderStyle.FixedSingle;

                timeLable.TextAlign = ContentAlignment.TopRight;
                timeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                timeLable.ForeColor = System.Drawing.Color.Black;
                x += 120;
                timeLable.Show();
                paintPan.Controls.Add(timeLable);

            }
        }
        private void Day_Load(object sender, EventArgs e)
        {
            button1.Visible = true;
            Down.Visible = true;

            dbs = new DBSchedule();
            dbc = new DBColor();
            nowDate = m_focus_dt;
            label1.Text = nowDate.ToString("yyyy.MM.dd ddd"); 
            day.AutoSize = true;
            day.AutoScroll = false;
            day.Location = new Point(0, 70);


            paintPan.Location = new Point(0, 0);
            paintPan.Size = new System.Drawing.Size(2990, 70);
            paintPan.Show();
            paintPan.Paint += new System.Windows.Forms.PaintEventHandler(Draw_Line);
            paintPan.BackColor = Color.Transparent;

            panel2.Controls.Add(paintPan);
            panel2.Controls.Add(day);
            panel2.Size = new System.Drawing.Size(600, 2230);

            Draw_Time();
            panel2.VerticalScroll.Maximum = 0;
            panel2.HorizontalScroll.Maximum = 0;
            panel2.VerticalScroll.Visible = false;
            panel2.VerticalScroll.Enabled = true;
            panel2.AutoScroll = true;


          

            Get_chedule();
            day.Controls.Clear(); 
            Get_chedule();
            Get_TodoList();

            if(checkHeight < 3)
            {
                button1.Visible = false;
                Down.Visible = false;
                Down.Enabled = false;
                button1.Enabled = false;
            }

            button1.Enabled = false;
            Down.Enabled = true;
        }

        private void Label_Click(object render, EventArgs e)
        {
            Label myPan = (Label)render;
            int i = myPan.TabIndex;
            DataRow curr = GET_DAY_SC_TB.Rows[i];
 
            Schedule_Modify dlg = new Schedule_Modify(curr["SC_CD"].ToString());
            dlg.FormClosed += new FormClosedEventHandler(Dlg_FormClosing);
            dlg.ShowDialog();

        }

        private void Dlg_FormClosing(object sender,FormClosedEventArgs e) // 일정 수정 폼이 닫히면 스케줄 다시불러오기
        {
            day.Controls.Clear();
            Get_chedule();
        }

        private void PictureBox_Click(object render, EventArgs e)
        {
            PictureBox myPic = (PictureBox)render;
            int i = myPic.TabIndex;
            DataRow curr = GET_DAY_SC_TB.Rows[i];


            Schedule_Modify dlg = new Schedule_Modify(curr["SC_CD"].ToString());
            dlg.FormClosed += new FormClosedEventHandler(Dlg_FormClosing);
            dlg.ShowDialog();

        }

        private void Get_TodoList()
        {
            string sql = "select * from TODO_TB where TD_UR_FK = '" + db.UR_CD + "'";
            db.ExecuteReader(sql);
            int y = 75;
         //   Color color = randomColor();
            while (db.Reader.Read())
            {

                Label todoName = new Label();
                todoName.Text = db.Reader[1].ToString();
                todoName.AutoSize = true;
                todoName.Location = new System.Drawing.Point(35, y);
                todoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                panel1.Controls.Add(todoName);
                y += 20;

                if(!(db.Reader[2].ToString().Equals(System.DBNull.Value)))
                {
                    Label todoDate = new Label();
                    todoDate.Text = db.Reader[2].ToString();
                    todoDate.AutoSize = true;
                    todoDate.Location = new System.Drawing.Point(15, y);
                    todoDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    panel1.Controls.Add(todoDate);
                    y += 40;
                }

                Color color = dbc.GetColorInsertCRCD(db.Reader[4].ToString());
                Label todoColor = new Label();
                todoColor.Text = "●";
                todoColor.AutoSize = true;
                todoColor.Location = new System.Drawing.Point(10, todoName.Location.Y);
                todoColor.ForeColor = color;
                todoColor.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                panel1.Controls.Add(todoColor);

            }

        }

        private void 확인_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (day.Location.Y <= (340 + 70 - ((checkHeight+1)*100)))
            { // 최대일정깊이? * 110(일정하나의 크기) + 340(폼에서 한번에 보이는 크기) +(원래 위치)
            
                Down.Enabled = false;
            }
            day.Location = new Point(day.Location.X, day.Location.Y - 80);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Down.Enabled = true;
            Down.Visible = true;
            if (day.Location.Y == -10)
            {
                day.Location = new Point(day.Location.X, day.Location.Y + 80);
                button1.Enabled = false;   
            }
            else
            {
                day.Location = new Point(day.Location.X, day.Location.Y + 80);
            }
           
        }
        private void nextDay_Click(object sender, EventArgs e)
        {
            nowDate = nowDate.AddDays(1);
            m_focus_dt = nowDate;
            label1.Text = nowDate.ToString("yyyy년MM월dd일 ddd");
            day.Controls.Clear();
            checkHeight = 0;
            button1.Enabled = false;
            day.Controls.Clear();
            Get_chedule();
            Get_TodoList();
            if (checkHeight < 4)
            {
                button1.Visible = false;
                Down.Visible = false;
                button1.Enabled = false;
                Down.Enabled = false;
            }
            else
            {
                button1.Visible = true;
                Down.Visible = true;
                button1.Enabled = true;
                Down.Enabled = true;
            }
        }
        private void preDay_Click(object sender, EventArgs e)
        {
            nowDate = nowDate.AddDays(-1);
            m_focus_dt = nowDate;
            label1.Text = nowDate.ToString("yyyy년MM월dd일 ddd");
            day.Controls.Clear();
            checkHeight = 0;
            button1.Enabled = false;
            day.Controls.Clear();
            Get_chedule();
            Get_TodoList();
            if (checkHeight < 4)
            {
                button1.Visible = false;
                Down.Visible = false;
                button1.Enabled = false;
                Down.Enabled = false;
            }
            else
            {
                button1.Visible = true;
                Down.Visible = true;
                button1.Enabled = true;
                Down.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diary diary = new Diary(nowDate);
            diary.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose();
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

    }
}
