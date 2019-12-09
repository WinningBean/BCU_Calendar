﻿using System;
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
        DBSchedule dbs = new DBSchedule();
        Panel paintPan = new Panel();
      
        Panel day = new Panel();
        Panel pre = new Panel();
        DataTable GET_DAY_SC_TB = null;

        int checkHeight = 0;
        int[,] location = new int[10,2];

        DateTime nowDate; // 생성자에 넣어서 월간에서 넘겨 받는다

        private bool dragging = false;
        private Point offset;

        public Day(DateTime nowDate)//DateTime date
        {
            InitializeComponent();
            pre = null;
            this.nowDate = nowDate;

        }
        public enum color
        {
            Green, Yellow, Orange, Mint, Gray
        };
        
        private void Get_chedule()
        {
            db.UR_CD = "U100000";
            GET_DAY_SC_TB = dbs.Get_Day_Schedule(true, "U100000", nowDate);

            for (int i = 0; i < GET_DAY_SC_TB.Rows.Count; i++)
            {   
                DataRow currRow = GET_DAY_SC_TB.Rows[i];
                Create_Day(currRow, i);
            }
           // dt.Clear();
        }

        private void Check(Panel curr, Label name, Label color)
        {
            if (location[curr.TabIndex,1] != 0)
            {

                if (location[curr.TabIndex,0] == curr.Left || location[curr.TabIndex,1] > curr.Left)
                {
                    curr.Location = new Point(curr.Location.X, curr.Location.Y + 120);
                    name.Location = new Point(name.Location.X, name.Location.Y + 120);
                    color.Location = new Point(color.Location.X, color.Location.Y + 120);
                    curr.TabIndex++;
                    Check(curr, name, color);

                }
                else
                {
                    location[curr.TabIndex,0] = curr.Left;
                    location[curr.TabIndex,1] = curr.Right;
                }
            }
            else
            {
                location[curr.TabIndex,0] = curr.Left;
                location[curr.TabIndex,1] = curr.Right;

                if (pre.TabIndex < curr.TabIndex)
                {
                    checkHeight = curr.TabIndex;
                }
               
            }
            pre = curr;
        }

        private void Create_Day(DataRow dr, int i)
        {
            int y = 0;
            
            Color color = randomColor();
            DateTime strSC = Convert.ToDateTime(dr[4].ToString()); 
            DateTime endSC = Convert.ToDateTime(dr[5].ToString());

            int scheduleTimeSize;

            if (endSC.Hour == 0)
            {
                scheduleTimeSize = (24 * 120 + endSC.Minute * 2) - (strSC.Hour * 120 + strSC.Minute * 2);
            }
            else
            {
               scheduleTimeSize = (endSC.Hour * 120 + endSC.Minute * 2) - (strSC.Hour * 120 + strSC.Minute * 2);
            }
            

            Panel cre = new Panel();
            cre.Size = new Size(scheduleTimeSize,80);
            cre.Location = new Point(strSC.Hour * 120 + strSC.Minute * 2 + 10, y);
           // cre.BorderStyle = BorderStyle.FixedSingle;
            cre.TabIndex = 0;
            cre.Tag = i;
            cre.BackColor = color;
           // cre.Click += new EventHandler(Schedule_Click);


            Label scheduleNameColor = new Label();
            scheduleNameColor.ForeColor = color;
            scheduleNameColor.Text = "●";
            scheduleNameColor.Size = new Size(30, 30);
            scheduleNameColor.Location = new Point(cre.Location.X, cre.Location.Y + 80);
            scheduleNameColor.Font=new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            Label scheduleName = new Label();
            scheduleName.Text = dr[1].ToString();
            scheduleName.Size = new Size(scheduleTimeSize - 30, 30);
            scheduleName.Location = new Point(scheduleNameColor.Location.X + 30, scheduleNameColor.Location.Y);
            scheduleName.Font = new System.Drawing.Font("함초롬돋움",12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            Label label = new Label();
            label.Text = dr[2].ToString();
            label.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label.Size = new Size(scheduleTimeSize, 80);
            label.TabIndex = i;
            label.Click += new EventHandler(Label_Click);

            if (!(dr[6].ToString().Equals(System.DBNull.Value)) && cre.Size.Width > 119)
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

                    if (cre.Size.Width == 120)
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

        private Color randomColor() // 색을 랜덤으로 만들어줌
        {
            Random r = new Random();
            color c = (color)(r.Next() % 5);
            return SelectColor(c);
        }
        private Color SelectColor(color c) // 지정한 색을 리턴
        {
            switch (c)
            {
                case color.Green: // 투명도 0 ~ 255
                    return Color.FromArgb(100, 85, 239, 196);// green
                case color.Yellow:
                    return Color.FromArgb(100, 253, 203, 110); // yellow
                case color.Orange:
                    return Color.FromArgb(100, 225, 112, 85); //orange
                case color.Mint:
                    return Color.FromArgb(100, 129, 236, 236); //mint
                case color.Gray:
                    return Color.FromArgb(100, 178, 190, 195); // gray
            }
            return Color.FromArgb(50, 0, 255, 0); // 기본 컬러
        }

        private void Draw_Line(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int x = 10;
            int y = 70;
            //int y = 60;
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < 25; i++)
            {
                Panel pan = new Panel();
                graphics.DrawLine(pen, x, 0, x, 30);
                x += 120;
               // paintPan.Controls.Add(pan);
            }
            for (int i = 0; i < 25; i++)
            {
                Panel pan = new Panel();
                graphics.DrawLine(pen, y, 0, y, 15);
                y += 120;
               // paintPan.Controls.Add(pan);
            }
        
        }
        private void Draw_Time()
        {
            int x = 1;
            for (int i = 0; i < 25; i++)
            {
                Label timeLable = new Label();
                timeLable.Text = (i).ToString();


                timeLable.AutoSize = true;
                timeLable.Location = new Point(x, 40);

                //pan.BorderStyle = BorderStyle.FixedSingle;

                timeLable.TextAlign = ContentAlignment.TopRight;
                timeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                timeLable.ForeColor = Color.Black;
                x += 120;
                timeLable.Show();
                paintPan.Controls.Add(timeLable);

            }
        }
        private void Day_Load(object sender, EventArgs e)
        {
            label1.Text = nowDate.ToString("yyyy년mm월dd일 ddd"); 
            day.AutoSize = true;
            day.AutoScroll = false;
            day.Location = new Point(0, 70);


            paintPan.Location = new Point(0, 0);
            paintPan.Size = new Size(2910, 70);
            paintPan.Show();
            paintPan.Paint += new System.Windows.Forms.PaintEventHandler(Draw_Line);
            paintPan.BackColor = Color.Transparent;

            panel2.Controls.Add(paintPan);
            panel2.Controls.Add(day);
            panel2.Size = new Size(595, 810);

            Draw_Time();
            panel2.VerticalScroll.Maximum = 0;
            panel2.HorizontalScroll.Maximum = 0;
            panel2.VerticalScroll.Visible = false;
            panel2.VerticalScroll.Enabled = true;
            panel2.AutoScroll = true;


            button1.Enabled = false;

            Get_chedule();
            Get_TodoList();
           

        }
       

        private void Label_Click(object render, EventArgs e)
        {
            Label myPan = (Label)render;
            int i = myPan.TabIndex;
            DataRow curr = GET_DAY_SC_TB.Rows[i];
            DateTime strSC = Convert.ToDateTime(curr[4].ToString());
            DateTime endSC = Convert.ToDateTime(curr[5].ToString());

            ModifySchedule dlg = new ModifySchedule();
            dlg.NameTxt = curr["SC_NM"].ToString();
            dlg.ExTxt = curr["SC_EX"].ToString();
            dlg.StrDate = (DateTime)curr["SC_STR_DT"];
            dlg.EndDate = (DateTime)curr["SC_END_DT"];
            dlg.StrHour = strSC.Hour.ToString();
            dlg.StrMin = strSC.Minute.ToString();
            dlg.EndHour = endSC.Hour.ToString();
            dlg.EndMin = endSC.Minute.ToString();
            // dlg.StateCheck = Convert.ToInt32( curr["SC_PB_ST"]);

            string sql = "select * from PICTURE_TB where PIC_CD = '" + curr["SC_PIC_FK"].ToString() + "'";
            db.ExecuteReader(sql);
            if (db.Reader.Read())
            {
                Byte[] b = (Byte[])(db.Reader["PIC_DATA"]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);
              
                dlg.ImagePic = img;
            }
            else
            {
                dlg.ImagePic = null;
            }

            dlg.ShowDialog();

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    label1.Left = dlg.LabelX;
            //    label1.Top = dlg.LabelY;
            //    label1.Text = dlg.LabelText;
            //}
            dlg.Dispose();

        }
        private void PictureBox_Click(object render, EventArgs e)
        {
            PictureBox myPic = (PictureBox)render;
            int i = myPic.TabIndex;
            DataRow curr = GET_DAY_SC_TB.Rows[i];
            DateTime strSC = Convert.ToDateTime(curr[4].ToString());
            DateTime endSC = Convert.ToDateTime(curr[5].ToString());

            ModifySchedule dlg = new ModifySchedule();
            dlg.NameTxt = curr["SC_NM"].ToString();
            dlg.ExTxt = curr["SC_EX"].ToString();
            dlg.StrDate = strSC;
            dlg.EndDate = endSC;
            dlg.StrHour = strSC.Hour.ToString();
            dlg.StrMin = strSC.Minute.ToString();
            dlg.EndHour = endSC.Hour.ToString();
            dlg.EndMin = endSC.Minute.ToString();

            //dlg.StateCheck = true;

            string sql = "select * from PICTURE_TB where PIC_CD = '" + curr["SC_PIC_FK"].ToString() + "'";
            db.ExecuteReader(sql);
            if (db.Reader.Read())
            {
                Byte[] b = (Byte[])(db.Reader["PIC_DATA"]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);

                dlg.ImagePic = img;
            }
            else
            {
                dlg.ImagePic = null;
            }

            dlg.ShowDialog();

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    label1.Left = dlg.LabelX;
            //    label1.Top = dlg.LabelY;
            //    label1.Text = dlg.LabelText;
            //}
            dlg.Dispose();

        }

        private void Get_TodoList()
        {
            string sql = "select * from TODO_TB where TD_UR_FK = '" + db.UR_CD + "'";
            db.ExecuteReader(sql);
            int y = 75;
            Color color = randomColor();
            while (db.Reader.Read())
            {
                Label todoColor = new Label();
                todoColor.Text = "●";
                todoColor.AutoSize = true;
                todoColor.Location = new Point(10, y);
                todoColor.ForeColor = color;
                todoColor.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                panel1.Controls.Add(todoColor);
                

                Label todoName = new Label();
                todoName.Text = db.Reader["TD_EX"].ToString();
                todoName.AutoSize = true;
                todoName.Location = new Point(35, y);
                todoName.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                panel1.Controls.Add(todoName);
                y += 20;

                if(!(db.Reader["TD_DT"].ToString().Equals(System.DBNull.Value)))
                {
                    Label todoDate = new Label();
                    todoDate.Text = db.Reader["TD_DT"].ToString();
                    todoDate.AutoSize = true;
                    todoDate.Location = new Point(15, y);
                    todoDate.Font = new System.Drawing.Font("함초롬돋움", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    panel1.Controls.Add(todoDate);
                    y += 40;
                }


            }

        }
    

        private void 확인_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (day.Location.Y < - (checkHeight+1)*110+340+80)
            { // 최대일정깊이? * 110(일정하나의 크기) + 340(폼에서 한번에 보이는 크기) +(원래 위치)
            
                Down.Enabled = false;
            }
            day.Location = new Point(day.Location.X, day.Location.Y - 80);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Down.Enabled = true;
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

  
    }
}
