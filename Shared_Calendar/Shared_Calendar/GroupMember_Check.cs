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
    public partial class GroupMember_Check : Form
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

        public GroupMember_Check()
        {
            InitializeComponent();
        }

        private void Get_list() {
            try
            {
                sql = "select GR_CD, GR_NM from GROUP_TB";
                sql += " where GR_CD in (";
                sql += "select GRMB_FK from GROUP_MEMBER_TB";
                sql += " where GRMB_MBR_UR_FK = '" + db.UR_CD + "'";
                sql += " and GRMB_ACEP_ST = 0)";

                DS = new DataSet();
                db.AdapterOpen(sql);
                db.Adapter.Fill(DS, "GET_GROUP_TB");

                DataTable GET_GROUP_TB = new DataTable();
                GET_GROUP_TB  = DS.Tables["GET_GROUP_TB"];
                GET_GROUP_TB.PrimaryKey = new DataColumn[] { GET_GROUP_TB.Columns["GR_CD"] };

                if (GET_GROUP_TB.Rows.Count == 0)
                {
                    Close();
                }
                else
                {
                    Group_dbgrid.DataSource = GET_GROUP_TB;
                    Set_DBgridview();
                }
            }
            catch
            {
                MessageBox.Show("끝", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private int btnColumnIdx_acept;
        private int btnColumnIdx_delete;
        private void Set_DBgridview()
        {
            Group_dbgrid.Columns[0].Visible = false;
            Group_dbgrid.Columns[1].HeaderText = "그룹명";

            DataGridViewButtonColumn btnColumn_acept = new DataGridViewButtonColumn();
            btnColumn_acept.HeaderText = "Acept";
            btnColumn_acept.Name = "delete_buttonColumn";
            btnColumnIdx_acept = Group_dbgrid.Columns.Add(btnColumn_acept);

            foreach (DataGridViewRow row in Group_dbgrid.Rows)
                row.Cells[btnColumnIdx_acept].Value = "수락";
            Group_dbgrid.Columns[2].Width = 50;

            DataGridViewButtonColumn btnColumn_delete = new DataGridViewButtonColumn();
            btnColumn_delete.HeaderText = "Acept";
            btnColumn_delete.Name = "delete_buttonColumn";
            btnColumnIdx_delete = Group_dbgrid.Columns.Add(btnColumn_delete);

            foreach (DataGridViewRow row in Group_dbgrid.Rows)
                row.Cells[btnColumnIdx_delete].Value = "무시";
            Group_dbgrid.Columns[3].Width = 50;

            Group_dbgrid.CellClick += Group_DBgrid_CellClick;
        }

        void Group_DBgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == btnColumnIdx_acept)
            {
                string update_gr_cd = Group_dbgrid.Rows[e.RowIndex].Cells["GR_CD"].Value.ToString();
                sql = "update GROUP_MEMBER_TB set GRMB_ACEP_ST = 1";
                sql += " where GRMB_FK = '" + update_gr_cd + "'";
                sql += " and GRMB_MBR_UR_FK = '" + db.UR_CD + "'";
                db.ExecuteNonQuery(sql);
                Group_dbgrid.Rows.Remove(Group_dbgrid.Rows[e.RowIndex]);
            }
            else if (e.ColumnIndex == btnColumnIdx_delete)
            {
                string delete_gr_cd = Group_dbgrid.Rows[e.RowIndex].Cells["GR_CD"].Value.ToString();
                sql = "delete from GROUP_MEMBER_TB";
                sql += " where GRMB_FK = '" + delete_gr_cd + "'";
                sql += " and GRMB_MBR_UR_FK = '" + db.UR_CD + "'";
                db.ExecuteNonQuery(sql);
                Group_dbgrid.Rows.Remove(Group_dbgrid.Rows[e.RowIndex]);
            }
            if (Group_dbgrid.Rows.Count == 1) Close();
        }

        private void GroupMember_Check_Load(object sender, EventArgs e)
        {
            Get_list();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
