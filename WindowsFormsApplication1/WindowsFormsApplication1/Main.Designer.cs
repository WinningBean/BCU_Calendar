namespace WindowsFormsApplication1
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainTop_panel = new System.Windows.Forms.Panel();
            this.PictureForm_btn = new System.Windows.Forms.Button();
            this.TodoForm_btn = new System.Windows.Forms.Button();
            this.WeekForm_btn = new System.Windows.Forms.Button();
            this.FreindForm_btn = new System.Windows.Forms.Label();
            this.m_Today_lbl = new System.Windows.Forms.Label();
            this.MonthForm_btn = new System.Windows.Forms.Button();
            this.UserName_txt = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.친구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.일정탭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLeft_panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MainCenter_panel = new System.Windows.Forms.Panel();
            this.Mainuser_panel = new System.Windows.Forms.Panel();
            this.할일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사진ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTop_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.MainLeft_panel.SuspendLayout();
            this.Mainuser_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTop_panel
            // 
            this.MainTop_panel.BackColor = System.Drawing.Color.Lime;
            this.MainTop_panel.Controls.Add(this.PictureForm_btn);
            this.MainTop_panel.Controls.Add(this.TodoForm_btn);
            this.MainTop_panel.Controls.Add(this.WeekForm_btn);
            this.MainTop_panel.Controls.Add(this.FreindForm_btn);
            this.MainTop_panel.Controls.Add(this.m_Today_lbl);
            this.MainTop_panel.Controls.Add(this.MonthForm_btn);
            this.MainTop_panel.Location = new System.Drawing.Point(243, 24);
            this.MainTop_panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainTop_panel.Name = "MainTop_panel";
            this.MainTop_panel.Size = new System.Drawing.Size(969, 69);
            this.MainTop_panel.TabIndex = 1;
            // 
            // PictureForm_btn
            // 
            this.PictureForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PictureForm_btn.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PictureForm_btn.Location = new System.Drawing.Point(670, 23);
            this.PictureForm_btn.Margin = new System.Windows.Forms.Padding(0);
            this.PictureForm_btn.Name = "PictureForm_btn";
            this.PictureForm_btn.Size = new System.Drawing.Size(56, 27);
            this.PictureForm_btn.TabIndex = 11;
            this.PictureForm_btn.Text = "사진";
            this.PictureForm_btn.UseVisualStyleBackColor = true;
            // 
            // TodoForm_btn
            // 
            this.TodoForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TodoForm_btn.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TodoForm_btn.Location = new System.Drawing.Point(615, 23);
            this.TodoForm_btn.Margin = new System.Windows.Forms.Padding(0);
            this.TodoForm_btn.Name = "TodoForm_btn";
            this.TodoForm_btn.Size = new System.Drawing.Size(56, 27);
            this.TodoForm_btn.TabIndex = 10;
            this.TodoForm_btn.Text = "할 일";
            this.TodoForm_btn.UseVisualStyleBackColor = true;
            // 
            // WeekForm_btn
            // 
            this.WeekForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WeekForm_btn.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WeekForm_btn.Location = new System.Drawing.Point(245, 23);
            this.WeekForm_btn.Margin = new System.Windows.Forms.Padding(0);
            this.WeekForm_btn.Name = "WeekForm_btn";
            this.WeekForm_btn.Size = new System.Drawing.Size(56, 27);
            this.WeekForm_btn.TabIndex = 9;
            this.WeekForm_btn.Text = "월간";
            this.WeekForm_btn.UseVisualStyleBackColor = true;
            // 
            // FreindForm_btn
            // 
            this.FreindForm_btn.AutoSize = true;
            this.FreindForm_btn.Location = new System.Drawing.Point(17, 26);
            this.FreindForm_btn.Name = "FreindForm_btn";
            this.FreindForm_btn.Size = new System.Drawing.Size(60, 16);
            this.FreindForm_btn.TabIndex = 8;
            this.FreindForm_btn.Text = "친구 목록";
            // 
            // m_Today_lbl
            // 
            this.m_Today_lbl.AutoSize = true;
            this.m_Today_lbl.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_Today_lbl.Location = new System.Drawing.Point(450, 24);
            this.m_Today_lbl.Name = "m_Today_lbl";
            this.m_Today_lbl.Size = new System.Drawing.Size(59, 21);
            this.m_Today_lbl.TabIndex = 6;
            this.m_Today_lbl.Text = "TODAY";
            // 
            // MonthForm_btn
            // 
            this.MonthForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthForm_btn.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MonthForm_btn.Location = new System.Drawing.Point(190, 23);
            this.MonthForm_btn.Margin = new System.Windows.Forms.Padding(0);
            this.MonthForm_btn.Name = "MonthForm_btn";
            this.MonthForm_btn.Size = new System.Drawing.Size(56, 27);
            this.MonthForm_btn.TabIndex = 2;
            this.MonthForm_btn.Text = "월간";
            this.MonthForm_btn.UseVisualStyleBackColor = true;
            // 
            // UserName_txt
            // 
            this.UserName_txt.AutoSize = true;
            this.UserName_txt.Font = new System.Drawing.Font("함초롬돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UserName_txt.Location = new System.Drawing.Point(99, 23);
            this.UserName_txt.Name = "UserName_txt";
            this.UserName_txt.Size = new System.Drawing.Size(90, 21);
            this.UserName_txt.TabIndex = 2;
            this.UserName_txt.Text = "UserName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("함초롬돋움", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.친구ToolStripMenuItem,
            this.일정탭ToolStripMenuItem,
            this.친구ToolStripMenuItem1,
            this.할일ToolStripMenuItem,
            this.사진ToolStripMenuItem,
            this.xToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1213, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 친구ToolStripMenuItem
            // 
            this.친구ToolStripMenuItem.Name = "친구ToolStripMenuItem";
            this.친구ToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.친구ToolStripMenuItem.Text = "사용자";
            // 
            // 일정탭ToolStripMenuItem
            // 
            this.일정탭ToolStripMenuItem.Name = "일정탭ToolStripMenuItem";
            this.일정탭ToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.일정탭ToolStripMenuItem.Text = "일정 탭";
            // 
            // 친구ToolStripMenuItem1
            // 
            this.친구ToolStripMenuItem1.Name = "친구ToolStripMenuItem1";
            this.친구ToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.친구ToolStripMenuItem1.Text = "친구";
            // 
            // MainLeft_panel
            // 
            this.MainLeft_panel.BackColor = System.Drawing.Color.SandyBrown;
            this.MainLeft_panel.Controls.Add(this.panel3);
            this.MainLeft_panel.Location = new System.Drawing.Point(0, 92);
            this.MainLeft_panel.Name = "MainLeft_panel";
            this.MainLeft_panel.Size = new System.Drawing.Size(243, 612);
            this.MainLeft_panel.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(243, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(970, 612);
            this.panel3.TabIndex = 6;
            // 
            // MainCenter_panel
            // 
            this.MainCenter_panel.BackColor = System.Drawing.Color.Maroon;
            this.MainCenter_panel.Location = new System.Drawing.Point(243, 92);
            this.MainCenter_panel.Name = "MainCenter_panel";
            this.MainCenter_panel.Size = new System.Drawing.Size(969, 612);
            this.MainCenter_panel.TabIndex = 7;
            // 
            // Mainuser_panel
            // 
            this.Mainuser_panel.BackColor = System.Drawing.Color.Sienna;
            this.Mainuser_panel.Controls.Add(this.pictureBox1);
            this.Mainuser_panel.Controls.Add(this.UserName_txt);
            this.Mainuser_panel.Location = new System.Drawing.Point(0, 24);
            this.Mainuser_panel.Name = "Mainuser_panel";
            this.Mainuser_panel.Size = new System.Drawing.Size(243, 69);
            this.Mainuser_panel.TabIndex = 8;
            // 
            // 할일ToolStripMenuItem
            // 
            this.할일ToolStripMenuItem.Name = "할일ToolStripMenuItem";
            this.할일ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.할일ToolStripMenuItem.Text = "할 일";
            // 
            // 사진ToolStripMenuItem
            // 
            this.사진ToolStripMenuItem.Name = "사진ToolStripMenuItem";
            this.사진ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.사진ToolStripMenuItem.Text = "사진";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 20);
            this.toolStripMenuItem1.Text = "─";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 20);
            this.toolStripMenuItem2.Text = "□";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(27, 20);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 706);
            this.Controls.Add(this.Mainuser_panel);
            this.Controls.Add(this.MainCenter_panel);
            this.Controls.Add(this.MainLeft_panel);
            this.Controls.Add(this.MainTop_panel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("함초롬돋움", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MainTop_panel.ResumeLayout(false);
            this.MainTop_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainLeft_panel.ResumeLayout(false);
            this.Mainuser_panel.ResumeLayout(false);
            this.Mainuser_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel MainTop_panel;
        private System.Windows.Forms.Label UserName_txt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 친구ToolStripMenuItem;
        private System.Windows.Forms.Panel MainLeft_panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel MainCenter_panel;
        private System.Windows.Forms.Panel Mainuser_panel;
        private System.Windows.Forms.Label m_Today_lbl;
        private System.Windows.Forms.Label FreindForm_btn;
        private System.Windows.Forms.Button MonthForm_btn;
        private System.Windows.Forms.Button WeekForm_btn;
        private System.Windows.Forms.Button PictureForm_btn;
        private System.Windows.Forms.Button TodoForm_btn;
        private System.Windows.Forms.ToolStripMenuItem 일정탭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 할일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사진ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
    }
}

