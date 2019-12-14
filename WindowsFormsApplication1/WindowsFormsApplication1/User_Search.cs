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
    public partial class User_Search : Form
    {
        private DBConnection db = Program.DB;
        private DataSet DS;
        private string sql;

        public User_Search()
        {
            InitializeComponent();
        }

        private void Set_UserSearch() {
            sql = "select UR_CD, UR_ID, UR_NM from USER_TB";
            sql += " where (UR_ID like '%" + SearchUR_txt.Text + "%'";
            sql += " or UR_NM like '%" + SearchUR_txt.Text + "%')";
            sql += " and UR_CD not in (";
            sql += "select GRMB_MBR_UR_FK from GROUP_MEMBER_TB";
            sql += " where GRMB_FK = '" + db.GR_CD + "')";
            sql += " order by UR_ID ASC";

            DS = new DataSet();
            db.AdapterOpen(sql);
            db.Adapter.Fill(DS, "GET_USER_SEARCH_TB");

            DataTable GET_USER_SEARCH_TB = new DataTable();
            GET_USER_SEARCH_TB = DS.Tables["GET_USER_SEARCH_TB"];
            GET_USER_SEARCH_TB.PrimaryKey = new DataColumn[] { GET_USER_SEARCH_TB.Columns["UR_CD"] };

            if (GET_USER_SEARCH_TB.Rows.Count == 0)
            {
                MessageBox.Show("검색 데이터가 없습니다", "확인");
            }
            else
            {
                User_DBgrid.DataSource = GET_USER_SEARCH_TB;
                Set_DBgridview();
            }
        }

        private void SEARCH_UR_btn_Click(object sender, EventArgs e)
        {
            Set_UserSearch();
        }

        private int btnColumnIdx;
        private void Set_DBgridview()
        {
            User_DBgrid.Columns[0].Visible = false;
            User_DBgrid.Columns[1].HeaderText = "ID";
            User_DBgrid.Columns[2].HeaderText = "NAME";

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Add";
            btnColumn.Name = "delete_buttonColumn";
            btnColumnIdx = User_DBgrid.Columns.Add(btnColumn);

            foreach (DataGridViewRow row in User_DBgrid.Rows)
                row.Cells[btnColumnIdx].Value = "추가";
            User_DBgrid.Columns[3].Width = 50;

            User_DBgrid.CellClick += User_DBgrid_CellClick;
        }

        void User_DBgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == btnColumnIdx)
            {
                string add_ur_cd = User_DBgrid.Rows[e.RowIndex].Cells["UR_CD"].Value.ToString();
                sql = "insert into GROUP_MEMBER_TB";
                sql += " values ('" + db.GR_CD + "', '" + add_ur_cd + "', 0)";
                db.ExecuteNonQuery(sql);
                MessageBox.Show("그룹원 추가 신청되었습니다.");
                Set_UserSearch();
            }
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
