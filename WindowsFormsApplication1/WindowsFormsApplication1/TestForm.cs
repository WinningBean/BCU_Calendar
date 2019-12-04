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
    public partial class TestForm : Form
    {
        DBConnection db = Program.DB;
        DBSchedule sche_db = new DBSchedule();
        DataSet DS = new DataSet();
        DataTable DT = new DataTable();

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Parse("2019-11-13 00:00:00");
            DT = sche_db.Get_Day_Schedule("U",db.UR_CD, now);
            dataGridView1.DataSource = DT;
        }
    }
}
