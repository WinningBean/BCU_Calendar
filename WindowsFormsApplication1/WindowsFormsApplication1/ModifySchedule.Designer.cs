namespace WindowsFormsApplication1
{
    partial class ModifySchedule
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
            this.strDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imagePic = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.exTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stateCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.strHour = new System.Windows.Forms.ComboBox();
            this.strMin = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.colorCom = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.endMin = new System.Windows.Forms.ComboBox();
            this.endHour = new System.Windows.Forms.ComboBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePic)).BeginInit();
            this.SuspendLayout();
            // 
            // strDate
            // 
            this.strDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.strDate.Location = new System.Drawing.Point(130, 169);
            this.strDate.Name = "strDate";
            this.strDate.Size = new System.Drawing.Size(149, 30);
            this.strDate.TabIndex = 0;
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.endDate.Location = new System.Drawing.Point(130, 213);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(149, 30);
            this.endDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(170, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "~";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(26, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "시작일시";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(26, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "대표사진";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(26, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "종료일시";
            // 
            // imagePic
            // 
            this.imagePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePic.Location = new System.Drawing.Point(130, 299);
            this.imagePic.Name = "imagePic";
            this.imagePic.Size = new System.Drawing.Size(241, 131);
            this.imagePic.TabIndex = 7;
            this.imagePic.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(45, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "일정명";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(26, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "일정설명";
            // 
            // exTxt
            // 
            this.exTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exTxt.Location = new System.Drawing.Point(130, 70);
            this.exTxt.Multiline = true;
            this.exTxt.Name = "exTxt";
            this.exTxt.Size = new System.Drawing.Size(235, 89);
            this.exTxt.TabIndex = 10;
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameTxt.Location = new System.Drawing.Point(130, 24);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(140, 33);
            this.nameTxt.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(26, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 26);
            this.label7.TabIndex = 12;
            this.label7.Text = "공개상태";
            // 
            // stateCheck
            // 
            this.stateCheck.AutoSize = true;
            this.stateCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stateCheck.Location = new System.Drawing.Point(130, 491);
            this.stateCheck.Name = "stateCheck";
            this.stateCheck.Size = new System.Drawing.Size(91, 30);
            this.stateCheck.TabIndex = 13;
            this.stateCheck.Text = "비공개";
            this.stateCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(107, 565);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(341, 565);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(392, 408);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "불러오기";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(392, 373);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "등록하기";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // strHour
            // 
            this.strHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.strHour.FormattingEnabled = true;
            this.strHour.Location = new System.Drawing.Point(289, 169);
            this.strHour.Name = "strHour";
            this.strHour.Size = new System.Drawing.Size(42, 30);
            this.strHour.TabIndex = 19;
            this.strHour.SelectedIndexChanged += new System.EventHandler(this.strHour_SelectedIndexChanged);
            // 
            // strMin
            // 
            this.strMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.strMin.FormattingEnabled = true;
            this.strMin.Location = new System.Drawing.Point(367, 172);
            this.strMin.Name = "strMin";
            this.strMin.Size = new System.Drawing.Size(48, 30);
            this.strMin.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(337, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 19);
            this.label8.TabIndex = 21;
            this.label8.Text = "시";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(227, 447);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 33);
            this.label11.TabIndex = 25;
            this.label11.Text = "●";
            // 
            // colorCom
            // 
            this.colorCom.FormattingEnabled = true;
            this.colorCom.Location = new System.Drawing.Point(130, 452);
            this.colorCom.Name = "colorCom";
            this.colorCom.Size = new System.Drawing.Size(91, 23);
            this.colorCom.TabIndex = 27;
            this.colorCom.SelectedIndexChanged += new System.EventHandler(this.colorCom_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(26, 447);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 26);
            this.label12.TabIndex = 28;
            this.label12.Text = "글자색깔";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(337, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 19);
            this.label9.TabIndex = 29;
            this.label9.Text = "시";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(421, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 19);
            this.label10.TabIndex = 30;
            this.label10.Text = "분";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(421, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 19);
            this.label13.TabIndex = 31;
            this.label13.Text = "분";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.ForeColor = System.Drawing.Color.Crimson;
            this.checkBox1.Location = new System.Drawing.Point(372, 249);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 30);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "하루종일";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(392, 335);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 33;
            this.button5.Text = "지우기";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // endMin
            // 
            this.endMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.endMin.FormattingEnabled = true;
            this.endMin.Location = new System.Drawing.Point(367, 213);
            this.endMin.Name = "endMin";
            this.endMin.Size = new System.Drawing.Size(48, 30);
            this.endMin.TabIndex = 34;
            // 
            // endHour
            // 
            this.endHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.endHour.FormattingEnabled = true;
            this.endHour.Location = new System.Drawing.Point(289, 221);
            this.endHour.Name = "endHour";
            this.endHour.Size = new System.Drawing.Size(42, 30);
            this.endHour.TabIndex = 35;
            this.endHour.SelectedIndexChanged += new System.EventHandler(this.endHour_SelectedIndexChanged);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.deleteBtn.Location = new System.Drawing.Point(233, 565);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 36;
            this.deleteBtn.Text = "삭제";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // ModifySchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 591);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.endHour);
            this.Controls.Add(this.endMin);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.colorCom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.strMin);
            this.Controls.Add(this.strHour);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stateCheck);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.exTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imagePic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.strDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModifySchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ModifySchedule";
            this.Load += new System.EventHandler(this.ModifySchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker strDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox imagePic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox exTxt;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox stateCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox strHour;
        private System.Windows.Forms.ComboBox strMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox colorCom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox endMin;
        private System.Windows.Forms.ComboBox endHour;
        private System.Windows.Forms.Button deleteBtn;
    }
}