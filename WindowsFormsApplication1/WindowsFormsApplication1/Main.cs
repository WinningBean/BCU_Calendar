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

        //abcabc hello
        private void Main_Load(object sender, EventArgs e)
        {
            //UserName_txt.Text = db.UR_CD;
            Month mnt = new Month();
            mnt.MdiParent = this;
            mnt.Show();
        }
    }
}
