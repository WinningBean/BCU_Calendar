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
        int location;


        public FriendList()
        {
            InitializeComponent();
            int location = 0;
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
            for (int i = 0; i < 20; i++)
            {
                Label label = new Label();
                label.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                label.Location = new System.Drawing.Point(110, location + i * 30);
                label.Name = "label" + i.ToString();
                label.Size = new System.Drawing.Size(120, 23);
                label.TabIndex = i;
                label.Text = "최주은" + i;
                panel1.Controls.Add(label);

            }
        }
        private void GetFriendsList()
        {
            db.UR_CD = "U100001";
            db.AdapterOpen("select fr_fr_fk from friend_tb WHERE fr_ur_fk = '" + db.UR_CD + "' ORDER BY fr_fr_fk DESC");

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
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;
        
            GetFriendsList();
            UploadeList(location);


        }

        private void GetGroupList()
        {
            db.AdapterOpen("select fr_fr_fk from friend_tb WHERE fr_ur_fk = '" + db.UR_CD + "' ORDER BY fr_fr_fk DESC");

            DataSet ds = new DataSet();

        }

    }
    }

