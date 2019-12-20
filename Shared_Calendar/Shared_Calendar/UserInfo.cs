using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.DataAccess.Client;

namespace Shared_Calendar
{


    public partial class UserInfo : Form
    {
        DBConnection db = Program.DB;
        DataRow dr = null;
        string ur_cd;
        public string ur_name;
        bool isDefault = true;
        Image imgs;

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

        public UserInfo(string UR_CD)
        {
            InitializeComponent();
            profile1.USERPIC.MouseClick += new MouseEventHandler(OnMouseClick);
            ur_cd = UR_CD;
            db.AdapterOpen("select * from USER_TB where UR_CD = '" + UR_CD + "'");
            DataSet ds = new DataSet("USER_TB");
            db.Adapter.Fill(ds, "USER_TB");
            dr = ds.Tables["USER_TB"].Rows[0];
            m_Name_tb.Text = dr[3].ToString();
            m_ID_tb.Text = dr[1].ToString();
            m_PW_tb.Text = dr[2].ToString();
            m_PW_tb.PasswordChar = '*';
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            profile1.USERNAME.Text = dr[3].ToString();
            profile1.Set_Profile_Size(FontLibrary.HANDOTUM, FontStyle.Bold);
            if (!(dr[4].Equals(System.DBNull.Value)))
            {
                Byte[] b = (Byte[])(dr[4]);
                MemoryStream stmBlobData = new MemoryStream(b);
                Image img = Image.FromStream(stmBlobData);
                profile1.USERPIC.Image = img; // 프로퍼티로 PIC값 넘겨줌
                imgs = img;
                isDefault = false;
            }
            else
            {
                isDefault = true;
                imgs = null;
            }
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("회원정보를 수정하시겠습니까?", "회원정보", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if(!m_PW_tb.Text.Equals(m_PWCheck_tb.Text)) // 패스워드와 패스워드체크가 같지않다면
                {
                    MessageBox.Show("패스워드가 같지않습니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(m_Name_tb.Text.Length <2)
                {
                    MessageBox.Show("이름은 2글자 이상이어야 합니다.\n 현재" + m_Name_tb.Text.Length.ToString() + "글자", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (m_PW_tb.Text.Length < 4)
                {
                    MessageBox.Show("패스워드는 4글자 이상이어야 합니다.\n 현재" + m_PW_tb.Text.Length.ToString() + "글자", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (m_ID_tb.Text.Length < 6)
                {
                    MessageBox.Show("아이디 길이가 6자 이상이어야 합니다\n현재 " + m_ID_tb.Text.Length.ToString() + "글자", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (m_ID_tb.Text.Length > 15)
                {
                    MessageBox.Show("아이디 길이가 12자 이하이어야 합니다\n현재 " + m_ID_tb.Text.Length.ToString() + "글자", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.ExecuteReader("select * from USER_TB where UR_ID = '" + m_ID_tb + "'");
                if (db.Reader.Read())
                {
                    MessageBox.Show("동일한 아이디가 이미 존재합니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (isDefault || imgs == null)
                {
                    db.ExecuteNonQuery("UPDATE USER_TB SET UR_PIC = null, UR_ID = '" + m_ID_tb.Text + "', UR_PW = '" + m_PW_tb.Text + "' WHERE UR_CD = '" + ur_cd.ToString() + "'");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    Image imgA = profile1.USERPIC.Image;
                    imgA.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    byte[] b = ms.ToArray();

                    OracleParameter op = new OracleParameter();
                    op.ParameterName = ":BINARYFILE";
                    op.OracleDbType = Oracle.DataAccess.Client.OracleDbType.Blob;
                    op.Direction = ParameterDirection.Input;
                    op.Size = b.Length;
                    op.Value = b;
                    db.Command.CommandType = CommandType.Text;
                    db.Command.Parameters.Add(op); // 커맨드에 이 파라미터를 추가시켜서 db에 보낼때 같이 보낼수있게 함

                    db.ExecuteNonQuery("UPDATE USER_TB SET UR_NM = '"+m_Name_tb.Text+"', UR_PIC = :BINARYFILE, UR_ID = '" 
                        + m_ID_tb.Text + "', UR_PW = '" + m_PW_tb.Text + "' WHERE UR_CD = '" + ur_cd.ToString() + "'");
                    db.Command.Parameters.Remove(op); // 삭제를 꼭 시켜야한다 안하면 사진생성을 두번이상 실행안됨
                    MessageBox.Show("수정 되었습니다!", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            UserInfo_Picture up = new UserInfo_Picture(profile1.USERPIC.Image, imgs == null ? false : true);
            if (up.ShowDialog() == DialogResult.OK)
            {
                //db.AdapterOpen("select * from USER_TB where UR_CD = '" + db.UR_CD + "'");
                //DataSet ds = new DataSet("USER_TB");
                //db.Adapter.Fill(ds, "USER_TB");
                //if (ds.Tables["USER_TB"].Rows[0][4].Equals(System.DBNull.Value))
                //{
                //    profile1.USERPIC.Image = null;
                //    this.DialogResult = DialogResult.OK;
                //    return;
                //}
                //Byte[] b = (Byte[])(ds.Tables["USER_TB"].Rows[0][4]);
                //MemoryStream stmBlobData = new MemoryStream(b);
                //Image img = Image.FromStream(stmBlobData);
                //profile1.USERPIC.Image = img; // 프로퍼티로 PIC값 넘겨줌
                //this.DialogResult = DialogResult.OK;
                if (!up.isImg)
                {
                    profile1.USERPIC.Image = up.defaultImage;
                    isDefault = true;
                    imgs = null;
                }
                else
                {
                    profile1.USERPIC.Image = up.img;
                    isDefault = false;
                    imgs = up.img;
                }
            }
            //if(DialogResult.Yes == MessageBox.Show("사진을 수정하시겠습니까?", "수정", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("정말 회원탈퇴 하시겠습니까?\n탈퇴시 정보를 되돌릴수없습니다."
                , "탈퇴", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
            {
                db.ExecuteNonQuery("delete from USER_TB where UR_CD = '" + db.UR_CD + "'");
                Application.Exit();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            ur_name = m_Name_tb.Text;
        }
    }
}
