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
    public partial class Picture_SelectDate : Form
    {
        public DateTime dt;
        public Picture_SelectDate()
        {
            InitializeComponent();
            dt = monthCalendar1.TodayDate;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dt = monthCalendar1.SelectionStart;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
