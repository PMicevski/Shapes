﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;


namespace MyGame
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        private bool _selected;

        public Color Colour
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }

        public Shape() : this(Color.Yellow)
        {

        }

        public Shape(Color myClr)
        {
            _color = myClr;
        }

        public virtual bool IsAt(Point2D point)
        {
            return false;
            //return SwinGame.PointInRect(point, _x, _y, _width, _height);          
        }

        public abstract void Draw();
        //{
        //    //swingame.fillrectangle(colour, x, y, width, height);
        //    //if (selected)
        //    //{
        //    //    drawoutline();
        //    //}
        //}

        public abstract void DrawOutline();
    }
    }
