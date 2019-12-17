namespace Shared_Calendar
{
    partial class DiaryList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.private_btn = new System.Windows.Forms.Button();
            this.public_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 608);
            this.panel1.TabIndex = 2;
            // 
            // private_btn
            // 
            this.private_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.private_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.private_btn.Location = new System.Drawing.Point(201, 35);
            this.private_btn.Margin = new System.Windows.Forms.Padding(0);
            this.private_btn.Name = "private_btn";
            this.private_btn.Size = new System.Drawing.Size(55, 30);
            this.private_btn.TabIndex = 11;
            this.private_btn.Text = "비공개";
            this.private_btn.UseVisualStyleBackColor = true;
            this.private_btn.Click += new System.EventHandler(this.private_btn_Click);
            // 
            // public_btn
            // 
            this.public_btn.BackColor = System.Drawing.Color.Gainsboro;
            this.public_btn.Enabled = false;
            this.public_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.public_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.public_btn.Location = new System.Drawing.Point(147, 35);
            this.public_btn.Margin = new System.Windows.Forms.Padding(0);
            this.public_btn.Name = "public_btn";
            this.public_btn.Size = new System.Drawing.Size(55, 30);
            this.public_btn.TabIndex = 10;
            this.public_btn.Text = "공개";
            this.public_btn.UseVisualStyleBackColor = false;
            this.public_btn.Click += new System.EventHandler(this.public_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(245, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 31);
            this.label1.TabIndex = 39;
            this.label1.Text = "Diary List";
            // 
            // DiaryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(282, 689);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.private_btn);
            this.Controls.Add(this.public_btn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiaryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DiaryList";
            this.Load += new System.EventHandler(this.DiaryList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button private_btn;
        private System.Windows.Forms.Button public_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}