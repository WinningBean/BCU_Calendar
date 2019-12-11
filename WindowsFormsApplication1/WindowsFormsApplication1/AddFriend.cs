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
        DataTable friendTable = null;
        DataTable friend_group_tb = null;
        string strGroup;
        string strFriendID;

        public AddFriend()
        {
            InitializeComponent();
        }

        private void AddFriend_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel1.Visible = false;
            Get_GroupList();
            GetFriendsList();

            button1.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button3.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button2.MouseEnter += new EventHandler(OnTopPanMouseEnter);

            button1.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button3.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button2.MouseEnter += new EventHandler(OnTopPanMouseLeave);
        }

        private void Get_GroupList()
        {
            db.AdapterOpen("select FRGR_NM, FRGR_CD from FRIEND_GROUP_TB WHERE FRGR_UR_FK = '" + db.UR_CD + "' ORDER BY FRGR_NM DESC");
            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "friend_group_tb");
            friend_group_tb = ds.Tables["friend_group_tb"];

            for(int i =0; i<friend_group_tb.Rows.Count; i++ )
            {
                DataRow currRow;
                currRow = friend_group_tb.Rows[i];
                comboBox1.Items.Add(currRow["FRGR_NM"].ToString());
            }
        }
        private void GetFriendsList()
        {
            db.AdapterOpen("select  UR_NM ,UR_CD from USER_TB  WHERE ur_cd  in (select FR_FR_FK from FRIEND_TB where FR_UR_FK = '" + db.UR_CD + "') ORDER BY  UR_NM ASC");

            DataSet DS = new DataSet();
            db.Adapter.Fill(DS, "friend_tb");
            friendTable = DS.Tables["friend_tb"];

            //db.Close();
        }
        private bool check()
        {
            for (int i = 0; i < friendTable.Rows.Count; i++)
            {
                DataRow currRow = friendTable.Rows[i];
                if (db.Reader["UR_NM"].ToString().Equals(currRow["UR_NM"].ToString()))
                {
                   
                    return false;
                }
            }
            return true;
        }

        private void 친구신청_Click(object sender, EventArgs e)
        {
            string command = "select * from USER_TB where UR_ID = '" + textBox1.Text + "'";
            
            db.ExecuteReader(command);
   
            if(db.Reader.Read())
            {
                if (check())
                {
                    label2.Text = db.Reader["UR_NM"].ToString() + "님이 맞습니까??";
                    strFriendID = db.Reader["UR_CD"].ToString();
                    panel1.Enabled = true;
                    panel1.Visible = true;
                }
                else
                {
                    MessageBox.Show("이미 친구입니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("존재하지 않는 아이디 입니다 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //db.Close();               
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            for (int i =0; i<friend_group_tb.Rows.Count; i++)
            {
                DataRow currRow;
                currRow = friend_group_tb.Rows[i];
                if(currRow["FRGR_NM"].ToString().Equals(comboBox1.Text))
                {
                    strGroup = currRow["FRGR_CD"].ToString();
                }              
            }   

            string command = "insert into FRIEND_TB values('" + db.UR_CD + "', '" + strFriendID + "', '" + strGroup + "', 0 ) ";
            if (db.ExecuteNonQuery(command) < 1)
            {
                MessageBox.Show("데이터베이스 오류!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("친구 신청 보넸습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               panel1.Enabled = true;
                panel1.Visible = true;
                this.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}
