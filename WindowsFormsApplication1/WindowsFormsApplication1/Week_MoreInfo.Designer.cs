namespace WindowsFormsApplication1
{
    partial class Week_MoreInfo
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
            this.m_LiView_info = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // m_LiView_info
            // 
            this.m_LiView_info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_LiView_info.Location = new System.Drawing.Point(1, 1);
            this.m_LiView_info.MultiSelect = false;
            this.m_LiView_info.Name = "m_LiView_info";
            this.m_LiView_info.Size = new System.Drawing.Size(507, 179);
            this.m_LiView_info.TabIndex = 2;
            this.m_LiView_info.UseCompatibleStateImageBehavior = false;
            this.m_LiView_info.View = System.Windows.Forms.View.Details;
            this.m_LiView_info.SelectedIndexChanged += new System.EventHandler(this.m_LiView_info_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "일정명";
            this.columnHeader1.Width = 89;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "시작일시";
            this.columnHeader2.Width = 168;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "종료일시";
            this.columnHeader3.Width = 166;
            // 
            // Week_MoreInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 181);
            this.Controls.Add(this.m_LiView_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Week_MoreInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Week_MoreInfo";
            this.Deactivate += new System.EventHandler(this.Week_MoreInfo_Deactivate);
            this.LocationChanged += new System.EventHandler(this.Week_MoreInfo_LocationChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView m_LiView_info;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}