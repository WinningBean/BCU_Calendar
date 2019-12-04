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
    public partial class Week : Form
    {
        Panel insideMain = null;
        List<List<Panel>> day = null;

        DBSchedule dbs = new DBSchedule();
        DBConnection db = Program.DB;
        DateTime today;
        public Week()
        {
            InitializeComponent();
            day = new List<List<Panel>>(); // 각 시간마다 생성된 패널 (ex: day[1][7] -> 월요일 8 AM)
            insideMain = new Panel();
            insideMain.Location = new Point(0, 0);
            insideMain.Size = new Size(966, 1512);
            insideMain.Show();
            insideMain.Paint += new System.Windows.Forms.PaintEventHandler(OnMainPaint);
            insideMain.BackColor = Color.Transparent;
            m_Main_pan.Controls.Add(insideMain);

            m_Main_pan.VerticalScroll.Maximum = 0;
            m_Main_pan.VerticalScroll.Maximum = 0;
            m_Main_pan.VerticalScroll.Visible = false;
            m_Main_pan.AutoScroll = true;

            m_Top_pan.Paint += new System.Windows.Forms.PaintEventHandler(OnTopPaint);

            makeTop();


            makeTime();

            makeDay();


            for (int i = 0; i < 7; i++)
                statusSC.Add(new List<Panel>());

            insideMain.Controls.Add(label1);
        }

        #region Week Form Designe
        // 폼 디자인에 사용한 코드


        private void OnTopPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int x = 125;
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.LightGray);
            for (int i = 0; i < 6; i++)
            {
                graphics.DrawLine(pen, x, 0, x, 63);
                x += 125;
            }
            graphics.Dispose();
        }

        private void OnMainPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int x = 91;
            int y = 0;
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.LightGray);
            for (int i = 0; i < 24; i++)
            {
                graphics.DrawLine(pen, x, y, 956, y);
                y += 63;
            }
            x = 216;
            for (int i = 0; i < 6; i++)
            {
                graphics.DrawLine(pen, x, 5, x, 1507);
                x += 125;
            }
            graphics.Dispose();
        }

        private void makeTime()
        {
            int y = -11;
            for (int i = 0; i < 25; i++)
            {
                Label pan = new Label();

                if (i < 12)
                    pan.Text = i.ToString() + " AM";
                else if (i > 12 && i < 24)
                {
                    pan.Text = (i % 12).ToString() + " PM";
                }
                else if (i == 12)
                    pan.Text = "Noon";
                else
                    pan.Text = "0 AM";


                pan.Size = new Size(91, 63); // 125
                pan.Location = new Point(0, y);
                //pan.BorderStyle = BorderStyle.FixedSingle;

                pan.TextAlign = ContentAlignment.TopRight;
                pan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                pan.ForeColor = Color.DimGray;
                y += 63;
                pan.Show();
                insideMain.Controls.Add(pan);
            }

        }

        private void makeTop()
        {
            int x = 0;
            String[] dayEnum = { "Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat" };

            for (int j = 0; j < 7; j++)
            {
                Panel pan = new Panel();
                pan.Size = new Size(125, 63);
                pan.Location = new Point(x, 0);
                pan.BackColor = Color.Transparent;

                Label day = new Label();
                day.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                day.AutoSize = true;
                day.Location = new Point(60, 30);
                day.Text = dayEnum[j];
                pan.Controls.Add(day);
                m_Top_pan.Controls.Add(pan);
                x += 125;
            }
        }

        private void makeDay()
        {
            int x = 91;
            for (int j = 0; j < 7; j++)
            {
                int y = 0;
                day.Add(new List<Panel>());
                for (int i = 0; i < 24; i++)
                {
                    Panel pan = new Panel();
                    pan.Size = new Size(125, 63);
                    pan.Location = new Point(x, y);
                    pan.Visible = false;
                    //pan.BorderStyle = BorderStyle.Fixed3D;
                    y += 63;
                    //pan.Show();
                    insideMain.Controls.Add(pan);
                    day[j].Add(pan);
                }
                x += 125;
            }
            day[4][7].BackColor = Color.Tan;
        }

        #endregion

        private void Week_Load(object sender, EventArgs e)
        {
            m_Main_pan.AutoScrollPosition = new Point(0, 505); // 휠 포지션을 가운데로 설정
            
        }

        private void CurrWeek()
        {
            //현재시간을 년 월 일로 나눔
            int currYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            int currMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currDay = Int32.Parse(DateTime.Now.ToString("dd"));
            today = new DateTime(currYear, currMonth, currDay);

            int weekCount; // 몇주차인지 확인하는 카운트
            DateTime weekSunday = new DateTime(); // 그 주차에 일요일을 구함

            if (new DateTime(currYear, currMonth, 1).DayOfWeek == DayOfWeek.Sunday)
                weekCount = -1;  // 주차를 구할때 첫일이 일요일이면 첫주차가 0이 아닌 1이 되므로 -1로 정의
            else
                weekCount = 0;//5 7 8 11 12 14 


            for (int i = 1; i <= currDay; i++) // 1일부터 현재날까지 돌면서 몇주차인지를 구함
            {
                if (new DateTime(currYear, currMonth, i).DayOfWeek == DayOfWeek.Sunday)
                {
                    weekSunday = new DateTime(currYear, currMonth, i);
                    weekCount++;
                }
            }
            createWeek(weekSunday);
        }

        private void createWeek(DateTime weekSunday)
        {
            if (weekSunday.Year != 1) // 일주일이 온전하게 있을경우
            {
                for (int i = 0; i < 7; i++)
                {
                    DataTable dt = dbs.Get_Day_Schedule(true,"U100000", weekSunday.AddDays(i));
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        DataRow dr = dt.Rows[k];
                        CreateSCPan(ref dr, i);
                        //MessageBox.Show(i.ToString() + " : " + Convert.ToDateTime(dr[4].ToString()).Hour.ToString());
                    }
                    dt.Clear();
                }
            }
            else
            {
                for (DayOfWeek i = today.DayOfWeek; i <= DayOfWeek.Saturday; i++)
                {
                    MessageBox.Show(i.ToString());
                }
            }
        }

        public enum color
        {
            Green, Yellow, Orange, Mint, Gray
        };

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
        List<List<Panel>> statusSC = new List<List<Panel>>();

        public void CreateSCPan(ref DataRow dr, int i) // DataRow를 읽고 색을 입혀줌
        {
            MessageBox.Show(dr[1].ToString());
            DateTime beginSC = Convert.ToDateTime(dr[4].ToString()); // 시작일
            DateTime endSC = Convert.ToDateTime(dr[5].ToString()); // 종료일

            Panel beginPosition = day[Convert.ToInt32(beginSC.DayOfWeek)][beginSC.Hour];
            Panel endPosition = day[Convert.ToInt32(endSC.DayOfWeek)][endSC.Hour + 1];

            Panel cre = new Panel();
            cre.Size = new Size(beginPosition.Size.Width, endPosition.Location.Y - beginPosition.Location.Y);
            cre.Location = beginPosition.Location;
            cre.BorderStyle = BorderStyle.FixedSingle;
            cre.BackColor = randomColor();
            Label lb = CreateSCText(ref dr);
            lb.Text = dr[1].ToString();

            cre.Controls.Add(lb);
            if (statusSC[i].Any()) // 리스트에 엘리먼트가 있는지 확인
            {
                for (int k = 0; k < statusSC[i].Count; k++)
                {
                    if (statusSC[i][k].Top <= cre.Top && statusSC[i][k].Bottom >= cre.Bottom)
                    { // 자기가 완전히 안에 들어가면
                        if (statusSC[i][k].Top == cre.Top) // 만약 시작일도 곂쳐버리면 안에 들어가는 텍스트를 내림
                            cre.Controls[0].Location = new Point(10, cre.Controls[0].Location.Y + 30);
                        cre.Location = new Point(0, cre.Top - statusSC[i][k].Top);
                        statusSC[i][k].Controls.Add(cre);
                        statusSC[i].Add(cre);
                        return;
                    }
                    else if(statusSC[i][k].Top <= cre.Top && statusSC[i][k].Bottom < cre.Bottom)
                    { // 윗부분 들어가고 아랫부분 나올경우
                        if (statusSC[i][k].Top == cre.Top) // 만약 시작일도 곂쳐버리면 안에 들어가는 텍스트를 내림
                            cre.Controls[0].Location = new Point(10, cre.Controls[0].Location.Y + 30);
                        Panel plus = new Panel();
                        plus.Location = new Point(statusSC[i][k].Location.X, statusSC[i][k].Bottom);
                        plus.Size = new Size(cre.Size.Width, cre.Bottom - statusSC[i][k].Bottom);
                        plus.BackColor = cre.BackColor;
                        plus.BorderStyle = BorderStyle.FixedSingle;

                        cre.Location = new Point(0, cre.Top - statusSC[i][k].Top);
                        cre.Size = new Size(cre.Size.Width, statusSC[i][k].Bottom - cre.Top);

                        statusSC[i][k].Controls.Add(cre);
                        insideMain.Controls.Add(plus);
                        statusSC[i].Add(plus);
                        return;
                    }
                }
            }
            statusSC[i].Add(cre);
            insideMain.Controls.Add(cre);
        }

        private Label CreateSCText(ref DataRow dr)
        {
            Label txt = new Label();
            txt.TextAlign = ContentAlignment.TopLeft;
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt.Location = new Point(10, 10);
            txt.AutoSize = true; // this.label1.Size = new System.Drawing.Size(46, 18);
            //txt.BackColor = Color.Transparent; // 안한게 더 예쁜데?

            return txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrWeek();
        }
    }
}
