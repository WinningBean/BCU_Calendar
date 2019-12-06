using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public enum color
    {
        Green, Yellow, Orange, Mint, Blue
    };

    class DBColor
    {
        color currColor;

        public DBColor() { }
        public DBColor(color c)
        {
            currColor = c;
        }

        public Color randomColor() // 색을 랜덤으로 만들어줌
        {
            Random r = new Random();
            color c = (color)(r.Next() % 5);
            return SelectColor(c, 100);
        }

        public Color SelectColor(color c, int alpha) // 지정한 색을 리턴
        {
            switch (c)
            {
                case color.Green: // 투명도 0 ~ 255
                    return Color.FromArgb(alpha, 85, 239, 196);// green
                case color.Yellow:
                    return Color.FromArgb(alpha, 253, 203, 110); // yellow
                case color.Orange:
                    return Color.FromArgb(alpha, 225, 112, 85); //orange
                case color.Mint:
                    return Color.FromArgb(alpha, 129, 236, 236); //mint
                case color.Blue:
                    return Color.FromArgb(alpha, 30, 144, 255); // gray
            }
            return Color.FromArgb(alpha, 0, 255, 0); // 기본 컬러
        }
    }

}
