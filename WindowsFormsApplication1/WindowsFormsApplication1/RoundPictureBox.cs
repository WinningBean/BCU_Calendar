using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public class RoundPictureBox : PictureBox
    {

        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath grath = new GraphicsPath();
            grath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grath);
            base.OnPaint(pe);
        }
    }
}
