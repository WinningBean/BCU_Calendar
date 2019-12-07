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
    public partial class Picture_Modify : Form
    {
        DBConnection db = Program.DB;
        DataRow dr;
        public Picture_Modify(DataRow dr)
        {
            this.dr = dr;
            InitializeComponent();
            m_CD_lb.Text = dr[0].ToString();
            m_DT_lb.Text = dr[2].ToString();
            m_PB_lb.Text = dr[1].ToString() == "1" ? "공개된 사진" : "비공개 사진";
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult drt = MessageBox.Show(this, "사진을 삭제하시겠습니까?", "사진삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (drt == DialogResult.Yes)
            {
                string sql = "delete from PICTURE_TB where PIC_CD = '" + dr[0].ToString() + "'";
                db.ExecuteNonQuery(sql);
                this.DialogResult = DialogResult.No;
            }
            Close();
        }
    }
}
