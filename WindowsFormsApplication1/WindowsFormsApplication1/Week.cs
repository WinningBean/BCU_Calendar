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
        List<Panel> time = null;
        List<List<Panel>> day = null;
        public Week()
        {
            InitializeComponent();
            time = new List<Panel>();
            day = new List<List<Panel>>();
            insideMain = new Panel();
            insideMain.Location = new Point(0, 0);
            insideMain.Size = new Size(966, 1512);
            insideMain.Show();
            m_Main_pan.Controls.Add(insideMain);
            m_Main_pan.VerticalScroll.Maximum = 0;
            m_Main_pan.VerticalScroll.Maximum = 0;
            m_Main_pan.VerticalScroll.Visible = false;
            m_Main_pan.AutoScroll = true;


            
            makeTop();
            makeTime();
            makeDay();
        }

        private void makeTime()
        {
            int y = 0;
            for (int i = 0; i < 24; i++)
            {
                Panel pan = new Panel();
                pan.Size = new Size(91, 63); // 125
                pan.Location = new Point(0, y);
                pan.BorderStyle = BorderStyle.FixedSingle;
                pan.BackColor = Color.Red;
                y += 63;
                pan.Show();
                insideMain.Controls.Add(pan);
                time.Add(pan);
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
                pan.BackColor = Color.Pink;
                pan.BorderStyle = BorderStyle.FixedSingle;

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
                    pan.BackColor = Color.Orange;
                    pan.BorderStyle = BorderStyle.FixedSingle;
                    y += 63;
                    pan.Show();
                    insideMain.Controls.Add(pan);
                    day[j].Add(pan);
                }
                x += 125;
            }
        }
        //가로 : 2400 : 100
        // 세로 : 1800 : 75
    }

}
