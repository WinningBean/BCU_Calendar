﻿using System;
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
    public partial class Picture_Modify : Form
    {
        DBConnection db = Program.DB;
        DataRow dr;
        DateTime currDT;
        int PIC_PB_ST;
        public Picture_Modify(DataRow dr, Image img)
        {
            this.dr = dr;
            InitializeComponent();
            this.AutoScroll = true;
            m_CD_lb.Text = dr[0].ToString();
            currDT = DateTime.Parse(dr[2].ToString());
            m_DT_lb.Text = currDT.ToString("yyyy년 MM월 dd일");
            PIC_PB_ST = dr[1].ToString() == "1" ? 0 : 1;
            m_PB_cb.SelectedIndex = PIC_PB_ST;
            ShowIamge(img);
        }

        private void ShowIamge(Image img)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(img.Width, img.Height);
            pb.SizeMode = PictureBoxSizeMode.Normal;
            pb.Image = img;
            pb.Location = new Point(6, 30);
            this.Size = new Size(this.Width + pb.Width, this.Height + pb.Height);
            panel1.Location = new Point(panel1.Location.X + pb.Width, panel1.Location.Y + pb.Height);
            this.Controls.Add(pb);
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult drt = MessageBox.Show(this, "사진을 삭제하시겠습니까?", "사진삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (drt == DialogResult.Yes)
            {
                string sql = "delete from PICTURE_TB where PIC_CD = '" + dr[0].ToString() + "'";
                db.ExecuteNonQuery(sql);
                this.DialogResult = DialogResult.No;
            }
            Close();
        }

        private void modify_btn_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE PICTURE_TB SET PIC_PB_ST = " + PIC_PB_ST + ", PIC_DT = '" + currDT.ToString("yyyy-MM-dd HH:mm:dd") + "' where PIC_CD = '" + m_CD_lb.Text + "'";
            db.ExecuteNonQuery(sql);
            MessageBox.Show(this, "수정되었습니다", "사진수정", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }

        private void m_DT_lb_Click(object sender, EventArgs e)
        {
            Picture_SelectDate psd = new Picture_SelectDate();
            if (psd.ShowDialog() == DialogResult.OK)
            {
                m_DT_lb.Text = psd.dt.ToString("yyyy년 MM월 dd일");
                currDT = psd.dt;
            }
        }

        private void m_PB_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_PB_cb.SelectedIndex == 0)
                PIC_PB_ST = 1;
            else
                PIC_PB_ST = 0;
        }

    }
}
