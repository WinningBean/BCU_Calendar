﻿namespace WindowsFormsApplication1
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
            this.m_Year_btn = new System.Windows.Forms.Label();
            this.m_Mon_pan = new System.Windows.Forms.Panel();
            this.m_Top_pan = new System.Windows.Forms.Panel();
            this.m_Main_pan = new System.Windows.Forms.Panel();
            this.m_Mid_pan = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_Mon_pan.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Year_btn
            // 
            this.m_Year_btn.AutoSize = true;
            this.m_Year_btn.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Year_btn.Location = new System.Drawing.Point(15, 15);
            this.m_Year_btn.Name = "m_Year_btn";
            this.m_Year_btn.Size = new System.Drawing.Size(79, 32);
            this.m_Year_btn.TabIndex = 4;
            this.m_Year_btn.Text = "APR";
            // 
            // m_Mon_pan
            // 
            this.m_Mon_pan.Controls.Add(this.m_Year_btn);
            this.m_Mon_pan.Location = new System.Drawing.Point(0, 0);
            this.m_Mon_pan.Name = "m_Mon_pan";
            this.m_Mon_pan.Size = new System.Drawing.Size(117, 64);
            this.m_Mon_pan.TabIndex = 6;
            // 
            // m_Top_pan
            // 
            this.m_Top_pan.Location = new System.Drawing.Point(117, 0);
            this.m_Top_pan.Name = "m_Top_pan";
            this.m_Top_pan.Size = new System.Drawing.Size(852, 64);
            this.m_Top_pan.TabIndex = 7;
            // 
            // m_Main_pan
            // 
            this.m_Main_pan.Location = new System.Drawing.Point(117, 89);
            this.m_Main_pan.Name = "m_Main_pan";
            this.m_Main_pan.Size = new System.Drawing.Size(852, 510);
            this.m_Main_pan.TabIndex = 7;
            // 
            // m_Mid_pan
            // 
            this.m_Mid_pan.BackColor = System.Drawing.Color.LightGray;
            this.m_Mid_pan.Location = new System.Drawing.Point(0, 64);
            this.m_Mid_pan.Name = "m_Mid_pan";
            this.m_Mid_pan.Size = new System.Drawing.Size(969, 28);
            this.m_Mid_pan.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 507);
            this.panel1.TabIndex = 9;
            // 
            // Week
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 598);
            this.Controls.Add(this.panel1);
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
            this.m_Mon_pan.ResumeLayout(false);
            this.m_Mon_pan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label m_Year_btn;
        private System.Windows.Forms.Panel m_Mon_pan;
        private System.Windows.Forms.Panel m_Top_pan;
        private System.Windows.Forms.Panel m_Main_pan;
        private System.Windows.Forms.Panel m_Mid_pan;
        private System.Windows.Forms.Panel panel1;
    }
}