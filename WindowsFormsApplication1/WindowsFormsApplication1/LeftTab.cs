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
    public partial class LeftTab : Form
    {
        DBConnection db = Program.DB;
        string sql;

        List<string> Group_lst;

        public LeftTab()
        {
            InitializeComponent();
        }

        private void Add_GR_btn_Click(object sender, EventArgs e) // 그룹 추가 버튼
        {
            MessageBox.Show("여기에 그룹 추가 폼을 띄웁니다");
        }

        int MstGr_cnt = 0;
        private void Set_MstGroupList() // 유저가 마스터인 그룹
        {
            Group_lst = new List<string>();

            sql = "select GR_CD, GR_NM from GROUP_TB";
            sql += " where GR_MST_UR_FK = '" + db.UR_CD + "'";
            sql += " order by GR_NM ASC";
            db.ExecuteReader(sql);

            while (db.Reader.Read())
            {
                Group_lst.Add(db.Reader.GetString(0));
                Group_lstbox.Items.Add(db.Reader.GetString(1));
                MstGr_cnt++;
            }
        }

        private void Set_MemGroupList() // 유저가 멤버인 그룹
        {
            sql = "select GR_CD, GR_NM from GROUP_TB";
            sql += " where GR_MST_UR_FK != '" + db.UR_CD + "'";
            sql += " and GR_CD in (";
            sql += "select GRMB_FK from GROUP_MEMBER_TB";
            sql += " where GRMB_MBR_UR_FK = '" + db.UR_CD + "'";
            sql += " and GRMB_ACEP_ST = 1)";
            sql += " order by GR_NM ASC";
            db.ExecuteReader(sql);

            while (db.Reader.Read())
            {
                Group_lst.Add(db.Reader.GetString(0));
                Group_lstbox.Items.Add(db.Reader.GetString(1));
            }
        }

        private void LeftTab_Load(object sender, EventArgs e)
        {
            Set_MstGroupList();
            Set_MemGroupList();
        }

        private void Group_lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);

                Font font;

                if (e.Index < MstGr_cnt) font = new Font("함초롬돋움", 9, FontStyle.Bold);
                else font = new Font("함초롬돋움", 9, FontStyle.Regular);

                SizeF size = e.Graphics.MeasureString(item.ToString(), font);

                e.Graphics.DrawString(item.ToString(), font, brush, e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }

        private void Group_lstbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.GR_CD = Group_lst[Group_lstbox.SelectedIndex];
            Group grp = new Group();
            grp.TopLevel = false;
            grp.TopMost = true;
            grp.Parent = this;
            grp.Location = new Point(0, 0);
            Tab_panel.Controls.Add(grp);
            Tab_panel.Visible = true;
            grp.Show();
        }
    }
}
