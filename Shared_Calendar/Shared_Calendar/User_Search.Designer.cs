namespace Shared_Calendar
{
    partial class User_Search
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
            this.User_DBgrid = new System.Windows.Forms.DataGridView();
            this.Close_btn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchLine = new System.Windows.Forms.Label();
            this.SEARCH_UR_btn = new System.Windows.Forms.Label();
            this.SearchUR_txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.User_DBgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // User_DBgrid
            // 
            this.User_DBgrid.BackgroundColor = System.Drawing.Color.White;
            this.User_DBgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_DBgrid.Location = new System.Drawing.Point(15, 90);
            this.User_DBgrid.Name = "User_DBgrid";
            this.User_DBgrid.RowTemplate.Height = 27;
            this.User_DBgrid.Size = new System.Drawing.Size(370, 200);
            this.User_DBgrid.TabIndex = 8;
            // 
            // Close_btn
            // 
            this.Close_btn.AutoSize = true;
            this.Close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.Location = new System.Drawing.Point(358, 10);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(33, 25);
            this.Close_btn.TabIndex = 7;
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
            this.label1.TabIndex = 6;
            this.label1.Text = "그룹원 추가";
            // 
            // searchLine
            // 
            this.searchLine.BackColor = System.Drawing.Color.Gainsboro;
            this.searchLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchLine.Location = new System.Drawing.Point(15, 75);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(330, 1);
            this.searchLine.TabIndex = 16;
            this.searchLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SEARCH_UR_btn
            // 
            this.SEARCH_UR_btn.BackColor = System.Drawing.Color.Silver;
            this.SEARCH_UR_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEARCH_UR_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCH_UR_btn.ForeColor = System.Drawing.Color.White;
            this.SEARCH_UR_btn.Location = new System.Drawing.Point(360, 50);
            this.SEARCH_UR_btn.Name = "SEARCH_UR_btn";
            this.SEARCH_UR_btn.Size = new System.Drawing.Size(25, 25);
            this.SEARCH_UR_btn.TabIndex = 15;
            this.SEARCH_UR_btn.Text = "⌕";
            this.SEARCH_UR_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SEARCH_UR_btn.Click += new System.EventHandler(this.SEARCH_UR_btn_Click);
            // 
            // SearchUR_txt
            // 
            this.SearchUR_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchUR_txt.Location = new System.Drawing.Point(15, 54);
            this.SearchUR_txt.Name = "SearchUR_txt";
            this.SearchUR_txt.Size = new System.Drawing.Size(330, 17);
            this.SearchUR_txt.TabIndex = 14;
            // 
            // User_Search
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 305);
            this.Controls.Add(this.searchLine);
            this.Controls.Add(this.SEARCH_UR_btn);
            this.Controls.Add(this.SearchUR_txt);
            this.Controls.Add(this.User_DBgrid);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "User_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User_Search";
            this.Load += new System.EventHandler(this.User_Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User_DBgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView User_DBgrid;
        private System.Windows.Forms.Label Close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label searchLine;
        private System.Windows.Forms.Label SEARCH_UR_btn;
        private System.Windows.Forms.TextBox SearchUR_txt;
    }
}