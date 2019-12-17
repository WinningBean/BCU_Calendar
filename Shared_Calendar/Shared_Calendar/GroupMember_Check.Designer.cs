namespace Shared_Calendar
{
    partial class GroupMember_Check
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
            this.Group_dbgrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Group_dbgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_btn
            // 
            this.Close_btn.AutoSize = true;
            this.Close_btn.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.Location = new System.Drawing.Point(258, 10);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(33, 25);
            this.Close_btn.TabIndex = 3;
            this.Close_btn.Text = "✖";
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "그룹 신청 목록";
            // 
            // Group_dbgrid
            // 
            this.Group_dbgrid.BackgroundColor = System.Drawing.Color.White;
            this.Group_dbgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Group_dbgrid.Location = new System.Drawing.Point(15, 51);
            this.Group_dbgrid.Name = "Group_dbgrid";
            this.Group_dbgrid.RowTemplate.Height = 27;
            this.Group_dbgrid.Size = new System.Drawing.Size(270, 237);
            this.Group_dbgrid.TabIndex = 4;
            // 
            // GroupMember_Check
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.Group_dbgrid);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GroupMember_Check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GroupMember_Check";
            this.Load += new System.EventHandler(this.GroupMember_Check_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Group_dbgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Group_dbgrid;
    }
}