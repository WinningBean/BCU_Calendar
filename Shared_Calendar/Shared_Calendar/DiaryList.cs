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
    public partial class DiaryList : Form
    {
        public DiaryList()
        {
            InitializeComponent();
        }
        DBConnection db = Program.DB;
        DataTable DiaryTB = null;
        TextBox[] tb;
        int check = 1;
        int location = 0;
        DateTime[] date;
        private void DiaryList_Load(object sender, EventArgs e)
        {
            panel1.HorizontalScroll.Maximum = 0;
            panel1.VerticalScroll.Maximum = 0;
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;
           
            Get_Diary();
            tb = new TextBox[DiaryTB.Rows.Count + 1];
            date = new DateTime[DiaryTB.Rows.Count + 1];
            Create();
        }
        private void Get_Diary()
        {
            string sql = "select * from DIARY_TB where DR_UR_FK = '" + db.UR_CD + "'and DR_PB_ST= '" + check + "'ORDER BY  DR_DT DESC";
            db.AdapterOpen(sql);
            DataSet DS = new DataSet();
            db.Adapter.Fill(DS, "DiaryTB");
            DiaryTB = DS.Tables["DiaryTB"];
        }
        private void Create()
        {
           for(int i = 0; i< DiaryTB.Rows.Count; i++ )
            {
                DataRow currRow = DiaryTB.Rows[i]; // 행 하나씩 받아옴
                string date = currRow["DR_DT"].ToString();
                int year = Convert.ToInt32(date.Substring(0, 4));
                int month = Convert.ToInt32(date.Substring(5, 2));
                int day = Convert.ToInt32(date.Substring(8, 2));
                DateTime currDate = new DateTime(year, month, day);
                //date.value = currRow["DR_DT"].value;

                Panel panel = new Panel();
                panel1.Controls.Add(panel);
                panel.Location = new Point(0, location);
                panel.Size = new Size(255, 148);

                Label lb = new Label();
                panel.Controls.Add(lb);
                lb.Text = currDate.ToString("yyyy.MM.dd일");
                lb.Location = new Point(5, 5);
                lb.AutoSize = true;
                lb.Size = new System.Drawing.Size(60, 20);
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.Show();

                tb[i] = new TextBox();
                panel.Controls.Add(tb[i]);
                tb[i].Location = new Point(5, 35);
                tb[i].Size = new Size(240, 75);
                tb[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tb[i].Text = currRow["DR_EX"].ToString();
                tb[i].Multiline = true;


                Button bt = new Button();
                panel.Controls.Add(bt);
                bt.Size = new Size(45, 23);
                bt.Text = "수정";
                bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bt.Location = new Point(150, 115);
                bt.Name = currDate.ToString("yyyy/MM/dd H:mm");
                bt.TabIndex = i;                                                   
                bt.FlatStyle = FlatStyle.Flat;
                bt.Click += new System.EventHandler(update);

                Button btn = new Button();
                panel.Controls.Add(btn);
                btn.Size = new Size(45, 23);
                btn.Text = "삭제";
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Location = new Point(195, 115);
                btn.Name = currDate.ToString("yyyy/MM/dd H:mm");
                btn.FlatStyle = FlatStyle.Flat;
                btn.TabIndex = i;
                btn.Click += new System.EventHandler(delete);



                location += 140; // 라벨 y값 + y 10 띄우기 해서 34
            }
        }
        private void delete(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int i = bt.TabIndex;
            string str = tb[i].Text;
            string nowdate = bt.Name;
            if (MessageBox.Show("일기가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from DIARY_TB where DR_DT = to_date('" + nowdate + "', 'yyyy/MM/dd hh24:mi') and DR_PB_ST = '" + check + "' and DR_UR_FK='" + db.UR_CD + "'";
                db.ExecuteNonQuery(sql);
                Clear_Control();
                this.Close();
            }
     
        }
        private void update(object sender, EventArgs e)                                                            
        {

            Button bt = (Button)sender;
            int i = bt.TabIndex;
            string str = tb[i].Text;
            string nowdate = bt.Name;
            string sql = "update DIARY_TB set DR_EX = '" + str + "' where DR_DT = to_date('" + nowdate + "', 'yyyy/MM/dd hh24:mi') and DR_PB_ST = '" + check + "'"; 
            db.ExecuteNonQuery(sql);

            MessageBox.Show("수정이 완료 되었습니다", "완료", MessageBoxButtons.OK);
            this.Close();

        }



        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void public_btn_Click(object sender, EventArgs e)
        {
            check = 1;
            public_btn.Enabled = false; 
            private_btn.Enabled = true; 
            public_btn.BackColor = Color.Gainsboro;
            public_btn.BackColor = Color.White;
            Clear_Control();

        }
        private void Clear_Control()
        {
            panel1.Controls.Clear();
            location = 0;
            Get_Diary();
            Create();
        }

        private void private_btn_Click(object sender, EventArgs e)
        {
            check = 0;
            private_btn.Enabled = false; 
            public_btn.Enabled = true;
            private_btn.BackColor = Color.Gainsboro;
            private_btn.BackColor = Color.White;

            Clear_Control();
        }
    }
}
