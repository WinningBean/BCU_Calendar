namespace WindowsFormsApplication1
{
    partial class Picture
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_Small_btn = new System.Windows.Forms.Label();
            this.m_Zoom_btn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Picture_pan = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_Small_btn);
            this.panel1.Controls.Add(this.m_Zoom_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 51);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(253, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft New Tai Lue", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "ADD";
            this.label4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label4_MouseClick);
            // 
            // m_Small_btn
            // 
            this.m_Small_btn.AutoSize = true;
            this.m_Small_btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.m_Small_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Small_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_Small_btn.Location = new System.Drawing.Point(190, 26);
            this.m_Small_btn.Name = "m_Small_btn";
            this.m_Small_btn.Size = new System.Drawing.Size(57, 20);
            this.m_Small_btn.TabIndex = 1;
            this.m_Small_btn.Text = "목록보기";
            this.m_Small_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_Small_btn.Click += new System.EventHandler(this.m_Small_btn_Click);
            // 
            // m_Zoom_btn
            // 
            this.m_Zoom_btn.AutoSize = true;
            this.m_Zoom_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_Zoom_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Zoom_btn.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.m_Zoom_btn.Location = new System.Drawing.Point(190, 2);
            this.m_Zoom_btn.Name = "m_Zoom_btn";
            this.m_Zoom_btn.Size = new System.Drawing.Size(57, 20);
            this.m_Zoom_btn.TabIndex = 0;
            this.m_Zoom_btn.Text = "크게보기";
            this.m_Zoom_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_Zoom_btn.Click += new System.EventHandler(this.m_Zoom_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Picture";
            // 
            // Picture_pan
            // 
            this.Picture_pan.Location = new System.Drawing.Point(0, 49);
            this.Picture_pan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Picture_pan.Name = "Picture_pan";
            this.Picture_pan.Size = new System.Drawing.Size(282, 642);
            this.Picture_pan.TabIndex = 1;
            this.Picture_pan.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Picture_pan_MouseWheel);
            // 
            // Picture
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(282, 689);
            this.Controls.Add(this.Picture_pan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Picture";
            this.Text = "Picture";
            this.Load += new System.EventHandler(this.Picture_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label m_Small_btn;
        private System.Windows.Forms.Label m_Zoom_btn;
        private System.Windows.Forms.Panel Picture_pan;
        private System.Windows.Forms.Label label2;
    }
}