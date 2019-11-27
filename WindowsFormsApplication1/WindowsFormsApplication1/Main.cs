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
    public partial class Main : Form
    {
        DBConnection db = Program.DB;

        public Main()
        {
            InitializeComponent();
        }

        public string USERNAME
        {
            get { return UserName_txt.Text; }
            set { UserName_txt.Text = value; }
        }

        private void setCenterPanel() { // 센터패널 설정 함수 (월간, 주간 일정 폼 가져오기)
            Month mnt = new Month();
            mnt.TopLevel = false;
            mnt.TopMost = true;

            mnt.Parent = this;
            MainCenter_panel.Controls.Add(mnt);
            mnt.Location = new Point(0, 0);
            mnt.Show();
        }



        //abcabc hello
        private void Main_Load(object sender, EventArgs e)
        {
            //UserName_txt.Text = db.UR_CD;
            setCenterPanel();

            m_Today_lbl.Text = DateTime.Now.ToString("yyyy.MM.dd");
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
