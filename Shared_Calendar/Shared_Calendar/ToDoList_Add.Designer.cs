namespace Shared_Calendar
{
    partial class ToDoList_Add
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.m_Color_pan = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_Date_cb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox2.Location = new System.Drawing.Point(9, 55);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(226, 142);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "내용";
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 226);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 18);
            this.button1.TabIndex = 1;
            this.button1.Text = "완료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_Color_pan
            // 
            this.m_Color_pan.Location = new System.Drawing.Point(9, 199);
            this.m_Color_pan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_Color_pan.Name = "m_Color_pan";
            this.m_Color_pan.Size = new System.Drawing.Size(226, 26);
            this.m_Color_pan.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 31);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 227);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 18);
            this.button2.TabIndex = 4;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(FontLibrary.HANDOTUM, 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(208, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // m_Date_cb
            // 
            this.m_Date_cb.AutoSize = true;
            this.m_Date_cb.Checked = true;
            this.m_Date_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_Date_cb.Location = new System.Drawing.Point(9, 13);
            this.m_Date_cb.Name = "m_Date_cb";
            this.m_Date_cb.Size = new System.Drawing.Size(112, 16);
            this.m_Date_cb.TabIndex = 6;
            this.m_Date_cb.Text = "마감일자 미설정";
            this.m_Date_cb.UseVisualStyleBackColor = true;
            this.m_Date_cb.CheckedChanged += new System.EventHandler(this.m_Date_cb_CheckedChanged);
            // 
            // ToDoList_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(247, 248);
            this.Controls.Add(this.m_Date_cb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.m_Color_pan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ToDoList_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ToDoList_Add";
            this.Deactivate += new System.EventHandler(this.ToDoList_Add_Deactivate);
            this.Load += new System.EventHandler(this.ToDoList_Add_Load);
            this.LocationChanged += new System.EventHandler(this.ToDoList_Add_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel m_Color_pan;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox m_Date_cb;
    }
}