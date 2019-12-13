namespace WindowsFormsApplication1
{
    partial class Week
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
            this.m_Month_lab = new System.Windows.Forms.Label();
            this.m_Mon_pan = new System.Windows.Forms.Panel();
            this.m_Year_lab = new System.Windows.Forms.Label();
            this.m_Top_pan = new System.Windows.Forms.Panel();
            this.m_Main_pan = new System.Windows.Forms.Panel();
            this.m_Mid_pan = new System.Windows.Forms.Panel();
            this.m_Right_btn = new System.Windows.Forms.Button();
            this.m_Left_btn = new System.Windows.Forms.Button();
            this.m_Str_focus = new System.Windows.Forms.Label();
            this.m_Mon_pan.SuspendLayout();
            this.m_Mid_pan.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Month_lab
            // 
            this.m_Month_lab.AutoSize = true;
            this.m_Month_lab.BackColor = System.Drawing.Color.Transparent;
            this.m_Month_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Month_lab.Location = new System.Drawing.Point(44, 27);
            this.m_Month_lab.Name = "m_Month_lab";
            this.m_Month_lab.Size = new System.Drawing.Size(98, 34);
            this.m_Month_lab.TabIndex = 4;
            this.m_Month_lab.Text = "Month";
            // 
            // m_Mon_pan
            // 
            this.m_Mon_pan.Controls.Add(this.m_Year_lab);
            this.m_Mon_pan.Controls.Add(this.m_Month_lab);
            this.m_Mon_pan.Location = new System.Drawing.Point(0, 0);
            this.m_Mon_pan.Name = "m_Mon_pan";
            this.m_Mon_pan.Size = new System.Drawing.Size(91, 63);
            this.m_Mon_pan.TabIndex = 6;
            // 
            // m_Year_lab
            // 
            this.m_Year_lab.AutoSize = true;
            this.m_Year_lab.BackColor = System.Drawing.Color.Transparent;
            this.m_Year_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Year_lab.Location = new System.Drawing.Point(-1, 0);
            this.m_Year_lab.Name = "m_Year_lab";
            this.m_Year_lab.Size = new System.Drawing.Size(100, 41);
            this.m_Year_lab.TabIndex = 4;
            this.m_Year_lab.Text = "YEAR";
            // 
            // m_Top_pan
            // 
            this.m_Top_pan.Location = new System.Drawing.Point(91, 0);
            this.m_Top_pan.Name = "m_Top_pan";
            this.m_Top_pan.Size = new System.Drawing.Size(878, 64);
            this.m_Top_pan.TabIndex = 7;
            // 
            // m_Main_pan
            // 
            this.m_Main_pan.Location = new System.Drawing.Point(1, 92);
            this.m_Main_pan.Name = "m_Main_pan";
            this.m_Main_pan.Size = new System.Drawing.Size(966, 504);
            this.m_Main_pan.TabIndex = 7;
            // 
            // m_Mid_pan
            // 
            this.m_Mid_pan.BackColor = System.Drawing.Color.LightGray;
            this.m_Mid_pan.Controls.Add(this.m_Right_btn);
            this.m_Mid_pan.Controls.Add(this.m_Left_btn);
            this.m_Mid_pan.Controls.Add(this.m_Str_focus);
            this.m_Mid_pan.Location = new System.Drawing.Point(0, 64);
            this.m_Mid_pan.Name = "m_Mid_pan";
            this.m_Mid_pan.Size = new System.Drawing.Size(969, 28);
            this.m_Mid_pan.TabIndex = 8;
            // 
            // m_Right_btn
            // 
            this.m_Right_btn.BackColor = System.Drawing.Color.LightGray;
            this.m_Right_btn.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.m_Right_btn.Location = new System.Drawing.Point(917, 1);
            this.m_Right_btn.Name = "m_Right_btn";
            this.m_Right_btn.Size = new System.Drawing.Size(49, 25);
            this.m_Right_btn.TabIndex = 1;
            this.m_Right_btn.Text = ">";
            this.m_Right_btn.UseVisualStyleBackColor = false;
            this.m_Right_btn.Click += new System.EventHandler(this.m_Right_btn_Click);
            // 
            // m_Left_btn
            // 
            this.m_Left_btn.BackColor = System.Drawing.Color.LightGray;
            this.m_Left_btn.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.m_Left_btn.Location = new System.Drawing.Point(3, 1);
            this.m_Left_btn.Name = "m_Left_btn";
            this.m_Left_btn.Size = new System.Drawing.Size(49, 25);
            this.m_Left_btn.TabIndex = 1;
            this.m_Left_btn.Text = "<";
            this.m_Left_btn.UseVisualStyleBackColor = false;
            this.m_Left_btn.Click += new System.EventHandler(this.m_Left_btn_Click);
            // 
            // m_Str_focus
            // 
            this.m_Str_focus.AutoSize = true;
            this.m_Str_focus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Str_focus.Location = new System.Drawing.Point(71, 3);
            this.m_Str_focus.Name = "m_Str_focus";
            this.m_Str_focus.Size = new System.Drawing.Size(53, 20);
            this.m_Str_focus.TabIndex = 0;
            this.m_Str_focus.Text = "label1";
            // 
            // Week
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 598);
            this.Controls.Add(this.m_Mid_pan);
            this.Controls.Add(this.m_Main_pan);
            this.Controls.Add(this.m_Top_pan);
            this.Controls.Add(this.m_Mon_pan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(-5, 64);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Week";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Week";
            this.Load += new System.EventHandler(this.Week_Load);
            this.m_Mon_pan.ResumeLayout(false);
            this.m_Mon_pan.PerformLayout();
            this.m_Mid_pan.ResumeLayout(false);
            this.m_Mid_pan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label m_Month_lab;
        private System.Windows.Forms.Panel m_Mon_pan;
        private System.Windows.Forms.Panel m_Top_pan;
        private System.Windows.Forms.Panel m_Main_pan;
        private System.Windows.Forms.Panel m_Mid_pan;
        private System.Windows.Forms.Label m_Str_focus;
        private System.Windows.Forms.Button m_Right_btn;
        private System.Windows.Forms.Button m_Left_btn;
        private System.Windows.Forms.Label m_Year_lab;
    }
}