namespace WindowsFormsApplication1
{
    partial class Picture_Modify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_CD_lb = new System.Windows.Forms.Label();
            this.DT_lb = new System.Windows.Forms.Label();
            this.m_DT_lb = new System.Windows.Forms.Label();
            this.PB_lb = new System.Windows.Forms.Label();
            this.modify_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_PB_cb = new System.Windows.Forms.ComboBox();
            this.MainHeader_menustp = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.최소화toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.MainHeader_menustp.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_CD_lb
            // 
            this.m_CD_lb.AutoSize = true;
            this.m_CD_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_CD_lb.Location = new System.Drawing.Point(18, 33);
            this.m_CD_lb.Name = "m_CD_lb";
            this.m_CD_lb.Size = new System.Drawing.Size(56, 18);
            this.m_CD_lb.TabIndex = 0;
            this.m_CD_lb.Text = "label1";
            // 
            // DT_lb
            // 
            this.DT_lb.AutoSize = true;
            this.DT_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_lb.Location = new System.Drawing.Point(6, 2);
            this.DT_lb.Name = "DT_lb";
            this.DT_lb.Size = new System.Drawing.Size(87, 18);
            this.DT_lb.TabIndex = 0;
            this.DT_lb.Text = "사진 등록일 :";
            // 
            // m_DT_lb
            // 
            this.m_DT_lb.AutoSize = true;
            this.m_DT_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_DT_lb.Location = new System.Drawing.Point(99, 2);
            this.m_DT_lb.Name = "m_DT_lb";
            this.m_DT_lb.Size = new System.Drawing.Size(36, 18);
            this.m_DT_lb.TabIndex = 0;
            this.m_DT_lb.Text = "text";
            this.m_DT_lb.Click += new System.EventHandler(this.m_DT_lb_Click);
            // 
            // PB_lb
            // 
            this.PB_lb.AutoSize = true;
            this.PB_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PB_lb.Location = new System.Drawing.Point(6, 24);
            this.PB_lb.Name = "PB_lb";
            this.PB_lb.Size = new System.Drawing.Size(74, 18);
            this.PB_lb.TabIndex = 0;
            this.PB_lb.Text = "사진 공개 :";
            // 
            // modify_btn
            // 
            this.modify_btn.Location = new System.Drawing.Point(225, 20);
            this.modify_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modify_btn.Name = "modify_btn";
            this.modify_btn.Size = new System.Drawing.Size(66, 18);
            this.modify_btn.TabIndex = 1;
            this.modify_btn.Text = "수정";
            this.modify_btn.UseVisualStyleBackColor = true;
            this.modify_btn.Click += new System.EventHandler(this.modify_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(225, 40);
            this.delete_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(66, 18);
            this.delete_btn.TabIndex = 1;
            this.delete_btn.Text = "삭제";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_PB_cb);
            this.panel1.Controls.Add(this.modify_btn);
            this.panel1.Controls.Add(this.delete_btn);
            this.panel1.Controls.Add(this.DT_lb);
            this.panel1.Controls.Add(this.PB_lb);
            this.panel1.Controls.Add(this.m_DT_lb);
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 64);
            this.panel1.TabIndex = 2;
            // 
            // m_PB_cb
            // 
            this.m_PB_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_PB_cb.FormattingEnabled = true;
            this.m_PB_cb.Items.AddRange(new object[] {
            "공개",
            "비공개"});
            this.m_PB_cb.Location = new System.Drawing.Point(86, 22);
            this.m_PB_cb.Name = "m_PB_cb";
            this.m_PB_cb.Size = new System.Drawing.Size(88, 20);
            this.m_PB_cb.TabIndex = 2;
            this.m_PB_cb.SelectedIndexChanged += new System.EventHandler(this.m_PB_cb_SelectedIndexChanged);
            // 
            // MainHeader_menustp
            // 
            this.MainHeader_menustp.BackColor = System.Drawing.Color.Black;
            this.MainHeader_menustp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MainHeader_menustp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainHeader_menustp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.최소화toolStripMenuItem});
            this.MainHeader_menustp.Location = new System.Drawing.Point(0, 0);
            this.MainHeader_menustp.Name = "MainHeader_menustp";
            this.MainHeader_menustp.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainHeader_menustp.Size = new System.Drawing.Size(337, 24);
            this.MainHeader_menustp.TabIndex = 8;
            this.MainHeader_menustp.Text = "menuStrip1";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(27, 20);
            this.xToolStripMenuItem.Text = "X";
            // 
            // 최소화toolStripMenuItem
            // 
            this.최소화toolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.최소화toolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.최소화toolStripMenuItem.Name = "최소화toolStripMenuItem";
            this.최소화toolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.최소화toolStripMenuItem.Text = "─";
            // 
            // Picture_Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 138);
            this.Controls.Add(this.MainHeader_menustp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_CD_lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Picture_Modify";
            this.Text = "Picture_Modify";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MainHeader_menustp.ResumeLayout(false);
            this.MainHeader_menustp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_CD_lb;
        private System.Windows.Forms.Label DT_lb;
        private System.Windows.Forms.Label m_DT_lb;
        private System.Windows.Forms.Label PB_lb;
        private System.Windows.Forms.Button modify_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox m_PB_cb;
        private System.Windows.Forms.MenuStrip MainHeader_menustp;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 최소화toolStripMenuItem;
    }
}