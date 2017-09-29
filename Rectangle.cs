using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Rectangle : Shape
    {
        private int _height, _width;
                
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public Rectangle() : this(Color.Green, SwinGame.MouseX(), SwinGame.MouseY(), 100, 100)
        {

        }

        public Rectangle(Color clr, float x, float y, int width, int height) : base(clr)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public override void Draw()
        {
            SwinGame.FillRectangle(Colour, X, Y, Width, Height);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SwinGame.DrawRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }

        public override bool IsAt(Point2D point)
        {            
            return SwinGame.PointInRect(point, X, Y, _width, _height);          
        }
    }
}
