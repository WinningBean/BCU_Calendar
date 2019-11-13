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
        public Main()
        {
            InitializeComponent();
        }
        //abc
        private void Main_Load(object sender, EventArgs e)
        {
            Month mnt = new Month();
            mnt.MdiParent = this;
            mnt.Show();
        }
    }
}
