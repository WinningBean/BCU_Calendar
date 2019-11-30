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
        ListBox[] list ;
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
                com.Name = "com"+i;
                com.Location = new System.Drawing.Point(50, location + i * 30);
                com.Text = "친구목록";

            }
        }
        
        private void FriendGroup_Click(object sender)
        {

        }

        private void UploadeList(int location)
        {
            flag = new int[friendTable.Rows.Count+1];
            Label[] label = new Label[friendTable.Rows.Count];
            Button[] btn = new Button[friend_group_tb.Rows.Count];


            Button btnbase = new Button();
            btnbase.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            btnbase.Location = new System.Drawing.Point(80, 10);
            btnbase.Name = "btn";
            btnbase.Size = new System.Drawing.Size(120, 32);
            btnbase.Text = "기본그룹    ▲";
            panel1.Controls.Add(btnbase);
            flag[0] = 1;

            for ( int i = 0; i < friendTable.Rows.Count; i++)
            {
                DataRow currRow = friendTable.Rows[i];
                label[i] = new Label();
                label[i].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                label[i].Location = new System.Drawing.Point(110, 45 + location * 30);
                label[i].Name = "label" + i.ToString();
                label[i].Size = new System.Drawing.Size(100, 25);
                label[i].TabIndex = i;
                label[i].Text = currRow["fr_fr_fk"].ToString();
                panel1.Controls.Add(label[i]);
                location++;
            }
            // friend_group_tb.Rows.Count
            //currRow["FRGR_NM"].ToString();
            for (int i = 0; i < friend_group_tb.Rows.Count; i++)
            {
                DataRow currRow = friend_group_tb.Rows[i];
                btn[i] = new Button();
                btn[i].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btn[i].Location = new System.Drawing.Point(80, 45 + location * 30);
                btn[i].Name = "btn" + i.ToString();
                btn[i].Size = new System.Drawing.Size(120, 32);
                btn[i].TabIndex = i;
                btn[i].Text = currRow["FRGR_NM"].ToString() + "       ▼";
                panel1.Controls.Add(btn[i]);

                location++;
                flag[i + 1] = 0;
            }


        }
        private void GetFriendsList()
        {
            db.UR_CD = "U100000";
            db.AdapterOpen("select fr_fr_fk, FR_FRGR_FK from friend_tb WHERE fr_ur_fk = '" + db.UR_CD + "' ORDER BY fr_fr_fk DESC");

            DataSet DS = new DataSet();
            db.Adapter.Fill(DS, "friend_tb");
            friendTable = DS.Tables["friend_tb"];
            DBGrid.DataSource = DS.Tables["friend_tb"].DefaultView;

            int count = friendTable.Rows.Count;

            //location = 50 + count * 30;

            db.Close();
        }

        private void FriendList_Load(object sender, EventArgs e)
        {
            panel1.HorizontalScroll.Maximum = 0;
            panel1.VerticalScroll.Maximum = 0;
         //   panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;
        
            GetFriendsList();
            GetGroupList();
            UploadeList(location);

          // GetGroupMamber();
            listBox1.BorderStyle = BorderStyle.None;
           //listBox1. = false;
            //listBox1.AutoSize = True;
            listBox1.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //listBox1.autosize
        }

        private void GetGroupList()
        {
            db.AdapterOpen("select FRGR_CD, FRGR_NM from FRIEND_GROUP_TB WHERE FRGR_UR_FK = '" + db.UR_CD + "' ORDER BY FRGR_NM DESC");

            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "friend_group_tb");
            friend_group_tb = ds.Tables["friend_group_tb"];
            DBGrid2.DataSource = ds.Tables["friend_group_tb"].DefaultView;
            
            for (int i = 0; i < friend_group_tb.Rows.Count; i++)
            {
                DataRow currRow = friend_group_tb.Rows[i];
                

            }


        }
        private void GetGroupMamber()
        {
            
            for(int i = 0; i < friend_group_tb.Rows.Count; i++)
            {
                
                int count = 0;
                DataRow GcurrRow = friend_group_tb.Rows[i];
                for (int j = 0; j < friendTable.Rows.Count; j++)
                {
                    DataRow McurrRow = friendTable.Rows[j];
                    list[i] = new ListBox();
                    list[i].Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    list[i].Location = new System.Drawing.Point(btn[i].Location.X, btn[i].Location.Y + 32);
                    list[i].Size = new System.Drawing.Size(120, count * 32);
                    panel1.Controls.Add(list[i]);


                    if ((GcurrRow["FRGR_CD"].ToString()).Equals( McurrRow["FR_FRGR_FK"].ToString()))
                    {
                        list[i].Items.Add(McurrRow["FR_FRGR_FK"].ToString());
                        count++;
                    }
                   
                }
               

            }
        }

        private void GetLocation(int i, MouseEventArgs e)
        {

            if (flag[i] == 1)
            {
                list[i].Visible = true; 
                for (int j = i; j < 0; j--)
                {
                    // btn[i].Location .Y += 30 

                }

                flag[i] = 0;
            }
            else
            {

                for(int j = 0; j > i; j--)
                {

                }
            }
        }


       private void 

        
    }
    }

