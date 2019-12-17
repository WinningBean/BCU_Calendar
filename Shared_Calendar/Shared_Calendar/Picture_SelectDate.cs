using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared_Calendar
{
    public partial class Picture_SelectDate : Form
    {

        #region 폼 그림자 생성
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

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

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
