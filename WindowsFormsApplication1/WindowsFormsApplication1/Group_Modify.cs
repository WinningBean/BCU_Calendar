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
    public partial class Group_Modify : Form
    {
        private DBConnection db = Program.DB;
        private string sql;

        public Group_Modify()
        {
            InitializeComponent();
        }

        public Group_Modify(int is_Modi = 0)
        {
            InitializeComponent();
            if (is_Modi == 1)
            {
                AddGR_btn.Visible = false;
                ModiGR_btn.Visible = true;
                DeleGR_btn.Visible = true;
            }
        }

        public string GRNM_txt { set { GR_nm_txt.Text = value; } }
        public string GREX_txt { set { GR_ex_txt.Text = value; } }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddGR_btn_Click(object sender, EventArgs e)
        {
            if (GR_nm_txt.Text == "")
            {
                MessageBox.Show("그룹명 입력은 필수입니다.");
                GR_nm_txt.Focus();
            }
            else if (System.Text.Encoding.Default.GetByteCount(GR_nm_txt.Text) > 40)
            {
                MessageBox.Show("그룹명이 너무 깁니다.");
            }
            else if (System.Text.Encoding.Default.GetByteCount(GR_ex_txt.Text) > 290)
            {
                MessageBox.Show("그룹 설명이 너무 깁니다.");
            }
            else
            {
                sql = "insert into GROUP_TB values('G' || to_char(seq_grcd.NEXTVAL), '";
                sql += db.UR_CD + "', '" + GR_nm_txt.Text + "', ";
                if (GR_ex_txt.Text == "") sql += "null)";
                else sql += "'" + GR_ex_txt.Text + "')";
                if (db.ExecuteNonQuery(sql) == 1) MessageBox.Show("그룹이 정상적으로 추가되었습니다.");

                db.ExecuteReader("select max(GR_CD) from GROUP_TB order by GR_CD DESC");
                db.Reader.Read();
                string new_GR_CD = db.Reader.GetString(0);
                db.Reader.Close();

                sql = "insert into GROUP_MEMBER_TB values(";
                sql += "'" + new_GR_CD + "', '" + db.UR_CD + "', 1)";
                db.ExecuteNonQuery(sql);
                
                Close();
            }
        }

        private void Group_Add_Load(object sender, EventArgs e)
        {
            GR_nm_txt.Focus();
        }

        private void ModiGR_btn_Click(object sender, EventArgs e)
        {
            if (GR_nm_txt.Text == "")
            {
                MessageBox.Show("그룹명 입력은 필수입니다.");
                GR_nm_txt.Focus();
            }
            else if (System.Text.Encoding.Default.GetByteCount(GR_nm_txt.Text) > 40)
            {
                MessageBox.Show("그룹명이 너무 깁니다.");
            }
            else if (System.Text.Encoding.Default.GetByteCount(GR_ex_txt.Text) > 290)
            {
                MessageBox.Show("그룹 설명이 너무 깁니다.");
            }
            else
            {
                sql = "update GROUP_TB set GR_NM = '" + GR_nm_txt.Text + "',";
                if (GR_ex_txt.Text == "") sql += " GR_EX = null";
                else sql += " GR_EX = '" + GR_ex_txt.Text + "'";
                sql += " where GR_CD = '" + db.GR_CD + "'";
                if (db.ExecuteNonQuery(sql) == 1) MessageBox.Show("그룹이 정상적으로 수정되었습니다.");
                Close();
            }
        }

        private void DeleGR_btn_Click(object sender, EventArgs e)
        {
            sql = "delete GROUP_TB where GR_CD = '" + db.GR_CD + "'";
            if (db.ExecuteNonQuery(sql) == 1) MessageBox.Show("그룹이 정상적으로 삭제되었습니다.");
            db.GR_CD = null;
            Close();
        }
    }
}
