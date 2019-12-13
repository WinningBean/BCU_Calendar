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
    public partial class DiaryList : Form
    {
        public DiaryList()
        {
            InitializeComponent();
        }
        DBConnection db = Program.DB;
        DataTable DiaryTB = null;
        int check = 1;
        int rowNum = 0;
        int location = 0;
        private void DiaryList_Load(object sender, EventArgs e)
        {
            Get_Diary();
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
            while (rowNum < DiaryTB.Rows.Count)
            {
                DataRow currRow = DiaryTB.Rows[rowNum++]; // 행 하나씩 받아옴
                string date = currRow["DR_DT"].ToString();
                int year = Convert.ToInt32(date.Substring(0, 4));
                int month = Convert.ToInt32(date.Substring(5, 2));
                int day = Convert.ToInt32(date.Substring(8, 2));
                DateTime currDate = new DateTime(year, month, day);

                Panel panel = new Panel();
                panel1.Controls.Add(panel);
                panel.Location = new Point(0, location);
                panel.Size = new Size(260, 148);

                Label lb = new Label();
                panel.Controls.Add(lb);
                lb.Text = currDate.ToString("yyyy년 MM월 dd일");
                lb.Location = new Point(5, 5);
                lb.AutoSize = true;
                lb.Size = new System.Drawing.Size(60, 20);
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.Show();

                TextBox textBox = new TextBox();
                panel.Controls.Add(textBox);
                textBox.Location = new Point(5, 35);
                textBox.Size = new Size(240, 75);
                textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox.Text = currRow["DR_EX"].ToString();
                textBox.Multiline = true;


                Button bt = new Button();
                panel.Controls.Add(bt);
                bt.Size = new Size(45, 23);
                bt.Text = "수정";
                bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bt.Location = new Point(150, 115);
                bt.Tag = currRow["DR_DT"];
                bt.Name = currRow["DR_PB_ST"].ToString();
                bt.FlatStyle = FlatStyle.Flat;

                Button btn = new Button();
                panel.Controls.Add(btn);
                btn.Size = new Size(45, 23);
                btn.Text = "삭제";
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Location = new Point(195, 115);
                btn.Tag = currRow["DR_DT"];
                btn.Name = currRow["DR_PB_ST"].ToString();
                btn.FlatStyle = FlatStyle.Flat;



                location += 140; // 라벨 y값 + y 10 띄우기 해서 34
            }
        }
        private void delete()
        {

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

            panel1.Controls.Clear();
            location = 0;
            rowNum = 0;
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

            panel1.Controls.Clear();
            location = 0;
            rowNum = 0;
            Get_Diary();
            Create();
        }
    }
}
