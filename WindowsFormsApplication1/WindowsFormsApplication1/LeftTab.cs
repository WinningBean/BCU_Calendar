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
        private DBConnection db = Program.DB;
        private string sql;

        private List<string> bsGroup_CD_lst;
        private List<string> schGroup_CD_lst;

        public LeftTab()
        {
            InitializeComponent();
        }

        public List<string> GROUP_CD_lst
        {
            // 그룹 코드 리스트 프로퍼티
            get { return bsGroup_CD_lst; }
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
            get { return bsGroup_lstbox; }
        }

        private void Add_GR_btn_Click(object sender, EventArgs e) // 그룹 추가 버튼
        {
            Group_Modify grpAdd = new Group_Modify();
            grpAdd.ShowDialog();
            reset();
        }

        int MstGr_cnt = 0;
        private void Set_MstGroupList() // 유저가 마스터인 그룹
        {
            bsGroup_CD_lst = new List<string>();

            sql = "select GR_CD, GR_NM from GROUP_TB";
            sql += " where GR_MST_UR_FK = '" + db.UR_CD + "'";
            sql += " order by GR_NM ASC";
            db.ExecuteReader(sql);

            while (db.Reader.Read())
            {
                bsGroup_CD_lst.Add(db.Reader.GetString(0));
                bsGroup_lstbox.Items.Add(db.Reader.GetString(1));
                //if (bsGroup_lstbox.Items.Count < 15) bsGroup_lstbox.Height += 30;
                bsGroup_lstbox.Height += 30;
                MstGr_cnt++;
            }
            Set_MemGroupList();
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
                bsGroup_CD_lst.Add(db.Reader.GetString(0));
                bsGroup_lstbox.Items.Add(db.Reader.GetString(1));
                //if (bsGroup_lstbox.Items.Count < 15) bsGroup_lstbox.Height += 30;
                bsGroup_lstbox.Height += 30;
            }
            db.Reader.Close();
        }

        public void reset() {
            bsGR_pan.VerticalScroll.Minimum = 0;
            bsGR_pan.VerticalScroll.Maximum = 0;
            bsGR_pan.VerticalScroll.Visible = true;
            bsGR_pan.HorizontalScroll.Minimum = 0;
            bsGR_pan.HorizontalScroll.Maximum = 0;
            bsGR_pan.HorizontalScroll.Visible = false;
            bsGR_pan.AutoSize = false;
            bsGR_pan.AutoScroll = true;

            //bsGroup_lstbox.AutoScrollOffset = bsGR_pan.AutoScrollOffset;

            bsGroup_lstbox.Items.Clear();
            bsGroup_lstbox.Height = 0;
            schGroup_lstbox.Height = 0;
            Set_MstGroupList();
            bsGroup_lstbox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.mylst_MouseWheel);
        }

        private void LeftTab_Load(object sender, EventArgs e)
        {
            reset();
        }
        
        private void mylst_MouseWheel(object sender, MouseEventArgs e)
        {
            ListBox mylst = (ListBox)sender;
            Panel parentPan = (Panel)mylst.Parent;
            if (e.Delta / 120 > 0)
            {
                if (mylst.Location.Y <= parentPan.Height - mylst.Height)
                {
                    mylst.Location = new Point(mylst.Location.X, mylst.Location.Y + 30);
                }
            }
            else
            {
                if (mylst.Location.Y <= 0)
                {
                    if (parentPan.Height >= mylst.Bottom) return;
                    mylst.Location = new Point(mylst.Location.X, mylst.Location.Y - 30);
                }
            }
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

        private void SEARCH_GR_btn_Click(object sender, EventArgs e)
        {
            if (SEARCH_GR_btn.Text == "⟳")
            {
                bsGR_pan.Visible = true;
                bsGroup_lstbox.Visible = true;
                SearchGR_txt.Visible = false;
                SEARCH_GR_btn.Visible = false;
                searchLine.Visible = false;
                schGroup_lstbox.Visible = false;
                SEARCH_GR_btn.Text = "⌕";
                SearchGR_txt.Clear();
                schGroup_lstbox.Items.Clear();
                schGroup_lstbox.Height = 0;
            }
            else
            {
                schGroup_CD_lst = new List<string>();

                sql = "select GR_CD, GR_NM from GROUP_TB";
                sql += " where GR_CD in (";
                sql += "select GRMB_FK from GROUP_MEMBER_TB";
                sql += " where GRMB_MBR_UR_FK = '" + db.UR_CD + "'";
                sql += " and GRMB_ACEP_ST = 1)";
                sql += " and GR_NM like '%" + SearchGR_txt.Text + "%'";
                sql += " order by GR_NM ASC";
                db.ExecuteReader(sql);

                while (db.Reader.Read())
                {
                    schGroup_CD_lst.Add(db.Reader.GetString(0));
                    schGroup_lstbox.Items.Add(db.Reader.GetString(1));
                    if (schGroup_lstbox.Items.Count < 15) schGroup_lstbox.Height += 30;
                }
                db.Reader.Close();

                bsGR_pan.Visible = false;
                schGroup_lstbox.Visible = true;
                bsGroup_lstbox.Visible = false;
                SEARCH_GR_btn.Text = "⟳";

                db.Reader.Close();
            }
        }

        private void Goup_lbl_MouseHover(object sender, EventArgs e)
        {
            if (SearchGR_txt.Visible == false)
            {
                this.toolTip1.SetToolTip(Goup_lbl, "클릭시 그룹 검색");
            }
        }

        private void Goup_lbl_Click(object sender, EventArgs e)
        {
            SearchGR_txt.Visible = true;
            SEARCH_GR_btn.Visible = true;
            searchLine.Visible = true;
        }

        private void SchGroup_lstbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);

                Font font =new Font("맑은 고딕", 9F, FontStyle.Regular);
                SizeF size = e.Graphics.MeasureString(item.ToString(), font);

                e.Graphics.DrawString(item.ToString(), font, brush, e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }
    }
}
