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
    public partial class GroupMember_Modify : Form
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

        private DBConnection db = Program.DB;
        private DataSet DS;
        private string sql;

        public GroupMember_Modify()
        {
            InitializeComponent();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_backcolor_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.WhiteSmoke;
        }

        private void btn_backcolor_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
        }

        private void Set_GroupMem() {
            try { 
                sql = "select UR_CD, UR_ID, UR_NM from USER_TB";
                sql += " where UR_CD in(";
                sql += "select GRMB_MBR_UR_FK from GROUP_MEMBER_TB";
                sql += " where GRMB_FK = '" + db.GR_CD + "'";
                sql += " and GRMB_ACEP_ST = 1";
                sql += " and GRMB_MBR_UR_FK != (";
                sql += "select GR_MST_UR_FK from GROUP_TB";
                sql += " where GR_CD = '" + db.GR_CD + "'))";
                sql += " order by UR_ID ASC";

                DS = new DataSet();
                db.AdapterOpen(sql);
                db.Adapter.Fill(DS, "GET_GRMB_TB");

                DataTable GET_GRMB_TB = new DataTable();
                GET_GRMB_TB = DS.Tables["GET_GRMB_TB"];

                Mem_DBgrid.DataSource = GET_GRMB_TB;
                Set_DBgridview();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private int btnColumnIdx;

        private void Set_DBgridview()
        {
            Mem_DBgrid.Columns[0].Visible = false;
            Mem_DBgrid.Columns[1].HeaderText = "ID";
            Mem_DBgrid.Columns[2].HeaderText = "NAME";

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Delete";
            btnColumn.Name = "delete_buttonColumn";
            btnColumnIdx = Mem_DBgrid.Columns.Add(btnColumn);

            foreach (DataGridViewRow row in Mem_DBgrid.Rows)
                row.Cells[btnColumnIdx].Value = "삭제";
            Mem_DBgrid.Columns[3].Width = 50;

            Mem_DBgrid.CellClick += Mem_DBgrid_CellClick;
        }

        void Mem_DBgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == btnColumnIdx)
            {
                string delete_ur_cd = Mem_DBgrid.Rows[e.RowIndex].Cells["UR_CD"].Value.ToString();
                sql = "delete from GROUP_MEMBER_TB";
                sql += " where GRMB_FK = '" + db.GR_CD + "'";
                sql += " and GRMB_MBR_UR_FK = '" + delete_ur_cd + "'";
                db.ExecuteNonQuery(sql);
                MessageBox.Show("그룹원이 삭제되었습니다.");
                Set_GroupMem();
            }
        }

        private void GroupMember_Modify_Load(object sender, EventArgs e)
        {
            Set_GroupMem();
        }

        private void Add_Mem_btn_Click(object sender, EventArgs e)
        {
            User_Search userSearch = new User_Search();
            userSearch.ShowDialog();
        }
    }
}
