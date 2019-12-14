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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_ID_tb = new System.Windows.Forms.TextBox();
            this.m_PW_tb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.profile1 = new UserCustomControl.Profile();
            this.label3 = new System.Windows.Forms.Label();
            this.m_PWCheck_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_Name_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "아이디 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "패스워드 :";
            // 
            // m_ID_tb
            // 
            this.m_ID_tb.Location = new System.Drawing.Point(183, 127);
            this.m_ID_tb.Name = "m_ID_tb";
            this.m_ID_tb.Size = new System.Drawing.Size(100, 21);
            this.m_ID_tb.TabIndex = 3;
            // 
            // m_PW_tb
            // 
            this.m_PW_tb.Location = new System.Drawing.Point(183, 154);
            this.m_PW_tb.Name = "m_PW_tb";
            this.m_PW_tb.Size = new System.Drawing.Size(100, 21);
            this.m_PW_tb.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "회원정보 수정";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "회원탈퇴";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // profile1
            // 
            this.profile1.BackColor = System.Drawing.Color.Transparent;
            this.profile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.profile1.Location = new System.Drawing.Point(0, 29);
            this.profile1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(304, 70);
            this.profile1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "패스워드 확인 :";
            // 
            // m_PWCheck_tb
            // 
            this.m_PWCheck_tb.Location = new System.Drawing.Point(183, 179);
            this.m_PWCheck_tb.Name = "m_PWCheck_tb";
            this.m_PWCheck_tb.PasswordChar = '*';
            this.m_PWCheck_tb.Size = new System.Drawing.Size(100, 21);
            this.m_PWCheck_tb.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "이름 : ";
            // 
            // m_Name_tb
            // 
            this.m_Name_tb.Location = new System.Drawing.Point(183, 100);
            this.m_Name_tb.Name = "m_Name_tb";
            this.m_Name_tb.Size = new System.Drawing.Size(100, 21);
            this.m_Name_tb.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(267, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(295, 241);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_PWCheck_tb);
            this.Controls.Add(this.m_PW_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_Name_tb);
            this.Controls.Add(this.m_ID_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profile1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfo";
            this.Text = "UserInfo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserInfo_FormClosed);
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_ID_tb;
        private System.Windows.Forms.TextBox m_PW_tb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private UserCustomControl.Profile profile1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_PWCheck_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_Name_tb;
        private System.Windows.Forms.Label label5;
    }
}