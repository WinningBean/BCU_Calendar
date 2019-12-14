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

        DBConnection db = Program.DB;
        DataTable friendTable = null;
        DataTable friend_group_tb = null;
        string strGroup;
        string strFriendID = null;

        public AddFriend()
        {
            InitializeComponent();
        }

        private void AddFriend_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel1.Visible = false;
            comboBox1.Text = "기본그룹";
            Get_GroupList();
            GetFriendsList();

            panel1.Controls.Add(dataGrid1);
            dataGrid1.BringToFront();
            button1.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button2.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button1.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button2.MouseEnter += new EventHandler(OnTopPanMouseLeave);
        }

        private void Get_GroupList()
        {
            db.AdapterOpen("select FRGR_NM, FRGR_CD from FRIEND_GROUP_TB WHERE FRGR_UR_FK = '" + db.UR_CD + "' ORDER BY FRGR_NM DESC");
            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "friend_group_tb");
            friend_group_tb = ds.Tables["friend_group_tb"];

            comboBox1.Items.Add("기본그룹");
            for (int i =0; i<friend_group_tb.Rows.Count; i++ )
            {
                DataRow currRow;
                currRow = friend_group_tb.Rows[i];
                comboBox1.Items.Add(currRow["FRGR_NM"].ToString());
            }
           
        }
        private void GetFriendsList()
        {
            db.AdapterOpen("select  UR_NM ,UR_CD, UR_ID from USER_TB  WHERE ur_cd  in (select FR_FR_FK from FRIEND_TB where FR_UR_FK = '" + db.UR_CD + "'and FR_ACEP_ST = '1') ORDER BY  UR_NM ASC");

            DataSet DS = new DataSet();
            db.Adapter.Fill(DS, "friend_tb");
            friendTable = DS.Tables["friend_tb"];
            friendTable.PrimaryKey = new DataColumn[] { friendTable.Columns["UR_CD"] };

            //db.Close();
        }
        private bool check(string id)
        {
                //DataRow currRow = ;

                if (friendTable.Rows.Find(id) != null)
                {
                   
                    return false;
                }

            return true;
        }

        private void 친구신청_Click(object sender, EventArgs e)
        {
            string command = "select UR_ID,UR_NM from USER_TB where UR_ID = '" + textBox1.Text + "' or UR_NM = '" + textBox1.Text + "'";
            db.AdapterOpen(command);

            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "search_tb");
                       
            int count = ds.Tables["search_tb"].Rows.Count;
            if (count == 0)
            {
                dataGrid1.DataSource = ds;
                dataGrid1.Refresh();
                MessageBox.Show("검색 데이터가 없습니다", "확인");
            }
            else
            {
                DataTable dataTable = ds.Tables["search_tb"];
                panel1.Enabled = true;
                panel1.Visible = true;
                dataGrid1.DataSource = dataTable;
                dataGrid1.Columns[1].HeaderText = "이름";
                dataGrid1.Columns[0].HeaderText = "아이디";

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(strFriendID == null || strFriendID == "아이디를 선택해주세요!!")
            {
                MessageBox.Show("유저를 선택해주세요 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(comboBox1.Text == "")
            {
                MessageBox.Show("그룹을 선택해 주세요 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox1.Text.Equals("기본그룹") )
            {
                strGroup = null;
            }
            else
            {
                for (int i = 0; i < friend_group_tb.Rows.Count; i++)
                {
                    DataRow currRow;
                    currRow = friend_group_tb.Rows[i];
                    if (currRow["FRGR_NM"].ToString().Equals(comboBox1.Text))
                    {
                        strGroup = currRow["FRGR_CD"].ToString();
                    }
                }
            }
            

            string command = "insert into FRIEND_TB values('" + db.UR_CD + "', '" + strFriendID + "', '" + strGroup + "', 0 ) ";
            db.ExecuteNonQuery(command);
            
 
                MessageBox.Show("친구 신청 보넸습니다", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               panel1.Enabled = true;
                panel1.Visible = true;
                this.Close();
            

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

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e) //그리드뷰에서 리스트 선택시
        {
            if (dataGrid1.SelectedCells.Count > 0)
            {
                strFriendID = dataGrid1.SelectedCells[0].Value.ToString();

                for(int i = 0; i< friendTable.Rows.Count; i++)
                {
                    DataRow currRow;
                    currRow = friendTable.Rows[i];
                    if (currRow["UR_ID"].ToString().Equals(strFriendID))
                    {
                        MessageBox.Show("이미 친구 입니다", "확인");
                        dataGrid1.Refresh();
                        strFriendID = "아이디를 선택해주세요";
                        return;
                    }
                  

                }

               label5.Text = strFriendID;
               string sql = "select UR_CD from USER_TB where UR_ID = '" + strFriendID + "'";
               db.ExecuteReader(sql);
               if (db.Reader.Read())
               {
                    strFriendID = db.Reader[0].ToString();
                    
                    string command = "select FR_ACEP_ST from FRIEND_TB where FR_UR_FK = '" + db.UR_CD + "' and FR_FR_FK= '" + strFriendID + "'";
                    db.ExecuteReader(command);
                    if (db.Reader.Read())
                    {
                       if(Convert.ToInt32(db.Reader[0]) == 0)
                       {
                           MessageBox.Show("이미친구친청 보넨 유저입니다.", "확인");
                            label5.Text = "아이디를 선택해주세요!!";
                            strFriendID = null;
                          return;
                       }
 
                    }


               }
 

 
            }
        }

        private void line_3_Click(object sender, EventArgs e)
        {

        }
    }
}
