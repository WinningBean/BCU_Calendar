using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared_Calendar
{
    public partial class Friend_Group : Form
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
        Panel[] boardPan = null;
        CheckBox[] check = null;
        int location;
        string frgr_CD;


        public Friend_Group()
        {
            InitializeComponent();
            location = 0;
        }

        private void FriendGroup_Load(object sender, EventArgs e)
        {
            panel1.HorizontalScroll.Maximum = 0;
            panel1.VerticalScroll.Maximum = 0;
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;

            panel1.Show();
            panel1.Visible = true;
            panel1.AutoScroll = true;
            GetFriendsList();
           
            boardPan= new Panel[friendTable.Rows.Count + 1];
            check = new CheckBox[friendTable.Rows.Count + 1];

            for (int i = 0; i < friendTable.Rows.Count; i++)
            {
                DataRow curr = friendTable.Rows[i];
                panel1.Controls.Add(Create_FriendProfile(i, curr));

            }
        }
        private Control Create_FriendProfile(int i, DataRow curr) //친구 프로필 생성
        {
            boardPan[i] = new Panel();
            boardPan[i].Size = new Size(180, 30);
            panel1.Controls.Add(boardPan[i]);
            boardPan[i].Location = new Point(2, location);
           // boardPan[i].BackColor = Color.Aqua;
            location += 40;

            check[i] = new CheckBox();
            boardPan[i].Controls.Add(check[i]);
            check[i].Location = new System.Drawing.Point(110, 2);
            //check.Name = code;
            check[i].Size = new System.Drawing.Size(35, 35);
            check[i].TabIndex = i;
            check[i].Text = "";
            check[i].BackColor = Color.White;
            check[i].UseVisualStyleBackColor = true;
       
            button2.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

       
            UserCustomControl.Profile FriendProfile = new UserCustomControl.Profile();
            FriendProfile.Size = new System.Drawing.Size(100, 25);
            FriendProfile.Set_Profile_Size(FontLibrary.HANDOTUM, FontStyle.Bold);
            boardPan[i].Controls.Add(FriendProfile);
            FriendProfile.Location = new System.Drawing.Point(5, 5);
            FriendProfile.USERNAME.Text = curr["UR_NM"].ToString();
            if (!(curr["UR_PIC"].Equals(System.DBNull.Value))) FriendProfile.USERPIC.Image = Image.FromStream(db.Reader.GetOracleBlob(2));
            FriendProfile.TabIndex = i;

            return boardPan[i];
        }
        private void GetFriendsList() //친구 목록 가져오기
        {
            db.AdapterOpen("select  UR_NM ,UR_CD,UR_PIC from USER_TB  WHERE ur_cd  in (select FR_FR_FK from FRIEND_TB where FR_UR_FK = '" + db.UR_CD + "' and FR_ACEP_ST = '1') ORDER BY  UR_NM ASC");

            DataSet DS = new DataSet();
            db.Adapter.Fill(DS, "friend_tb");
            friendTable = DS.Tables["friend_tb"];

            //db.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("그룹이름을 지정해주세요", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                string sql = "insert into FRIEND_GROUP_TB values('FRGR'||to_char(seq_sccd.NEXTVAL), '" + textBox1.Text + "', '" + db.UR_CD + "' )";
                db.ExecuteNonQuery(sql);

                string command = "select * from FRIEND_GROUP_TB ORDER BY FRGR_CD DESC";
                db.ExecuteReader(command);
                if (db.Reader.Read())
                {
                    frgr_CD = db.Reader["FRGR_CD"].ToString(); //frgr_CD 저장
                }

                for (int i = 0; i < friendTable.Rows.Count; i++)
                {
                    DataRow dataRow = friendTable.Rows[i];
                    if (check[i].Checked == true)
                    {

                        string sql2 = "update FRIEND_TB set FR_FRGR_FK = '" + frgr_CD + "' where FR_FR_FK = '" + dataRow["UR_CD"].ToString() + "'";
                        db.ExecuteNonQuery(sql2);
                    }

                }
                if (MessageBox.Show("친구그룹생성이 완료 되었습니다", "완료", MessageBoxButtons.OK) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
           
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
