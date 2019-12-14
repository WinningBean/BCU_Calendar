namespace WindowsFormsApplication1
{
    partial class FriendList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.line_3 = new System.Windows.Forms.Label();
            this.SearchFR_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SEARCH_FR_btn = new System.Windows.Forms.Label();
            this.search_pan = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Friend_lbl = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 505);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 545);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(126, 122);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 33);
            this.button4.TabIndex = 7;
            this.button4.Text = "취소";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(23, 122);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 33);
            this.button3.TabIndex = 1;
            this.button3.Text = "확인";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 95);
            this.label1.TabIndex = 0;
            this.label1.Text = "검색하신 이름의 친구가 없습니다 친구를 추가 하시겠습니까?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line_3
            // 
            this.line_3.BackColor = System.Drawing.Color.LightGray;
            this.line_3.Cursor = System.Windows.Forms.Cursors.Default;
            this.line_3.Location = new System.Drawing.Point(8, 47);
            this.line_3.Name = "line_3";
            this.line_3.Size = new System.Drawing.Size(223, 1);
            this.line_3.TabIndex = 13;
            this.line_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchFR_txt
            // 
            this.SearchFR_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchFR_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchFR_txt.Location = new System.Drawing.Point(40, 12);
            this.SearchFR_txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchFR_txt.Multiline = true;
            this.SearchFR_txt.Name = "SearchFR_txt";
            this.SearchFR_txt.Size = new System.Drawing.Size(98, 25);
            this.SearchFR_txt.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(37, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 1);
            this.label2.TabIndex = 16;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(13, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 1);
            this.label3.TabIndex = 17;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SEARCH_FR_btn
            // 
            this.SEARCH_FR_btn.BackColor = System.Drawing.Color.Silver;
            this.SEARCH_FR_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEARCH_FR_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCH_FR_btn.ForeColor = System.Drawing.Color.White;
            this.SEARCH_FR_btn.Location = new System.Drawing.Point(172, 12);
            this.SEARCH_FR_btn.Name = "SEARCH_FR_btn";
            this.SEARCH_FR_btn.Size = new System.Drawing.Size(25, 25);
            this.SEARCH_FR_btn.TabIndex = 18;
            this.SEARCH_FR_btn.Text = "⌕";
            this.SEARCH_FR_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SEARCH_FR_btn.Visible = false;
            this.SEARCH_FR_btn.Click += new System.EventHandler(this.SEARCH_FR_btn_Click);
            // 
            // search_pan
            // 
            this.search_pan.Location = new System.Drawing.Point(24, 94);
            this.search_pan.Name = "search_pan";
            this.search_pan.Size = new System.Drawing.Size(197, 480);
            this.search_pan.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 1);
            this.label4.TabIndex = 19;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Friend_lbl
            // 
            this.Friend_lbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.Friend_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Friend_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.Friend_lbl.Location = new System.Drawing.Point(11, 53);
            this.Friend_lbl.Name = "Friend_lbl";
            this.Friend_lbl.Size = new System.Drawing.Size(223, 40);
            this.Friend_lbl.TabIndex = 20;
            this.Friend_lbl.Text = "친구 총 0명";
            this.Friend_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FriendList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 596);
            this.Controls.Add(this.search_pan);
            this.Controls.Add(this.SEARCH_FR_btn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchFR_txt);
            this.Controls.Add(this.line_3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Friend_lbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FriendList";
            this.Text = "FriendList";
            this.Load += new System.EventHandler(this.FriendList_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label line_3;
        private System.Windows.Forms.TextBox SearchFR_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SEARCH_FR_btn;
        private System.Windows.Forms.Panel search_pan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Friend_lbl;
    }
}