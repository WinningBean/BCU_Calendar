namespace Shared_Calendar
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
            this.m_Year_lab = new System.Windows.Forms.Label();
            this.m_Top_pan = new System.Windows.Forms.Panel();
            this.m_Right_btn = new System.Windows.Forms.Button();
            this.m_Left_btn = new System.Windows.Forms.Button();
            this.m_Str_focus = new System.Windows.Forms.Label();
            this.m_Main_pan = new System.Windows.Forms.Panel();
            this.m_Main_pan.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Month_lab
            // 
            this.m_Month_lab.AutoSize = true;
            this.m_Month_lab.BackColor = System.Drawing.Color.Transparent;
            this.m_Month_lab.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Month_lab.Location = new System.Drawing.Point(4, 15);
            this.m_Month_lab.Name = "m_Month_lab";
            this.m_Month_lab.Size = new System.Drawing.Size(84, 29);
            this.m_Month_lab.TabIndex = 4;
            this.m_Month_lab.Text = "Month";
            // 
            // m_Year_lab
            // 
            this.m_Year_lab.AutoSize = true;
            this.m_Year_lab.BackColor = System.Drawing.Color.Transparent;
            this.m_Year_lab.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Year_lab.Location = new System.Drawing.Point(-4, -4);
            this.m_Year_lab.Name = "m_Year_lab";
            this.m_Year_lab.Size = new System.Drawing.Size(54, 20);
            this.m_Year_lab.TabIndex = 4;
            this.m_Year_lab.Text = "YEAR";
            // 
            // m_Top_pan
            // 
            this.m_Top_pan.Location = new System.Drawing.Point(91, 0);
            this.m_Top_pan.Name = "m_Top_pan";
            this.m_Top_pan.Size = new System.Drawing.Size(865, 38);
            this.m_Top_pan.TabIndex = 0;
            // 
            // m_Right_btn
            // 
            this.m_Right_btn.BackColor = System.Drawing.Color.Transparent;
            this.m_Right_btn.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.m_Right_btn.FlatAppearance.BorderSize = 0;
            this.m_Right_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_Right_btn.Location = new System.Drawing.Point(953, 0);
            this.m_Right_btn.Name = "m_Right_btn";
            this.m_Right_btn.Size = new System.Drawing.Size(23, 38);
            this.m_Right_btn.TabIndex = 0;
            this.m_Right_btn.Text = ">";
            this.m_Right_btn.UseVisualStyleBackColor = false;
            this.m_Right_btn.Click += new System.EventHandler(this.m_Right_btn_Click);
            // 
            // m_Left_btn
            // 
            this.m_Left_btn.BackColor = System.Drawing.Color.Transparent;
            this.m_Left_btn.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.m_Left_btn.FlatAppearance.BorderSize = 0;
            this.m_Left_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_Left_btn.Location = new System.Drawing.Point(80, -3);
            this.m_Left_btn.Name = "m_Left_btn";
            this.m_Left_btn.Size = new System.Drawing.Size(18, 42);
            this.m_Left_btn.TabIndex = 0;
            this.m_Left_btn.Text = "<";
            this.m_Left_btn.UseVisualStyleBackColor = false;
            this.m_Left_btn.Click += new System.EventHandler(this.m_Left_btn_Click);
            // 
            // m_Str_focus
            // 
            this.m_Str_focus.AutoSize = true;
            this.m_Str_focus.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Str_focus.Location = new System.Drawing.Point(-3, -14);
            this.m_Str_focus.Name = "m_Str_focus";
            this.m_Str_focus.Size = new System.Drawing.Size(46, 17);
            this.m_Str_focus.TabIndex = 0;
            this.m_Str_focus.Text = "label1";
            // 
            // m_Main_pan
            // 
            this.m_Main_pan.Controls.Add(this.m_Str_focus);
            this.m_Main_pan.Location = new System.Drawing.Point(1, 38);
            this.m_Main_pan.Name = "m_Main_pan";
            this.m_Main_pan.Size = new System.Drawing.Size(966, 558);
            this.m_Main_pan.TabIndex = 7;
            // 
            // Week
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 598);
            this.Controls.Add(this.m_Right_btn);
            this.Controls.Add(this.m_Year_lab);
            this.Controls.Add(this.m_Left_btn);
            this.Controls.Add(this.m_Month_lab);
            this.Controls.Add(this.m_Main_pan);
            this.Controls.Add(this.m_Top_pan);
            this.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(-5, 64);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Week";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Week";
            this.Load += new System.EventHandler(this.Week_Load);
            this.m_Main_pan.ResumeLayout(false);
            this.m_Main_pan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label m_Month_lab;
        private System.Windows.Forms.Panel m_Top_pan;
        private System.Windows.Forms.Panel m_Main_pan;
        private System.Windows.Forms.Label m_Str_focus;
        private System.Windows.Forms.Button m_Right_btn;
        private System.Windows.Forms.Button m_Left_btn;
        private System.Windows.Forms.Label m_Year_lab;
    }
}