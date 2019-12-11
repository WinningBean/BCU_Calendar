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
    public partial class FriendSearch : Form
    {
        DataTable dataTable;
        public FriendSearch(DataTable dataTable)
        {
            InitializeComponent();
            this.dataTable = dataTable;
            dataGridView1.DataSource = dataTable.DefaultView;
           // 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }
    }
}
