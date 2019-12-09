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
    public partial class Week_MoreInfo : Form
    {
        DBConnection db = Program.DB;

        DateTime focusDate;

        public DateTime FocusDate
        {
            get { return focusDate; }
        }


        public Week_MoreInfo(string scInfo)
        {
            InitializeComponent();
            int infoNum = scInfo.Length / 7;
            for(int i =0; i<infoNum; i++)
            {
                string subStr = scInfo.Substring(7 * i, 7);
                db.ExecuteReader("select * from SCHEDULE_TB where SC_CD = '" + subStr + "'");
                if (db.Reader.Read())
                {
                    m_LiView_info.Items.Add(db.Reader[1].ToString());
                    m_LiView_info.Items[i].SubItems.Add(db.Reader[4].ToString());
                    m_LiView_info.Items[i].SubItems.Add(db.Reader[5].ToString());
                    m_LiView_info.Items[i].Name = db.Reader[0].ToString();
                }
            }
        }


        private void Week_MoreInfo_LocationChanged(object sender, EventArgs e)
        {

            if (this.Location.X <= 0)
                this.Location = new Point(0, this.Location.Y);
            if (this.Location.X + this.Width >= System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width)
                this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width, this.Location.Y);
            if (this.Location.Y <= 0)
                this.Location = new Point(this.Location.X, 0);
            if (this.Location.Y + this.Height >= System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height)
                this.Location = new Point(this.Location.X, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height);


        }

        private void Week_MoreInfo_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void m_LiView_info_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            var ls = m_LiView_info.SelectedItems[0];
            db.ExecuteReader("select * from SCHEDULE_TB where SC_CD = '" + ls.Name + "'");
            db.Reader.Read();
            ModifySchedule ms = new ModifySchedule();
            ms.NameTxt = db.Reader[1].ToString();
            ms.ExTxt = db.Reader[2].ToString();
            ms.StrDate = DateTime.Parse(db.Reader[4].ToString());
            ms.EndDate = DateTime.Parse(db.Reader[5].ToString());
            ms.StateCheck = Int32.Parse(db.Reader[3].ToString());
            ms.Show();
            ms.Focus();
            focusDate = ms.StrDate;
        }
    }
}
