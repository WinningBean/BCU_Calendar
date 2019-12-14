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
    public partial class Friend_Group_Modify : Form
    {
        DBConnection db = Program.DB;
        string CD;
        public Friend_Group_Modify(string CD)
        {
            InitializeComponent();
            this.CD = CD;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "update FRIEND_GROUP_TB set FRGR_NM = '" + textBox1.Text + "'";
            db.ExecuteNonQuery(sql);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("그룹이 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from FRIEND_GROUP_TB where SC_CD = '" + CD + "'";
                db.ExecuteNonQuery(sql);
                this.Close();
            }

        }

        private void Friend_Group_Modify_Load(object sender, EventArgs e)
        {
            string sql = "select * from FRIEND_GROUP_TB where FRGR_CD ='" + CD + "'";
            db.ExecuteReader(sql);
            if(db.Reader.Read())
            {
                textBox1.Text = db.Reader[1].ToString();

            }

            string command = "select * from FRIEND_TB where FR_UR_FK ='" + db.UR_CD + "' and FR_FRGR_FK ='" + CD + "' and FR_ACEP_ST = '1'";
            db.ExecuteReader(command);
            int i = 0;
            if (db.Reader.Read())
            {
                i++;
                while(db.Reader.Read())
                {
                    i++;
                }
            }
            label1.Text = i + "명";

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
