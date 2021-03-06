﻿using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MnogugolnikiShapeLibrary
{
    
    [Serializable]
    public abstract class Shape
    {
        static int r;
        static Color lineColor;
        static Color fillColor;
        [NonSerialized] bool isMovable;
        [NonSerialized] bool isShell;
        int x;
        int y;
        public int id;
        [NonSerialized] int xShift;
        [NonSerialized] int yShift;
        [NonSerialized] int startPositionX;
        [NonSerialized] int startPositionY;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public int YShift
        {
            get
            {
                return yShift;
            }
        }
        public int XShift
        {
            get
            {
                return xShift;
            }
        }
        public Point MoveShift
        {
            get
            {
                return new Point(XShift, YShift);
            }
            set
            {
                xShift = value.X;
                yShift = value.Y;
            }
        }
        public bool IsShell
        {
            get
            {
                return isShell;
            }
            set
            {
                isShell = value;
            }
        }
        public static int R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }
        public bool IsMovable
        {
            get
            {
                return isMovable;
            }
            set
            {
                isMovable = value;
            }
        }
        public Point Location
        {
            get
            {
                return new Point(x, y);
            }
            set
            {
                x = value.X;
                y = value.Y;
            }
        }
        public static Color LineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                lineColor = value;
            }
        }
        public static Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
            }
        }

        public int StartPositionX { get => startPositionX; set => startPositionX = value; }
        public int StartPositionY { get => startPositionY; set => startPositionY = value; }

        static Shape()
        {
            r = 50;
            lineColor = Color.Black;
            fillColor = Color.Black;
        }
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
            startPositionX = x;
            startPositionY = y;
        }
        public Shape(Point position)
        {
            this.x = position.X;
            this.y = position.Y;
            startPositionX = x;
            startPositionY = y;
        }
        public abstract void Draw(Graphics g);
        public abstract bool IsInside(Point mousePosition);
    }
}
