using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Circle : Shape
    {
        private int _radius;

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }        

        public Circle() : this(Color.Blue, SwinGame.MouseX(), SwinGame.MouseY(), 50)
        {

        }

        public Circle(Color clr, float x, float y, int rad) : base(clr)
        {
            X = x;
            Y = y;
            Radius = rad;
        }

        public override void Draw()
        {
            if (Selected) DrawOutline();
            SwinGame.FillCircle(Colour, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, _radius+2);
        }

        public override bool IsAt(Point2D point)
        {
            
            return SwinGame.PointInCircle(point, X, Y, _radius);          
        }
    }
}
