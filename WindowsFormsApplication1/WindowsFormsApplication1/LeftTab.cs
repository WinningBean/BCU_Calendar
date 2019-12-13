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

        private List<string> Group_CD_lst;

        public LeftTab()
        {
            InitializeComponent();
        }

        public List<string> GROUP_CD_lst
        {
            // 그룹 코드 리스트 프로퍼티
            get { return Group_CD_lst; }
        }
        public Label PUBLIC_BTN
        {
            // 공개 일정 버튼 프로퍼티
            get { return Public_SC_btn; }
        }
        public Label PRIVATE_BTN
        {
            // 공개 일정 버튼 프로퍼티
            get { return Private_SC_btn; }
        }
        public ListBox GROUP_lstbox
        {
            // 그룹 리스트박스 프로퍼티
            get { return Group_lstbox; }
        }

        private void Add_GR_btn_Click(object sender, EventArgs e) // 그룹 추가 버튼
        {
            MessageBox.Show("여기에 그룹 추가 폼을 띄웁니다");
        }

        int MstGr_cnt = 0;
        private void Set_MstGroupList() // 유저가 마스터인 그룹
        {
            Group_CD_lst = new List<string>();

            sql = "select GR_CD, GR_NM from GROUP_TB";
            sql += " where GR_MST_UR_FK = '" + db.UR_CD + "'";
            sql += " order by GR_NM ASC";
            db.ExecuteReader(sql);

            while (db.Reader.Read())
            {
                Group_CD_lst.Add(db.Reader.GetString(0));
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
                Group_CD_lst.Add(db.Reader.GetString(0));
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

                if (e.Index < MstGr_cnt) font = new System.Drawing.Font("맑은 고딕", 9F, FontStyle.Bold);
                else font = new Font("맑은 고딕", 9F, FontStyle.Regular);

                SizeF size = e.Graphics.MeasureString(item.ToString(), font);

                e.Graphics.DrawString(item.ToString(), font, brush, e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));

            }
        }
    }
}
