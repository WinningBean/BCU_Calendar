namespace UserCustomControl
{
    partial class Profile
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_UserName_lbl = new System.Windows.Forms.Label();
            this.m_UserPic_rpic = new UserCustomControl.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_UserPic_rpic)).BeginInit();
            this.SuspendLayout();
            // 
            // m_UserName_lbl
            // 
            this.m_UserName_lbl.AutoSize = true;
            this.m_UserName_lbl.Font = new System.Drawing.Font("함초롬돋움", 20F, System.Drawing.FontStyle.Bold);
            this.m_UserName_lbl.Location = new System.Drawing.Point(75, 13);
            this.m_UserName_lbl.Name = "m_UserName_lbl";
            this.m_UserName_lbl.Size = new System.Drawing.Size(189, 44);
            this.m_UserName_lbl.TabIndex = 1;
            this.m_UserName_lbl.Text = "UserName";
            // 
            // m_UserPic_rpic
            // 
            this.m_UserPic_rpic.Image = global::UserCustomControl.Properties.Resources.user_null;
            this.m_UserPic_rpic.Location = new System.Drawing.Point(0, 0);
            this.m_UserPic_rpic.Name = "m_UserPic_rpic";
            this.m_UserPic_rpic.Size = new System.Drawing.Size(70, 70);
            this.m_UserPic_rpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_UserPic_rpic.TabIndex = 0;
            this.m_UserPic_rpic.TabStop = false;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.m_UserName_lbl);
            this.Controls.Add(this.m_UserPic_rpic);
            this.Name = "Profile";
            this.Size = new System.Drawing.Size(268, 70);
            ((System.ComponentModel.ISupportInitialize)(this.m_UserPic_rpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPictureBox m_UserPic_rpic;
        private System.Windows.Forms.Label m_UserName_lbl;
    }
}
