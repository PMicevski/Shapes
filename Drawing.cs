using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            Background = background;
        }

        public Drawing() : this(Color.White)
        {

        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach(Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }                    
                }
                return result;                
            }                       
        }
        
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public void Draw()
        {
            SwinGame.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }    
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach(Shape s in _shapes)
            {
                if (s.IsAt(SwinGame.MousePosition()))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }                
            }            
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
    }
}
