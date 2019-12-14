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
    public partial class Friend_Modify : Form
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

        DataRow curr;
        DataTable friendGoup;
        DataTable friendTable = null;
        DBConnection db = Program.DB;
        Point point;
 
        public string FrGrCom
        {
            get
            {
                if (friendGroupCom.Text == "기본그룹")
                    return null;
               else
                {
                    DataRow dataRow = friendGoup.Rows[friendGroupCom.SelectedIndex - 1];
                       return dataRow["FRGR_CD"].ToString();
                }
            }
            set
            {
                if (value == "")
                {
                    friendGroupCom.Text = "기본그룹";
                }
                else
                {
                    friendGroupCom.Text = value;
                }
                 
            }
        }
        public Friend_Modify(DataRow dr,DataTable dt, Point point)
        {
            InitializeComponent();
            this.curr = dr;
            this.point = point;
            this.friendGoup = dt;
            this.Location = new Point(point.X, point.Y);
        }


        private void FriendModify_Load(object sender, EventArgs e)
        {
            GetFriendsList();
            FrGrCom = "";
            friendGroupCom.Items.Add("기본그룹");
            nameLabel.Text = curr["UR_NM"].ToString();
            DataRow currRow = friendTable.Rows.Find(curr["UR_CD"].ToString());
            for (int i = 0; i < friendGoup.Rows.Count; i++ )
            {
                DataRow group = friendGoup.Rows[i];
                friendGroupCom.Items.Add(group["FRGR_NM"].ToString());
                if (currRow["FR_FRGR_FK"].ToString().Equals(group["FRGR_CD"].ToString()))
                {
                    FrGrCom = group["FRGR_NM"].ToString();

                }           
            }

            button4.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button5.MouseEnter += new EventHandler(OnTopPanMouseEnter);
            button4.MouseEnter += new EventHandler(OnTopPanMouseLeave);
            button5.MouseEnter += new EventHandler(OnTopPanMouseLeave);
        }
        private void GetFriendsList() //친구 목록 가져오기
        {
            db.AdapterOpen("select FR_FR_FK, FR_FRGR_FK from FRIEND_TB where FR_UR_FK = '" + db.UR_CD + "' and FR_ACEP_ST = '1' ");

            DataSet DS = new DataSet();
            db.Adapter.Fill(DS, "friend_tb");
            friendTable = DS.Tables["friend_tb"];
            friendTable.PrimaryKey = new DataColumn[] { friendTable.Columns["FR_FR_FK"] };

            //db.Close();
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
            if (MessageBox.Show("친구가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from FRIEND_TB where FR_FR_FK = '" + curr["UR_CD"].ToString() + "'";
                db.ExecuteNonQuery(sql);
                this.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           string sql = "update FRIEND_TB set FR_FRGR_FK = '" + FrGrCom + "' where FR_UR_FK = '" + db.UR_CD + "' and FR_FR_FK = '" + curr["UR_CD"].ToString() + "'";
            db.ExecuteNonQuery(sql);

            MessageBox.Show("수정이 완료 되었습니다", "완료", MessageBoxButtons.OK);
            
                this.Close();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void friendGroupCom_SelectedIndexChanged(object sender, EventArgs e)
        {
           // FrGrCom = 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
