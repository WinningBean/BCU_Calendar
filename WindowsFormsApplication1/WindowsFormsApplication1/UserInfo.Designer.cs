namespace WindowsFormsApplication1
{
    partial class UserInfo
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
            this.profile1 = new UserCustomControl.Profile();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.MainHeader_menustp = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.최소화toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainHeader_menustp.SuspendLayout();
            this.SuspendLayout();
            // 
            // profile1
            // 
            this.profile1.BackColor = System.Drawing.Color.Transparent;
            this.profile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.profile1.Location = new System.Drawing.Point(0, 28);
            this.profile1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(304, 70);
            this.profile1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(178, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(178, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "회원정보 수정";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "회원탈퇴";
            this.button2.UseVisualStyleBackColor = true;
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
            this.MainHeader_menustp.Size = new System.Drawing.Size(295, 24);
            this.MainHeader_menustp.TabIndex = 7;
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
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 204);
            this.Controls.Add(this.MainHeader_menustp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profile1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfo";
            this.Text = "UserInfo";
            this.MainHeader_menustp.ResumeLayout(false);
            this.MainHeader_menustp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserCustomControl.Profile profile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip MainHeader_menustp;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 최소화toolStripMenuItem;
    }
}