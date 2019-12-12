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
    public partial class FriendModify : Form
    {
        DataRow curr;
        DataTable friendGoup;
        DBConnection db = Program.DB;
        Point point;
        public FriendModify(DataRow dr,DataTable dt, Point point)
        {
            InitializeComponent();
            this.curr = dr;
            this.point = point;
            this.friendGoup = dt;
        }


        private void FriendModify_Load(object sender, EventArgs e)
        {
            this.Location = point;
            nameLabel.Text = curr["UR_NM"].ToString();
            button4.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button5.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button4.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button5.MouseEnter += new EventHandler(OnTopPanMouseEnter);
        }

        private void OnTopPanMouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.SlateGray;
        }

        private void OnTopPanMouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("w친구가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from SCHEDULE_TB where SC_CD = '" + curr["UR_CD"].ToString() + "'";
                db.ExecuteNonQuery(sql);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
