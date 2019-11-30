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


        // int count = 0;

        DBConnection db = Program.DB;
        DataTable friendTable = null;
        DataTable friend_group_tb = null;
        DataTable friendtb = null;
        

        Panel[] pan;
        Label[] label;
        Button[] btn;

        DataSet groupMember = new DataSet();

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
            btn = new Button[friend_group_tb.Rows.Count];
            

            
            
            Button btnbase = new Button();
            btnbase.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnbase.Location = new System.Drawing.Point(50, 10);
            btnbase.Name = "btn";
            btnbase.Size = new System.Drawing.Size(130, 32);
            btnbase.Text = "기본그룹    ▲";
            panel1.Controls.Add(btnbase);
            flag[0] = 1;

            for (int i = 0; i < friendTable.Rows.Count; i++)
            {
                DataRow currRow = friendTable.Rows[i];
                UserCustomControl.Profile FriendProfile = new UserCustomControl.Profile();
                FriendProfile.Set_Profile_Size(30, FontStyle.Bold);
                FriendProfile.USERNAME = currRow["UR_NM"].ToString();
                FriendProfile.Location = new System.Drawing.Point(70, 45 + location * 30);
                FriendProfile.Size = new System.Drawing.Size(150, 25);       
                panel1.Controls.Add(FriendProfile);
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
            // friend_group_tb.Rows.Count
            //currRow["FRGR_NM"].ToString();
            for (int i = 0; i < friend_group_tb.Rows.Count; i++)
            {
                DataRow currRow;
                currRow = friend_group_tb.Rows[i];
                btn[i] = new Button();
                btn[i].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btn[i].Location = new System.Drawing.Point(50, 45 + location * 30);
                btn[i].Name = "btn" + i.ToString();
                btn[i].Size = new System.Drawing.Size(130, 32);
                btn[i].TabIndex = i;
                btn[i].Text = currRow["FRGR_NM"].ToString() + "       ▼";
                // btn[i].Click +=
                panel1.Controls.Add(btn[i]);

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
            getFriendTB();
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
            pan = new Panel[friend_group_tb.Rows.Count];
            for (int i = 0; i < friend_group_tb.Rows.Count; i++)
            {

                int count = 0;
                pan[i] = new Panel();
                panel1.Controls.Add(pan[i]);
                pan[i].Location = new System.Drawing.Point(btn[i].Location.X, btn[i].Location.Y + 32);
                pan[i].AutoSize = true;
                pan[i].BorderStyle = BorderStyle.FixedSingle;



                DataRow currRow = friend_group_tb.Rows[i];
                db.AdapterOpen("select  UR_NM from USER_TB  where UR_CD in (select FR_FR_FK from FRIEND_TB where FR_FRGR_FK = '" + currRow["FRGR_CD"].ToString() + "') ORDER BY  UR_NM ASC");
               
                DataSet rs = new DataSet();
                db.Adapter.Fill(rs, "groupMemberTb");
                DataTable groupMemberTb = rs.Tables["groupMemberTb"];

                for (int j = 0; j < groupMemberTb.Rows.Count; j++)
                {
                     DataRow McurrRow = groupMemberTb.Rows[j];

                        Label li = new Label();
                        li.Size = new System.Drawing.Size(100, 25);
                        li.Text = McurrRow["UR_NM"].ToString();
                        li.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                         pan[i].Controls.Add(li);
                        li.Location = new Point(0, count*30);
                         listBox1.Items.Add(McurrRow["UR_NM"].ToString());
                    
                        count++;
               
                }
            }
        }

        private void getFriendTB()
        {
            db.AdapterOpen("select FR_UR_FK, FR_FR_FK ,FR_FRGR_FK from FRIEND_TB WHERE FR_UR_FK = '" + db.UR_CD + "' ");

            DataSet ds = new DataSet();

            db.Adapter.Fill(ds, "friendtb");
            friendtb = ds.Tables["friendtb"];

        }
        //private void userTB()
        //{
        //    db.AdapterOpen("select UR_CD, UR_NM  from USER_TB WHERE UR_CD = '" + db.UR_CD + "' ORDER BY UR_NM ASC");

        //    DataSet ds = new DataSet();

        //    db.Adapter.Fill(ds, "usertb");
        //    usertb = ds.Tables["usertb"];

        //}


        private void 


    }

}

