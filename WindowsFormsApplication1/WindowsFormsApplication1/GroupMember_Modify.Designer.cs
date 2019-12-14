namespace WindowsFormsApplication1
{
    partial class GroupMember_Modify
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
            this.Close_btn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Mem_DBgrid = new System.Windows.Forms.DataGridView();
            this.Add_Mem_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Mem_DBgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_btn
            // 
            this.Close_btn.AutoSize = true;
            this.Close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.Location = new System.Drawing.Point(358, 10);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(33, 25);
            this.Close_btn.TabIndex = 3;
            this.Close_btn.Text = "✖";
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "그룹원 수정";
            // 
            // Mem_DBgrid
            // 
            this.Mem_DBgrid.BackgroundColor = System.Drawing.Color.White;
            this.Mem_DBgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mem_DBgrid.Location = new System.Drawing.Point(15, 50);
            this.Mem_DBgrid.Name = "Mem_DBgrid";
            this.Mem_DBgrid.RowTemplate.Height = 27;
            this.Mem_DBgrid.Size = new System.Drawing.Size(370, 200);
            this.Mem_DBgrid.TabIndex = 4;
            // 
            // Add_Mem_btn
            // 
            this.Add_Mem_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_Mem_btn.FlatAppearance.BorderSize = 0;
            this.Add_Mem_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Mem_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Mem_btn.Location = new System.Drawing.Point(160, 260);
            this.Add_Mem_btn.Name = "Add_Mem_btn";
            this.Add_Mem_btn.Size = new System.Drawing.Size(80, 30);
            this.Add_Mem_btn.TabIndex = 5;
            this.Add_Mem_btn.Text = "추가";
            this.Add_Mem_btn.UseVisualStyleBackColor = true;
            this.Add_Mem_btn.Click += new System.EventHandler(this.Add_Mem_btn_Click);
            this.Add_Mem_btn.MouseEnter += new System.EventHandler(this.btn_backcolor_MouseEnter);
            this.Add_Mem_btn.MouseLeave += new System.EventHandler(this.btn_backcolor_MouseLeave);
            // 
            // GroupMember_Modify
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.Add_Mem_btn);
            this.Controls.Add(this.Mem_DBgrid);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GroupMember_Modify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GroupMember_Modify";
            this.Load += new System.EventHandler(this.GroupMember_Modify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mem_DBgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Mem_DBgrid;
        private System.Windows.Forms.Button Add_Mem_btn;
    }
}