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
            this.label1 = new System.Windows.Forms.Label();
            this.line_1 = new System.Windows.Forms.Label();
            this.Private_SC_btn = new System.Windows.Forms.Label();
            this.Public_SC_btn = new System.Windows.Forms.Label();
            this.line_2 = new System.Windows.Forms.Label();
            this.line_3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.line_0 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("함초롬돋움", 10F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "일정";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line_1
            // 
            this.line_1.BackColor = System.Drawing.Color.LightGray;
            this.line_1.Location = new System.Drawing.Point(10, 47);
            this.line_1.Name = "line_1";
            this.line_1.Size = new System.Drawing.Size(223, 1);
            this.line_1.TabIndex = 1;
            this.line_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Private_SC_btn
            // 
            this.Private_SC_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Private_SC_btn.Location = new System.Drawing.Point(15, 93);
            this.Private_SC_btn.Name = "Private_SC_btn";
            this.Private_SC_btn.Size = new System.Drawing.Size(213, 25);
            this.Private_SC_btn.TabIndex = 2;
            this.Private_SC_btn.Text = "비공개 일정";
            this.Private_SC_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Public_SC_btn
            // 
            this.Public_SC_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Public_SC_btn.Location = new System.Drawing.Point(15, 58);
            this.Public_SC_btn.Name = "Public_SC_btn";
            this.Public_SC_btn.Size = new System.Drawing.Size(213, 25);
            this.Public_SC_btn.TabIndex = 3;
            this.Public_SC_btn.Text = "공개 일정";
            this.Public_SC_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line_2
            // 
            this.line_2.BackColor = System.Drawing.Color.LightGray;
            this.line_2.Location = new System.Drawing.Point(10, 128);
            this.line_2.Name = "line_2";
            this.line_2.Size = new System.Drawing.Size(223, 1);
            this.line_2.TabIndex = 4;
            this.line_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line_3
            // 
            this.line_3.BackColor = System.Drawing.Color.LightGray;
            this.line_3.Location = new System.Drawing.Point(10, 174);
            this.line_3.Name = "line_3";
            this.line_3.Size = new System.Drawing.Size(223, 1);
            this.line_3.TabIndex = 6;
            this.line_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("함초롬돋움", 10F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(10, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "그룹";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line_0
            // 
            this.line_0.BackColor = System.Drawing.Color.LightGray;
            this.line_0.Location = new System.Drawing.Point(10, 1);
            this.line_0.Name = "line_0";
            this.line_0.Size = new System.Drawing.Size(223, 1);
            this.line_0.TabIndex = 7;
            this.line_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 30;
            this.listBox1.Location = new System.Drawing.Point(15, 180);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(213, 390);
            this.listBox1.TabIndex = 8;
            // 
            // LeftTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(243, 596);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.line_0);
            this.Controls.Add(this.line_3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.line_2);
            this.Controls.Add(this.Public_SC_btn);
            this.Controls.Add(this.Private_SC_btn);
            this.Controls.Add(this.line_1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("함초롬돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LeftTab";
            this.Text = "LeftTab";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label line_1;
        private System.Windows.Forms.Label Private_SC_btn;
        private System.Windows.Forms.Label Public_SC_btn;
        private System.Windows.Forms.Label line_2;
        private System.Windows.Forms.Label line_3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label line_0;
        private System.Windows.Forms.ListBox listBox1;
    }
}