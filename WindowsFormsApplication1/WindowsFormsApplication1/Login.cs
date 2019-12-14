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
    public partial class Login : Form
    {
        bool isSighUp, isSamePass;

        DBConnection db = Program.DB; // static 객체를 db참조변수에 저장

        public Login()
        {
            InitializeComponent();
            // 초기값 설정
            isSighUp = false;
            isSamePass = false;
            panel5.Visible = false;
            panel6.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label3.Visible = false;
            textBox1.Text = "ID";
            textBox2.Text = "Password";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            textBox4.ForeColor = Color.Gray;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(isSighUp)) // 회원가입 버튼 누르면
            {
                panel5.Visible = true;
                panel6.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                button1.Text = "Sign-up";
                button2.Text = "Sign-in";
                label1.Text = "Sign-up";
                textBox1.Text = "ID";
                textBox2.Text = "Password";
                textBox2.PasswordChar = '\0';
                textBox4.PasswordChar = '\0';
                textBox3.Text = "Name";
                textBox4.Text = "Rewrite Password";
                textBox1.ForeColor = Color.Gray;
                textBox2.ForeColor = Color.Gray;
                textBox3.ForeColor = Color.Gray;
                textBox4.ForeColor = Color.Gray;
                isSighUp = true;
            }
            else
            {
                panel5.Visible = false;
                panel6.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                button1.Text = "Sign-in";
                button2.Text = "Sign-up";
                label1.Text = "Sign-in";
                textBox1.Text = "ID";
                textBox2.Text = "Password";
                textBox2.PasswordChar = '\0';
                label3.Visible = false;
                textBox1.ForeColor = Color.Gray;
                textBox2.ForeColor = Color.Gray;
                textBox3.ForeColor = Color.Gray;
                textBox4.ForeColor = Color.Gray;
                isSighUp = false;

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isSighUp)
            {
                if (isSamePass)
                {
                    string strID = textBox1.Text;
                    string strPass = textBox2.Text;
                    string strName = textBox3.Text;
                    if (strID.Length < 6)
                    {
                        MessageBox.Show("아이디 길이가 6자 이상이어야 합니다\n현재 " + strID.Length.ToString() + "글자", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (strID.Length > 15)
                    {
                        MessageBox.Show("아이디 길이가 15자 이하이어야 합니다\n현재 " + strID.Length.ToString() + "글자", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    db.ExecuteReader("select * from USER_TB where UR_ID = '" + strID + "'");
                    if (db.Reader.Read())
                    {
                        MessageBox.Show("동일한 아이디가 이미 존재합니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        string command = "insert into USER_TB values('U' || seq_urcd.nextval, '" + strID + "', '" + strPass + "', '" + strName + "', null)";

                        if (db.ExecuteNonQuery(command) < 1)
                        {
                            MessageBox.Show("데이터베이스 오류!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        MessageBox.Show("회원가입 되었습니다!", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button2.PerformClick();
                    }
                    catch (DataException DE)
                    {
                        MessageBox.Show("데이터베이스 오류!! \n" + DE.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("데이터베이스 오류!! \n" + E.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                String strID = textBox1.Text;
                String strPass = textBox2.Text;
                String strName = textBox3.Text;
                try
                {
                    db.ExecuteReader("select * from USER_TB where (UR_ID = '" + strID + "') AND (UR_PW = '" + strPass + "')");
                    if (db.Reader.Read())
                    {
                        MessageBox.Show("로그인 되었습니다!", "완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Hide();
                        PassDB_ToMain();
                        //db.Reader.Close();
                        return;
                    }
                    MessageBox.Show("로그인 실패하였습니다!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (DataException DE)
                {
                    MessageBox.Show("데이터베이스 연결 오류!! \n" + DE.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Oracle.DataAccess.Client.OracleException OE)
                {
                    MessageBox.Show("데이터베이스 데이터 오류!! \n" + OE.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PassDB_ToMain()
        {
            // Main form에 DB 정보를 넘기는 함수
            db.UR_CD = db.Reader.GetString(0);
            string user_id = db.Reader.GetString(1);
            string user_nm = db.Reader.GetString(3);
            Image user_pic = null;
            bool b_pic = false;
            // UR_PIC 값이 null이 아니라면 사진을 가져와 주세요
            if (!(db.Reader[4].Equals(System.DBNull.Value)))
            {
                user_pic = Image.FromStream(db.Reader.GetOracleBlob(4));
                b_pic = true;
            }

            Main main = new Main(this);
            main.USERID = user_id; // 프로퍼티로 ID값 넘겨줌
            main.USERPROFILE.USERNAME.Text = user_nm; // 프로퍼티로 NAME값 넘겨줌
            if (b_pic == true) main.USERPROFILE.USERPIC.Image = user_pic; // 프로퍼티로 PIC값 넘겨줌
            main.Location = new Point(50, Screen.PrimaryScreen.Bounds.Height / 2 - main.Height / 2 - 50);
            main.Show();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.PasswordChar = '*';
            textBox4.ForeColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.Black;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (isSighUp)
            {
                if (!(textBox2.Text.Equals(textBox4.Text)))
                {
                    isSamePass = false;
                    label3.Text = "비밀번호가 같지 않습니다.";
                    label3.ForeColor = Color.Red;
                    label3.Visible = true;
                }
                else
                {
                    isSamePass = true;
                    label3.Text = "비밀번호가 같습니다.";
                    label3.ForeColor = Color.Green;
                }
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!(textBox4.Text.Equals(textBox2.Text)))
            {
                isSamePass = false;
                label3.Text = "비밀번호가 같지 않습니다.";
                label3.ForeColor = Color.Red;
                label3.Visible = true;
            }
            else
            {
                isSamePass = true;
                label3.Text = "비밀번호가 같습니다.";
                label3.ForeColor = Color.Green;
            }
        }
    }
}
