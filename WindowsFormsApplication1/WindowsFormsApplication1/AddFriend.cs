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
    public partial class AddFriend : Form
    {
        DBConnection db = Program.DB;

        public AddFriend()
        {
            InitializeComponent();
        }

        private void AddFriend_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel1.Visible = false;
            Get_GroupList();
        }

        private void Get_GroupList()
        {
            db.AdapterOpen("select FRGR_NM from FRIEND_GROUP_TB WHERE FRGR_UR_FK = '" + db.UR_CD + "' ORDER BY FRGR_NM DESC");
            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "friend_group_tb");
            DataTable friend_group_tb = ds.Tables["friend_group_tb"];

            for(int i =0; i<friend_group_tb.Rows.Count; i++ )
            {
                DataRow currRow;
                currRow = friend_group_tb.Rows[i];
                comboBox1.Items.Add(currRow["FRGR_NM"].ToString());
            }
        }
        

        private void 친구신청_Click(object sender, EventArgs e)
        {
            string command = "select * from USER_TB where UR_ID = '" + textBox1.Text + "'";
            db.ExecuteReader(command); 
            if (db.Reader.Read())
            {
                label1.Text = db.Reader["UR_NM"].ToString()+ "님이 맞습니까??";
                panel1.Enabled = true;
                panel1.Visible = true;
            }
            MessageBox.Show("존재하지 않는 아이디 입니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //db.Close();
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strFriendID = textBox1.Text;      
            string strGroup = comboBox1.Text;

            string command = "insert into USER_TB values('" + db.UR_CD + "', '" + strFriendID + "', '" + strGroup + "', 0 ) ";
            if (db.ExecuteNonQuery(command) < 1)
            {
                MessageBox.Show("데이터베이스 오류!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("친구 신청 보넸습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
