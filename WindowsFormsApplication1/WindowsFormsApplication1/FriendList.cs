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
    public partial class FriendList : Form
    {
        DBConnection db = Program.DB;
        DataTable friendTable = null;
        DataTable friend_group_tb = null;

        Panel[] pan;
        Label[] label;
        Button[] btn;

        int location;
        int[] flag;

        public FriendList()
        {
            InitializeComponent();
            location = 0;
        }

        private Control Create_FriendProfile(int i, DataTable dataTable)
        {
            DataRow currRow = dataTable.Rows[i];
            UserCustomControl.Profile FriendProfile = new UserCustomControl.Profile();          
            FriendProfile.Set_Profile_Size(30, FontStyle.Bold);
            FriendProfile.USERNAME = currRow["UR_NM"].ToString();
            FriendProfile.Location = new System.Drawing.Point(0, 10 + location * 30);
            FriendProfile.Size = new System.Drawing.Size(150, 25);

            location++; // 전역

            return FriendProfile;
        }

        private void UploadeList()
        {
            flag = new int[friendTable.Rows.Count + 1];
            label = new Label[friendTable.Rows.Count];
            btn = new Button[friend_group_tb.Rows.Count + 1];
            pan = new Panel[friend_group_tb.Rows.Count + 1];

            //기본적으로 생성해주는 모든친구 버튼과 목록이 저장되는 판넬 생성 
            btn[0] = new Button();
            btn[0].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btn[0].Location = new System.Drawing.Point(20, 10);
            btn[0].Name = "btn";
            btn[0].TabIndex = 0;
            btn[0].Size = new System.Drawing.Size(130, 32);
            btn[0].Text = "기본그룹    ▲";
            btn[0].Click += new EventHandler(GroupList_Click);
            panel1.Controls.Add(btn[0]);
            flag[0] = 1;

            pan[0] = new Panel();
            pan[0].AutoSize = true;
            pan[0].Location = new Point(btn[0].Location.X, btn[0].Location.Y + 30);
           
            panel1.Controls.Add(pan[0]);

            for (int i = 0; i < friendTable.Rows.Count; i++)
            {             
                pan[0].Controls.Add(Create_FriendProfile(i , friendTable));
            }

            for (int i = 0; i < friend_group_tb.Rows.Count; i++) // ***CreateGroupButton 함수로 뺄까...? // 그룹추가 할떄 
            {
                DataRow currRow;
                currRow = friend_group_tb.Rows[i];
                btn[i + 1] = new Button();
                btn[i + 1].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btn[i + 1].Location = new System.Drawing.Point(20, 45 + location * 30);
                btn[i + 1].Name = "btn" + i.ToString();
                btn[i + 1].Size = new System.Drawing.Size(130, 32);
                btn[i + 1].TabIndex = i+1;
                btn[i + 1].Text = currRow["FRGR_NM"].ToString() + "       ▼";
                btn[i + 1].Click += new EventHandler(GroupList_Click);
                panel1.Controls.Add(btn[i + 1]);

                location++;
                flag[i + 1] = 0;
            }

        }
        private void GetFriendsList()
        {
            db.UR_CD = "U100000";
            db.AdapterOpen("select  UR_NM ,UR_CD from USER_TB  WHERE ur_cd  in (select FR_FR_FK from FRIEND_TB where FR_UR_FK = '" + db.UR_CD + "') ORDER BY  UR_NM ASC");

            DataSet DS = new DataSet();
            db.Adapter.Fill(DS, "friend_tb");
            friendTable = DS.Tables["friend_tb"];

            db.Close();
        }

        private void FriendList_Load(object sender, EventArgs e)
        {
            panel1.HorizontalScroll.Maximum = 0;
            panel1.VerticalScroll.Maximum = 0;
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;

            GetFriendsList();
            GetGroupList();
            UploadeList();
            GetGroupMamber();
        }

        private void GetGroupList()
        {
            db.AdapterOpen("select FRGR_CD, FRGR_NM from FRIEND_GROUP_TB WHERE FRGR_UR_FK = '" + db.UR_CD + "' ORDER BY FRGR_NM DESC");
            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "friend_group_tb");
            friend_group_tb = ds.Tables["friend_group_tb"];
        }

        private void GetGroupMamber() // 그룹 멤버 반환 
        {

            for (int i = 0; i < friend_group_tb.Rows.Count; i++)  //panal 생성구간 create panel 로뺄까...?
            {
                location = 0;
                pan[i + 1] = new Panel();
                panel1.Controls.Add(pan[i + 1]);
                pan[i + 1].Location = new System.Drawing.Point(btn[i + 1].Location.X, btn[i + 1].Location.Y + 32);
                pan[i + 1].AutoSize = true;
                pan[i + 1].Visible = false;
                DataRow currRow = friend_group_tb.Rows[i];
                db.AdapterOpen("select  UR_NM from USER_TB  where UR_CD in (select FR_FR_FK from FRIEND_TB where FR_FRGR_FK = '" + currRow["FRGR_CD"].ToString() + "') ORDER BY  UR_NM ASC");

                DataSet rs = new DataSet();
                db.Adapter.Fill(rs, "groupMemberTb");
                DataTable groupMemberTb = rs.Tables["groupMemberTb"];

                for (int j = 0; j < groupMemberTb.Rows.Count; j++)
                {
                    pan[i + 1].Controls.Add( Create_FriendProfile(j, groupMemberTb));
                }
            }
        }

        private void GroupList_Click(object render, EventArgs e)// 위치 조절 함수
        {
            int i = 0;
            Button mybtn = (Button)render;
            i = mybtn.TabIndex ;
       
            if (!pan[i].Visible)
            {
                for (int j = i +1 ; j < friend_group_tb.Rows.Count + 1; j++)
                {
                    btn[j].Location = new Point(btn[j].Location.X, btn[j].Location.Y + pan[i].Size.Height);
                    pan[j].Location = new System.Drawing.Point(btn[j].Location.X, btn[j].Location.Y + 32);
                }
                pan[i].Visible = true;
            }
            else
            {
                for (int j = i+1; j < friend_group_tb.Rows.Count + 1; j++)
                {
                    btn[j].Location = new Point(btn[j].Location.X, btn[j].Location.Y - pan[i].Size.Height);
                    pan[j].Location = new System.Drawing.Point(btn[j].Location.X, btn[j].Location.Y + 32);
                }
                pan[i].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            location = 0;
            panel3.Controls.Clear();
            bool check = false;
            for (int i = 0; i < friendTable.Rows.Count; i++)
            {
                DataRow currRow = friendTable.Rows[i];
                if (currRow["UR_NM"].ToString().Equals(textBox1.Text))
                {
                    check = true;
                    panel3.Controls.Add( Create_FriendProfile(i, friendTable));
                    panel3.Visible = true;
                }       
            }
           
            if(!check)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
            textBox1.Text = "";        
        }

        private void button4_Click(object sender, EventArgs e) // 취소
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddFriend addFriend = new AddFriend();
            addFriend.ShowDialog();
          
        }

     
    }
}



