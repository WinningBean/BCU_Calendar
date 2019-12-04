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
    public partial class Day : Form
    {
        DBConnection db = Program.DB;
        Panel paintPan = new Panel();

        DataTable pictureTb = null;
        List<Panel> time = null;

        private int m_thisYear;
        private int m_thisMonth; 
        private int m_thisDay; 
        private int m_thisDayOfWeek; // Day From 이 열릴떄 Month에서 받아옴 

        public Day()
        {
            InitializeComponent();
            time = new List<Panel>();
        }

        
        private void Draw_Line(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int x = 10;
            int y = 60;
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < 25; i++)
            {
                Panel pan = new Panel();
                graphics.DrawLine(pen, x, 0, x, 60);
                x += 150;
            }
        }

        private void Day_Load(object sender, EventArgs e)
        {
            
            paintPan.Location = new Point(0, 0);
            paintPan.Size = new Size(3640, 355);
            paintPan.Show();
            paintPan.Paint += new System.Windows.Forms.PaintEventHandler(Draw_Line);
            // paintPan.BackColor = Color.Transparent;
            panel2.Controls.Add(paintPan);

            Draw_Time();
            panel2.VerticalScroll.Maximum = 0;
            panel2.HorizontalScroll.Maximum = 0;
            panel2.VerticalScroll.Visible = false;
            panel2.AutoScroll = true;

            //panel2.Paint += new System.Windows.Forms.PaintEventHandler(Draw_Line);

        }
        private void Draw_Time()
        {
           
                int x = 1;
            for (int i = 0; i < 25; i++)
            {
                Label timeLable = new Label();
                timeLable.Text = (i).ToString();


                timeLable.AutoSize = true;
                timeLable.Location = new Point(x, 70);

                //pan.BorderStyle = BorderStyle.FixedSingle;

                timeLable.TextAlign = ContentAlignment.TopRight;
                timeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                timeLable.ForeColor = Color.Black;
                x += 150;
                timeLable.Show();
                paintPan.Controls.Add(timeLable);

            }
            }

        private void Get_Schedule() //DB 에서 날짜에 해당하는 스케줄을 가져온다 
        {
            //string sql = "select * from SCHEDULE_TB";
            //       sql += " where SC_UR_FK = 'U100000'"; 
            //       sql += " and SC_STR_DT >= '2019-11-29'";
            //       sql += " and SC_STR_DT < '2019-11-30'";
            //        sql += "ORDER BY SC_STR_DT DESC";

            //       db.ExecuteReader(sql); 

            //  if(db.Reader.Read())
            //  {

            //  }
        }
        private void Get_Picture() //DB 에서 날짜에 해당하는 사진을 가져온다 
        {
            //string  sql = "select PIC_DATA from PICTURE_TB";
            //        sql +=" where SC_UR_FK = 'U100000'"; 
            //        sql += "and PIC_DT >= '2019-11-29'";
            //        sql += " and PIC_DT < '2019-11-30'";

            //db.AdapterOpen(sql);
            //DataSet ds = new DataSet();
            //db.Adapter.Fill(ds, "pictureTb");
            //pictureTb = ds.Tables["pictureTb"];
        }
        private void Create_Picure(int location, Image img)
        {
            PictureBox pictureBox = new PictureBox();
            panel2.Controls.Add(pictureBox); 

    
        }

        private void 확인_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
