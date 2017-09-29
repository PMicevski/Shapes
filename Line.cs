using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
namespace MyGame
{
    public class Line : Shape
    {
        private float _x2, _y2;
        private float _radius;

        public float X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public float Y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        public float Radius
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

        public Line() : this(Color.OrangeRed, SwinGame.MouseX(), SwinGame.MouseY(), SwinGame.MouseX()+100, SwinGame.MouseY())
        {

        }

        public Line(Color clr, float x, float y, float _x2, float _y2) :base(clr)
        {
            X = x;
            Y = y;
            X2 = _x2;
            Y2 = _y2;
        }

        public override void Draw()
        {
            if (Selected)            
            DrawOutline();
            SwinGame.DrawLine(Colour, X, Y, _x2, _y2);
        }

        public override void DrawOutline()
        {
            SwinGame.FillCircle(Color.Black, X, Y, _radius = 10);
            SwinGame.FillCircle(Color.Black, _x2, _y2, _radius = 10);
        }

        public override bool IsAt(Point2D point)
        {
            return SwinGame.PointOnLine(point, X, Y, _x2, _y2);
        }


    }
}
