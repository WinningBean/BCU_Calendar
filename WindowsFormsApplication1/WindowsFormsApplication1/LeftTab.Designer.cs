namespace WindowsFormsApplication1
{
    partial class LeftTab
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.line_1 = new System.Windows.Forms.Label();
            this.Private_SC_btn = new System.Windows.Forms.Label();
            this.Public_SC_btn = new System.Windows.Forms.Label();
            this.line_2 = new System.Windows.Forms.Label();
            this.line_3 = new System.Windows.Forms.Label();
            this.Goup_lbl = new System.Windows.Forms.Label();
            this.line_0 = new System.Windows.Forms.Label();
            this.bsGroup_lstbox = new System.Windows.Forms.ListBox();
            this.Add_GR_btn = new System.Windows.Forms.Label();
            this.SearchGR_txt = new System.Windows.Forms.TextBox();
            this.SEARCH_GR_btn = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.searchLine = new System.Windows.Forms.Label();
            this.schGroup_lstbox = new System.Windows.Forms.ListBox();
            this.bsGR_pan = new System.Windows.Forms.Panel();
            this.bsGR_pan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(10, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "일정";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line_1
            // 
            this.line_1.BackColor = System.Drawing.Color.LightGray;
            this.line_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.line_1.Location = new System.Drawing.Point(10, 42);
            this.line_1.Name = "line_1";
            this.line_1.Size = new System.Drawing.Size(223, 1);
            this.line_1.TabIndex = 1;
            this.line_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Private_SC_btn
            // 
            this.Private_SC_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Private_SC_btn.Location = new System.Drawing.Point(15, 78);
            this.Private_SC_btn.Name = "Private_SC_btn";
            this.Private_SC_btn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Private_SC_btn.Size = new System.Drawing.Size(213, 30);
            this.Private_SC_btn.TabIndex = 2;
            this.Private_SC_btn.Text = "비공개 일정";
            this.Private_SC_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Public_SC_btn
            // 
            this.Public_SC_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Public_SC_btn.Location = new System.Drawing.Point(15, 48);
            this.Public_SC_btn.Name = "Public_SC_btn";
            this.Public_SC_btn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Public_SC_btn.Size = new System.Drawing.Size(213, 30);
            this.Public_SC_btn.TabIndex = 3;
            this.Public_SC_btn.Text = "공개 일정";
            this.Public_SC_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line_2
            // 
            this.line_2.BackColor = System.Drawing.Color.LightGray;
            this.line_2.Cursor = System.Windows.Forms.Cursors.Default;
            this.line_2.Location = new System.Drawing.Point(10, 113);
            this.line_2.Name = "line_2";
            this.line_2.Size = new System.Drawing.Size(223, 1);
            this.line_2.TabIndex = 4;
            this.line_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line_3
            // 
            this.line_3.BackColor = System.Drawing.Color.LightGray;
            this.line_3.Cursor = System.Windows.Forms.Cursors.Default;
            this.line_3.Location = new System.Drawing.Point(10, 154);
            this.line_3.Name = "line_3";
            this.line_3.Size = new System.Drawing.Size(223, 1);
            this.line_3.TabIndex = 6;
            this.line_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Goup_lbl
            // 
            this.Goup_lbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.Goup_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Goup_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.Goup_lbl.Location = new System.Drawing.Point(10, 114);
            this.Goup_lbl.Name = "Goup_lbl";
            this.Goup_lbl.Size = new System.Drawing.Size(223, 40);
            this.Goup_lbl.TabIndex = 5;
            this.Goup_lbl.Text = "그룹";
            this.Goup_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Goup_lbl.Click += new System.EventHandler(this.Goup_lbl_Click);
            this.Goup_lbl.MouseHover += new System.EventHandler(this.Goup_lbl_MouseHover);
            // 
            // line_0
            // 
            this.line_0.BackColor = System.Drawing.Color.LightGray;
            this.line_0.Cursor = System.Windows.Forms.Cursors.Default;
            this.line_0.Location = new System.Drawing.Point(10, 1);
            this.line_0.Name = "line_0";
            this.line_0.Size = new System.Drawing.Size(223, 1);
            this.line_0.TabIndex = 7;
            this.line_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsGroup_lstbox
            // 
            this.bsGroup_lstbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bsGroup_lstbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bsGroup_lstbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsGroup_lstbox.FormattingEnabled = true;
            this.bsGroup_lstbox.ItemHeight = 30;
            this.bsGroup_lstbox.Location = new System.Drawing.Point(0, 0);
            this.bsGroup_lstbox.Name = "bsGroup_lstbox";
            this.bsGroup_lstbox.Size = new System.Drawing.Size(213, 30);
            this.bsGroup_lstbox.TabIndex = 8;
            this.bsGroup_lstbox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Group_lst_DrawItem);
            // 
            // Add_GR_btn
            // 
            this.Add_GR_btn.BackColor = System.Drawing.Color.Silver;
            this.Add_GR_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_GR_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Add_GR_btn.ForeColor = System.Drawing.Color.White;
            this.Add_GR_btn.Location = new System.Drawing.Point(203, 122);
            this.Add_GR_btn.Name = "Add_GR_btn";
            this.Add_GR_btn.Size = new System.Drawing.Size(25, 25);
            this.Add_GR_btn.TabIndex = 9;
            this.Add_GR_btn.Text = "✚";
            this.Add_GR_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Add_GR_btn.Click += new System.EventHandler(this.Add_GR_btn_Click);
            // 
            // SearchGR_txt
            // 
            this.SearchGR_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchGR_txt.Location = new System.Drawing.Point(15, 126);
            this.SearchGR_txt.Name = "SearchGR_txt";
            this.SearchGR_txt.Size = new System.Drawing.Size(183, 17);
            this.SearchGR_txt.TabIndex = 10;
            this.SearchGR_txt.Visible = false;
            // 
            // SEARCH_GR_btn
            // 
            this.SEARCH_GR_btn.BackColor = System.Drawing.Color.Silver;
            this.SEARCH_GR_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEARCH_GR_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCH_GR_btn.ForeColor = System.Drawing.Color.White;
            this.SEARCH_GR_btn.Location = new System.Drawing.Point(203, 122);
            this.SEARCH_GR_btn.Name = "SEARCH_GR_btn";
            this.SEARCH_GR_btn.Size = new System.Drawing.Size(25, 25);
            this.SEARCH_GR_btn.TabIndex = 11;
            this.SEARCH_GR_btn.Text = "⌕";
            this.SEARCH_GR_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SEARCH_GR_btn.Visible = false;
            this.SEARCH_GR_btn.Click += new System.EventHandler(this.SEARCH_GR_btn_Click);
            // 
            // searchLine
            // 
            this.searchLine.BackColor = System.Drawing.Color.Gainsboro;
            this.searchLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchLine.Location = new System.Drawing.Point(15, 147);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(183, 1);
            this.searchLine.TabIndex = 12;
            this.searchLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.searchLine.Visible = false;
            // 
            // schGroup_lstbox
            // 
            this.schGroup_lstbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schGroup_lstbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.schGroup_lstbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schGroup_lstbox.FormattingEnabled = true;
            this.schGroup_lstbox.ItemHeight = 30;
            this.schGroup_lstbox.Location = new System.Drawing.Point(15, 160);
            this.schGroup_lstbox.Name = "schGroup_lstbox";
            this.schGroup_lstbox.Size = new System.Drawing.Size(213, 30);
            this.schGroup_lstbox.TabIndex = 8;
            this.schGroup_lstbox.Visible = false;
            this.schGroup_lstbox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.SchGroup_lstbox_DrawItem);
            // 
            // bsGR_pan
            // 
            this.bsGR_pan.Controls.Add(this.bsGroup_lstbox);
            this.bsGR_pan.Location = new System.Drawing.Point(15, 160);
            this.bsGR_pan.Name = "bsGR_pan";
            this.bsGR_pan.Size = new System.Drawing.Size(213, 424);
            this.bsGR_pan.TabIndex = 13;
            // 
            // LeftTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 596);
            this.Controls.Add(this.searchLine);
            this.Controls.Add(this.SEARCH_GR_btn);
            this.Controls.Add(this.SearchGR_txt);
            this.Controls.Add(this.Add_GR_btn);
            this.Controls.Add(this.line_0);
            this.Controls.Add(this.line_3);
            this.Controls.Add(this.Goup_lbl);
            this.Controls.Add(this.line_2);
            this.Controls.Add(this.Public_SC_btn);
            this.Controls.Add(this.Private_SC_btn);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bsGR_pan);
            this.Controls.Add(this.schGroup_lstbox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LeftTab";
            this.Text = "LeftTab";
            this.Load += new System.EventHandler(this.LeftTab_Load);
            this.bsGR_pan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label Private_SC_btn;
        private System.Windows.Forms.Label Public_SC_btn;
        private System.Windows.Forms.Label line_2;
        private System.Windows.Forms.Label line_3;
        private System.Windows.Forms.Label Goup_lbl;
        private System.Windows.Forms.Label line_0;
        private System.Windows.Forms.ListBox bsGroup_lstbox;
        private System.Windows.Forms.Label Add_GR_btn;
        private System.Windows.Forms.TextBox SearchGR_txt;
        private System.Windows.Forms.Label SEARCH_GR_btn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label searchLine;
        private System.Windows.Forms.ListBox schGroup_lstbox;
        private System.Windows.Forms.Panel bsGR_pan;
    }
}