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

        private void UploadFriendList()
        {
            for (int i = 0; i < 3; i++)
            {
                ComboBox com = new ComboBox();
                com.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                com.Name = "com" + i;
                com.Location = new System.Drawing.Point(50, location + i * 30);
                com.Text = "친구목록";

            }
        }

        private void UploadeList(int location)
        {
            flag = new int[friendTable.Rows.Count + 1];
            label = new Label[friendTable.Rows.Count];
            btn = new Button[friend_group_tb.Rows.Count+1];
            pan = new Panel[friend_group_tb.Rows.Count + 1];

            //기본적으로 생성해주는 모든친구 버튼과 목록이 저장되는 판넬 생성 
            btn[0] = new Button();
            btn[0].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btn[0].Location = new System.Drawing.Point(50, 10);
            btn[0].Name = "btn";
            btn[0].Size = new System.Drawing.Size(130, 32);
            btn[0].Text = "기본그룹    ▲";
            panel1.Controls.Add(btn[0]);
            flag[0] = 1;

            pan[0] = new Panel();
            pan[0].AutoSize = true;
            pan[0].Location = new Point(btn[0].Location.X, btn[0].Location.Y + 30);
            panel1.Controls.Add(pan[0]);

            for (int i = 0; i < friendTable.Rows.Count; i++)
            {
                DataRow currRow = friendTable.Rows[i];
                UserCustomControl.Profile FriendProfile = new UserCustomControl.Profile();
                pan[0].Controls.Add(FriendProfile);
                FriendProfile.Set_Profile_Size(30, FontStyle.Bold);
                FriendProfile.USERNAME = currRow["UR_NM"].ToString();
                FriendProfile.Location = new System.Drawing.Point(0, 10 + location * 30);
                FriendProfile.Size = new System.Drawing.Size(150, 25);
                
                location++;

                //label[i] = new Label();
                //label[i].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                //label[i].Location = new System.Drawing.Point(110, 45 + location * 30);
                //label[i].Name = "label" + i.ToString();
                //label[i].Size = new System.Drawing.Size(100, 25);
                //label[i].TabIndex = i;
                //label[i].Text = currRow["UR_NM"].ToString();
                //panel1.Controls.Add(label[i]);
                //location++;
            }

            for (int i = 0; i < friend_group_tb.Rows.Count; i++) // ***CreateGroupButton 함수로 뺄꺼
            {
                DataRow currRow;
                currRow = friend_group_tb.Rows[i];
                btn[i+1] = new Button();
                btn[i+1].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btn[i+1].Location = new System.Drawing.Point(50, 45 + location * 30);
                btn[i+1].Name = "btn" + i.ToString();
                btn[i+1].Size = new System.Drawing.Size(130, 32);
                btn[i+1].TabIndex = i;
                btn[i+1].Text = currRow["FRGR_NM"].ToString() + "       ▼";
                // btn[i+1].Click +=
                panel1.Controls.Add(btn[i+1]);

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
            DBGrid.DataSource = DS.Tables["friend_tb"].DefaultView;

            // int count = friendTable.Rows.Count;

            //location = 50 + count * 30;

            db.Close();
        }

        private void FriendList_Load(object sender, EventArgs e)
        {
            panel1.HorizontalScroll.Maximum = 0;
            panel1.VerticalScroll.Maximum = 0;
            // panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;  //스크롤 

            GetFriendsList();
            GetGroupList();
            UploadeList(location);
           // getFriendTB();
            GetGroupMamber();
            // userTB();    

        }

        private void GetGroupList()
        {
            db.AdapterOpen("select FRGR_CD, FRGR_NM from FRIEND_GROUP_TB WHERE FRGR_UR_FK = '" + db.UR_CD + "' ORDER BY FRGR_NM DESC");
            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "friend_group_tb");
            friend_group_tb = ds.Tables["friend_group_tb"];
            DBGrid2.DataSource = ds.Tables["friend_group_tb"].DefaultView;

        }

        private void GetGroupMamber() // 그룹 멤버 반환 
        {
            
            for (int i = 0; i < friend_group_tb.Rows.Count; i++)  //panal 생성구간 create panel 로뺄까...?
            {

                int count = 0;
                pan[i+1] = new Panel();
                panel1.Controls.Add(pan[i+1]);
                pan[i+1].Location = new System.Drawing.Point(btn[i+1].Location.X, btn[i+1].Location.Y + 32);
                pan[i+1].AutoSize = true;
                pan[i+1].BorderStyle = BorderStyle.FixedSingle;

                DataRow currRow = friend_group_tb.Rows[i];
                db.AdapterOpen("select  UR_NM from USER_TB  where UR_CD in (select FR_FR_FK from FRIEND_TB where FR_FRGR_FK = '" + currRow["FRGR_CD"].ToString() + "') ORDER BY  UR_NM ASC");

                DataSet rs = new DataSet();
                db.Adapter.Fill(rs, "groupMemberTb");
                DataTable groupMemberTb = rs.Tables["groupMemberTb"];

                for (int j = 0; j < groupMemberTb.Rows.Count; j++)
                {
                    DataRow McurrRow = groupMemberTb.Rows[j];
                    UserCustomControl.Profile FriendProfile = new UserCustomControl.Profile();
                    FriendProfile.Set_Profile_Size(30, FontStyle.Bold);
                    FriendProfile.USERNAME = McurrRow["UR_NM"].ToString();
                    FriendProfile.Size = new System.Drawing.Size(150, 25);
                    pan[i + 1].Controls.Add(FriendProfile);
                    FriendProfile.Location = new Point(0, count * 30);

                    //Label li = new Label();
                    //li.Size = new System.Drawing.Size(100, 25);
                    //li.Text = McurrRow["UR_NM"].ToString();
                    //li.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    //pan[i+1].Controls.Add(li);
                    //li.Location = new Point(0, count * 30);
                    listBox1.Items.Add(McurrRow["UR_NM"].ToString()); 

                    count++;

                }
            }
        }

        //private void getFriendTB()
        //{
        //    db.AdapterOpen("select FR_UR_FK, FR_FR_FK ,FR_FRGR_FK from FRIEND_TB WHERE FR_UR_FK = '" + db.UR_CD + "' ");

        //    DataSet ds = new DataSet();

        //    db.Adapter.Fill(ds, "friendtb");
        //    friendtb = ds.Tables["friendtb"];

        //}
        //private void userTB()
        //{
        //    db.AdapterOpen("select UR_CD, UR_NM  from USER_TB WHERE UR_CD = '" + db.UR_CD + "' ORDER BY UR_NM ASC");

        //    DataSet ds = new DataSet();

        //    db.Adapter.Fill(ds, "usertb");
        //    usertb = ds.Tables["usertb"];

        //}

        private void GroupList_Click(object render, EventArgs e)  // 동적생성 버튼의 이벤드 아직 연결 안시킴 
        {
            int i = 0; // 눌린 버튼이 몇째버튼인지 구해서 i 에  넣어줘야함
                if (flag[i] == 0)
                {
                    pan[i].Visible = true;
                    for (int j = i; j < friend_group_tb.Rows.Count+1; j++)
                    {
                        btn[j].Location = new Point(btn[j].Location.X, btn[j].Location.Y + pan[j].Size.Height);
                        pan[j].Location = new System.Drawing.Point(btn[j].Location.X, btn[j].Location.Y + 32);
                    }
                }
                else
                {
                    pan[i].Visible = false;
                    for (int j = i; j < friend_group_tb.Rows.Count+1; j++)
                    {
                        btn[j].Location = new Point(btn[j].Location.X, btn[j].Location.Y - pan[j].Size.Height);
                        pan[j].Location = new System.Drawing.Point(btn[j].Location.X, btn[j].Location.Y + 32);
                    }

                } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}

