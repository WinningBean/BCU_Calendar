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
    public partial class FriendCheck : Form
    {
        public FriendCheck()
        {
            InitializeComponent();
        }
        DBConnection db = Program.DB;
        DataTable friend_request_tb = null;
        private void Get_List()
        {
            db.AdapterOpen("select FR_UR_FK, FR_FR_FK from FRIEND_TB WHERE FR_FR_FK = '" + db.UR_CD + "'");
            DataSet ds = new DataSet();
            db.Adapter.Fill(ds, "friend_request_tb");
            friend_request_tb = ds.Tables["friend_request_tb"];
        }
        private void Create_Control(DataTable dataTable)
        {
            Panel boardPan = new Panel();
            boardPan.Size = new Size(303, 73);
            panel1.Controls.Add(boardPan);
            boardPan.Location = new Point(0,0);

            



        }

        private void Accept_Click(object render, EventArgs e)
        {
            //수락시 insert 와 0값을 1로 update
            string commad = "";
        }
        private void Ignoring_Click(object render, EventArgs e)
        {
            //무시 클릭시 delete
            string commad = "";
        }

    }
}
