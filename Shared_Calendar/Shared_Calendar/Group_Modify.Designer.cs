namespace Shared_Calendar
{
    partial class Group_Modify
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
            this.Close_btn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GR_ex_txt = new System.Windows.Forms.TextBox();
            this.GR_nm_txt = new System.Windows.Forms.TextBox();
            this.AddGR_btn = new System.Windows.Forms.Label();
            this.ModiGR_btn = new System.Windows.Forms.Label();
            this.DeleGR_btn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "그룹 추가";
            // 
            // Close_btn
            // 
            this.Close_btn.AutoSize = true;
            this.Close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.Location = new System.Drawing.Point(308, 10);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(33, 25);
            this.Close_btn.TabIndex = 1;
            this.Close_btn.Text = "✖";
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "그룹명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "그룹 설명";
            // 
            // GR_ex_txt
            // 
            this.GR_ex_txt.Location = new System.Drawing.Point(94, 92);
            this.GR_ex_txt.MaxLength = 300;
            this.GR_ex_txt.Multiline = true;
            this.GR_ex_txt.Name = "GR_ex_txt";
            this.GR_ex_txt.Size = new System.Drawing.Size(235, 75);
            this.GR_ex_txt.TabIndex = 4;
            // 
            // GR_nm_txt
            // 
            this.GR_nm_txt.Location = new System.Drawing.Point(94, 57);
            this.GR_nm_txt.MaxLength = 50;
            this.GR_nm_txt.Name = "GR_nm_txt";
            this.GR_nm_txt.Size = new System.Drawing.Size(235, 24);
            this.GR_nm_txt.TabIndex = 5;
            // 
            // AddGR_btn
            // 
            this.AddGR_btn.AutoSize = true;
            this.AddGR_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddGR_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddGR_btn.Location = new System.Drawing.Point(154, 177);
            this.AddGR_btn.Name = "AddGR_btn";
            this.AddGR_btn.Size = new System.Drawing.Size(42, 25);
            this.AddGR_btn.TabIndex = 6;
            this.AddGR_btn.Text = "추가";
            this.AddGR_btn.Click += new System.EventHandler(this.AddGR_btn_Click);
            // 
            // ModiGR_btn
            // 
            this.ModiGR_btn.AutoSize = true;
            this.ModiGR_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModiGR_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModiGR_btn.Location = new System.Drawing.Point(74, 177);
            this.ModiGR_btn.Name = "ModiGR_btn";
            this.ModiGR_btn.Size = new System.Drawing.Size(42, 25);
            this.ModiGR_btn.TabIndex = 7;
            this.ModiGR_btn.Text = "수정";
            this.ModiGR_btn.Visible = false;
            this.ModiGR_btn.Click += new System.EventHandler(this.ModiGR_btn_Click);
            // 
            // DeleGR_btn
            // 
            this.DeleGR_btn.AutoSize = true;
            this.DeleGR_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleGR_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleGR_btn.Location = new System.Drawing.Point(234, 177);
            this.DeleGR_btn.Name = "DeleGR_btn";
            this.DeleGR_btn.Size = new System.Drawing.Size(42, 25);
            this.DeleGR_btn.TabIndex = 8;
            this.DeleGR_btn.Text = "삭제";
            this.DeleGR_btn.Visible = false;
            this.DeleGR_btn.Click += new System.EventHandler(this.DeleGR_btn_Click);
            // 
            // Group_Modify
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 212);
            this.Controls.Add(this.DeleGR_btn);
            this.Controls.Add(this.ModiGR_btn);
            this.Controls.Add(this.AddGR_btn);
            this.Controls.Add(this.GR_nm_txt);
            this.Controls.Add(this.GR_ex_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Group_Modify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group_Add";
            this.Load += new System.EventHandler(this.Group_Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Close_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GR_ex_txt;
        private System.Windows.Forms.TextBox GR_nm_txt;
        private System.Windows.Forms.Label AddGR_btn;
        private System.Windows.Forms.Label ModiGR_btn;
        private System.Windows.Forms.Label DeleGR_btn;
    }
}