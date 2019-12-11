using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserCustomControl
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        private float m_fontSize; // fontSize 설정 변수
        public void Set_Profile_Size(FontStyle m_fontStyle) {
            // Set_Profile_Size(int Profile Control's Heihgt, FontStyle want FontStyle)
            // Profile의 각 요소들 Size 설정 함수
            m_fontSize = this.Height/(float)3;
            this.m_UserPic_rpic.Size = new System.Drawing.Size(this.Height, this.Height);

            this.m_UserName_lbl.Left = this.Height + 5;
            this.m_UserName_lbl.Font = new System.Drawing.Font("함초롬돋움", m_fontSize, m_fontStyle);
            this.m_UserName_lbl.Top = this.Height / 2 - this.m_UserName_lbl.Height / 2;
            this.Width = this.m_UserPic_rpic.Width + 5 + this.m_UserName_lbl.Width;
        }

        public Image USERPIC
        {
            // m_UserPic 프로퍼티
            get { return this.m_UserPic_rpic.Image; }
            set { m_UserPic_rpic.Image = value; }
        }
        public string USERNAME
        {
            // m_UserName 프로퍼티
            get { return this.m_UserName_lbl.Text; }
            set { m_UserName_lbl.Text = value; }
        }
    }
}
