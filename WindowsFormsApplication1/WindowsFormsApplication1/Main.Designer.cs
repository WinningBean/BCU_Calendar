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
            this.MainTop_pan = new System.Windows.Forms.Panel();
            this.PictureForm_btn = new System.Windows.Forms.Button();
            this.TodoForm_btn = new System.Windows.Forms.Button();
            this.WeekForm_btn = new System.Windows.Forms.Button();
            this.FreindForm_btn = new System.Windows.Forms.Label();
            this.m_Today_lbl = new System.Windows.Forms.Label();
            this.MonthForm_btn = new System.Windows.Forms.Button();
            this.UserName_txt = new System.Windows.Forms.Label();
            this.MainHeader_menustp = new System.Windows.Forms.MenuStrip();
            this.사용자ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용자정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그룹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그룹추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구그룹추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.할일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.할일추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.할일모두완료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.할일모두삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사진ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사진추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLeft_pan = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MainCenter_pan = new System.Windows.Forms.Panel();
            this.Mainuser_pan = new System.Windows.Forms.Panel();
            this.roundPictureBox2 = new UserCustomControl.RoundPictureBox();
            this.MainTop_pan.SuspendLayout();
            this.MainHeader_menustp.SuspendLayout();
            this.MainLeft_pan.SuspendLayout();
            this.Mainuser_pan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTop_pan
            // 
            this.MainTop_pan.BackColor = System.Drawing.Color.White;
            this.MainTop_pan.Controls.Add(this.PictureForm_btn);
            this.MainTop_pan.Controls.Add(this.TodoForm_btn);
            this.MainTop_pan.Controls.Add(this.WeekForm_btn);
            this.MainTop_pan.Controls.Add(this.FreindForm_btn);
            this.MainTop_pan.Controls.Add(this.m_Today_lbl);
            this.MainTop_pan.Controls.Add(this.MonthForm_btn);
            this.MainTop_pan.Location = new System.Drawing.Point(243, 24);
            this.MainTop_pan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainTop_pan.Name = "MainTop_pan";
            this.MainTop_pan.Size = new System.Drawing.Size(969, 69);
            this.MainTop_pan.TabIndex = 1;
            // 
            // PictureForm_btn
            // 
            this.PictureForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PictureForm_btn.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PictureForm_btn.Location = new System.Drawing.Point(725, 23);
            this.PictureForm_btn.Margin = new System.Windows.Forms.Padding(0);
            this.PictureForm_btn.Name = "PictureForm_btn";
            this.PictureForm_btn.Size = new System.Drawing.Size(56, 27);
            this.PictureForm_btn.TabIndex = 11;
            this.PictureForm_btn.Text = "사진";
            this.PictureForm_btn.UseVisualStyleBackColor = true;
            this.PictureForm_btn.Click += new System.EventHandler(this.PictureForm_btn_Click);
            // 
            // TodoForm_btn
            // 
            this.TodoForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TodoForm_btn.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TodoForm_btn.Location = new System.Drawing.Point(670, 23);
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
            this.WeekForm_btn.Text = "주간";
            this.WeekForm_btn.UseVisualStyleBackColor = true;
            this.WeekForm_btn.Click += new System.EventHandler(this.WeekForm_btn_Click);
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
            this.m_Today_lbl.Font = new System.Drawing.Font("함초롬돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_Today_lbl.Location = new System.Drawing.Point(449, 23);
            this.m_Today_lbl.Name = "m_Today_lbl";
            this.m_Today_lbl.Size = new System.Drawing.Size(69, 24);
            this.m_Today_lbl.TabIndex = 6;
            this.m_Today_lbl.Text = "TODAY";
            // 
            // MonthForm_btn
            // 
            this.MonthForm_btn.BackColor = System.Drawing.Color.White;
            this.MonthForm_btn.Enabled = false;
            this.MonthForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthForm_btn.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MonthForm_btn.Location = new System.Drawing.Point(190, 23);
            this.MonthForm_btn.Margin = new System.Windows.Forms.Padding(0);
            this.MonthForm_btn.Name = "MonthForm_btn";
            this.MonthForm_btn.Size = new System.Drawing.Size(56, 27);
            this.MonthForm_btn.TabIndex = 2;
            this.MonthForm_btn.Text = "월간";
            this.MonthForm_btn.UseVisualStyleBackColor = false;
            this.MonthForm_btn.Click += new System.EventHandler(this.MonthForm_btn_Click);
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
            // MainHeader_menustp
            // 
            this.MainHeader_menustp.BackColor = System.Drawing.Color.Gainsboro;
            this.MainHeader_menustp.Font = new System.Drawing.Font("함초롬돋움", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainHeader_menustp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용자ToolStripMenuItem,
            this.그룹ToolStripMenuItem,
            this.친구ToolStripMenuItem,
            this.할일ToolStripMenuItem,
            this.사진ToolStripMenuItem,
            this.xToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.MainHeader_menustp.Location = new System.Drawing.Point(0, 0);
            this.MainHeader_menustp.Name = "MainHeader_menustp";
            this.MainHeader_menustp.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainHeader_menustp.Size = new System.Drawing.Size(1212, 24);
            this.MainHeader_menustp.TabIndex = 4;
            this.MainHeader_menustp.Text = "menuStrip1";
            this.MainHeader_menustp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainHeader_menustp_MouseDown);
            this.MainHeader_menustp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainHeader_menustp_MouseMove);
            this.MainHeader_menustp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainHeader_menustp_MouseUp);
            // 
            // 사용자ToolStripMenuItem
            // 
            this.사용자ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용자정보ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.로그아웃ToolStripMenuItem});
            this.사용자ToolStripMenuItem.Name = "사용자ToolStripMenuItem";
            this.사용자ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.사용자ToolStripMenuItem.Text = "UserID";
            // 
            // 사용자정보ToolStripMenuItem
            // 
            this.사용자정보ToolStripMenuItem.Name = "사용자정보ToolStripMenuItem";
            this.사용자정보ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.사용자정보ToolStripMenuItem.Text = "사용자 정보";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(137, 6);
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            // 
            // 그룹ToolStripMenuItem
            // 
            this.그룹ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.그룹추가ToolStripMenuItem});
            this.그룹ToolStripMenuItem.Name = "그룹ToolStripMenuItem";
            this.그룹ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.그룹ToolStripMenuItem.Text = "그룹";
            // 
            // 그룹추가ToolStripMenuItem
            // 
            this.그룹추가ToolStripMenuItem.Name = "그룹추가ToolStripMenuItem";
            this.그룹추가ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.그룹추가ToolStripMenuItem.Text = "그룹 추가";
            // 
            // 친구ToolStripMenuItem
            // 
            this.친구ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.친구추가ToolStripMenuItem,
            this.친구그룹추가ToolStripMenuItem});
            this.친구ToolStripMenuItem.Name = "친구ToolStripMenuItem";
            this.친구ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.친구ToolStripMenuItem.Text = "친구";
            // 
            // 친구추가ToolStripMenuItem
            // 
            this.친구추가ToolStripMenuItem.Name = "친구추가ToolStripMenuItem";
            this.친구추가ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.친구추가ToolStripMenuItem.Text = "친구 추가";
            // 
            // 친구그룹추가ToolStripMenuItem
            // 
            this.친구그룹추가ToolStripMenuItem.Name = "친구그룹추가ToolStripMenuItem";
            this.친구그룹추가ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.친구그룹추가ToolStripMenuItem.Text = "친구 그룹 추가";
            // 
            // 할일ToolStripMenuItem
            // 
            this.할일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.할일추가ToolStripMenuItem,
            this.할일모두완료ToolStripMenuItem,
            this.할일모두삭제ToolStripMenuItem});
            this.할일ToolStripMenuItem.Name = "할일ToolStripMenuItem";
            this.할일ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.할일ToolStripMenuItem.Text = "할 일";
            // 
            // 할일추가ToolStripMenuItem
            // 
            this.할일추가ToolStripMenuItem.Name = "할일추가ToolStripMenuItem";
            this.할일추가ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.할일추가ToolStripMenuItem.Text = "할 일 추가";
            // 
            // 할일모두완료ToolStripMenuItem
            // 
            this.할일모두완료ToolStripMenuItem.Name = "할일모두완료ToolStripMenuItem";
            this.할일모두완료ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.할일모두완료ToolStripMenuItem.Text = "할 일 모두 완료";
            // 
            // 할일모두삭제ToolStripMenuItem
            // 
            this.할일모두삭제ToolStripMenuItem.Name = "할일모두삭제ToolStripMenuItem";
            this.할일모두삭제ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.할일모두삭제ToolStripMenuItem.Text = "할 일 모두 삭제";
            // 
            // 사진ToolStripMenuItem
            // 
            this.사진ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사진추가ToolStripMenuItem});
            this.사진ToolStripMenuItem.Name = "사진ToolStripMenuItem";
            this.사진ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.사진ToolStripMenuItem.Text = "사진";
            // 
            // 사진추가ToolStripMenuItem
            // 
            this.사진추가ToolStripMenuItem.Name = "사진추가ToolStripMenuItem";
            this.사진추가ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.사진추가ToolStripMenuItem.Text = "사진 추가";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(27, 20);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 20);
            this.toolStripMenuItem2.Text = "□";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 20);
            this.toolStripMenuItem1.Text = "─";
            // 
            // MainLeft_pan
            // 
            this.MainLeft_pan.BackColor = System.Drawing.Color.SandyBrown;
            this.MainLeft_pan.Controls.Add(this.panel3);
            this.MainLeft_pan.Location = new System.Drawing.Point(0, 92);
            this.MainLeft_pan.Name = "MainLeft_pan";
            this.MainLeft_pan.Size = new System.Drawing.Size(243, 596);
            this.MainLeft_pan.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(243, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(970, 612);
            this.panel3.TabIndex = 6;
            // 
            // MainCenter_pan
            // 
            this.MainCenter_pan.BackColor = System.Drawing.Color.Maroon;
            this.MainCenter_pan.Location = new System.Drawing.Point(243, 92);
            this.MainCenter_pan.Name = "MainCenter_pan";
            this.MainCenter_pan.Size = new System.Drawing.Size(969, 596);
            this.MainCenter_pan.TabIndex = 7;
            // 
            // Mainuser_pan
            // 
            this.Mainuser_pan.BackColor = System.Drawing.Color.White;
            this.Mainuser_pan.Controls.Add(this.roundPictureBox2);
            this.Mainuser_pan.Controls.Add(this.UserName_txt);
            this.Mainuser_pan.Location = new System.Drawing.Point(0, 24);
            this.Mainuser_pan.Name = "Mainuser_pan";
            this.Mainuser_pan.Size = new System.Drawing.Size(243, 69);
            this.Mainuser_pan.TabIndex = 8;
            // 
            // roundPictureBox2
            // 
            this.roundPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("roundPictureBox2.Image")));
            this.roundPictureBox2.Location = new System.Drawing.Point(41, 12);
            this.roundPictureBox2.Name = "roundPictureBox2";
            this.roundPictureBox2.Size = new System.Drawing.Size(45, 45);
            this.roundPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox2.TabIndex = 4;
            this.roundPictureBox2.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1212, 689);
            this.Controls.Add(this.Mainuser_pan);
            this.Controls.Add(this.MainCenter_pan);
            this.Controls.Add(this.MainLeft_pan);
            this.Controls.Add(this.MainTop_pan);
            this.Controls.Add(this.MainHeader_menustp);
            this.Font = new System.Drawing.Font("함초롬돋움", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainHeader_menustp;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MainTop_pan.ResumeLayout(false);
            this.MainTop_pan.PerformLayout();
            this.MainHeader_menustp.ResumeLayout(false);
            this.MainHeader_menustp.PerformLayout();
            this.MainLeft_pan.ResumeLayout(false);
            this.Mainuser_pan.ResumeLayout(false);
            this.Mainuser_pan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel MainTop_pan;
        private System.Windows.Forms.Label UserName_txt;
        private System.Windows.Forms.MenuStrip MainHeader_menustp;
        private System.Windows.Forms.ToolStripMenuItem 사용자ToolStripMenuItem;
        private System.Windows.Forms.Panel MainLeft_pan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel MainCenter_pan;
        private System.Windows.Forms.Panel Mainuser_pan;
        private System.Windows.Forms.Label m_Today_lbl;
        private System.Windows.Forms.Label FreindForm_btn;
        private System.Windows.Forms.Button MonthForm_btn;
        private System.Windows.Forms.Button WeekForm_btn;
        private System.Windows.Forms.Button PictureForm_btn;
        private System.Windows.Forms.Button TodoForm_btn;
        private System.Windows.Forms.ToolStripMenuItem 그룹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 할일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사진ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용자정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 그룹추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 할일추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구그룹추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 할일모두완료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 할일모두삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사진추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private UserCustomControl.RoundPictureBox roundPictureBox2;
    }
}

