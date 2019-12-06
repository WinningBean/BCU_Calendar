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
            this.m_PB_lb = new System.Windows.Forms.Label();
            this.modify_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_CD_lb
            // 
            this.m_CD_lb.AutoSize = true;
            this.m_CD_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_CD_lb.Location = new System.Drawing.Point(29, 19);
            this.m_CD_lb.Name = "m_CD_lb";
            this.m_CD_lb.Size = new System.Drawing.Size(75, 23);
            this.m_CD_lb.TabIndex = 0;
            this.m_CD_lb.Text = "label1";
            // 
            // DT_lb
            // 
            this.DT_lb.AutoSize = true;
            this.DT_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_lb.Location = new System.Drawing.Point(29, 83);
            this.DT_lb.Name = "DT_lb";
            this.DT_lb.Size = new System.Drawing.Size(102, 23);
            this.DT_lb.TabIndex = 0;
            this.DT_lb.Text = "사진 등록일 :";
            // 
            // m_DT_lb
            // 
            this.m_DT_lb.AutoSize = true;
            this.m_DT_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_DT_lb.Location = new System.Drawing.Point(135, 83);
            this.m_DT_lb.Name = "m_DT_lb";
            this.m_DT_lb.Size = new System.Drawing.Size(51, 23);
            this.m_DT_lb.TabIndex = 0;
            this.m_DT_lb.Text = "text";
            // 
            // PB_lb
            // 
            this.PB_lb.AutoSize = true;
            this.PB_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PB_lb.Location = new System.Drawing.Point(44, 134);
            this.PB_lb.Name = "PB_lb";
            this.PB_lb.Size = new System.Drawing.Size(87, 23);
            this.PB_lb.TabIndex = 0;
            this.PB_lb.Text = "사진 공개 :";
            // 
            // m_PB_lb
            // 
            this.m_PB_lb.AutoSize = true;
            this.m_PB_lb.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PB_lb.Location = new System.Drawing.Point(135, 134);
            this.m_PB_lb.Name = "m_PB_lb";
            this.m_PB_lb.Size = new System.Drawing.Size(51, 23);
            this.m_PB_lb.TabIndex = 0;
            this.m_PB_lb.Text = "text";
            // 
            // modify_btn
            // 
            this.modify_btn.Location = new System.Drawing.Point(29, 184);
            this.modify_btn.Name = "modify_btn";
            this.modify_btn.Size = new System.Drawing.Size(75, 23);
            this.modify_btn.TabIndex = 1;
            this.modify_btn.Text = "수정";
            this.modify_btn.UseVisualStyleBackColor = true;
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(124, 184);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 1;
            this.delete_btn.Text = "삭제";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // Picture_Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 229);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.modify_btn);
            this.Controls.Add(this.m_PB_lb);
            this.Controls.Add(this.m_DT_lb);
            this.Controls.Add(this.PB_lb);
            this.Controls.Add(this.DT_lb);
            this.Controls.Add(this.m_CD_lb);
            this.Name = "Picture_Modify";
            this.Text = "Picture_Modify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_CD_lb;
        private System.Windows.Forms.Label DT_lb;
        private System.Windows.Forms.Label m_DT_lb;
        private System.Windows.Forms.Label PB_lb;
        private System.Windows.Forms.Label m_PB_lb;
        private System.Windows.Forms.Button modify_btn;
        private System.Windows.Forms.Button delete_btn;
    }
}