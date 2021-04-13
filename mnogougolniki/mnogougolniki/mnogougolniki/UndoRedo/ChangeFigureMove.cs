using System;
using System.Collections.Generic;
using System.Drawing;

namespace mnogougolniki.UndoRedo
{
    public class ChangeFigureMove : Change
    {
        List<DeltaPoint> delta;
        public ChangeFigureMove()
        {
            delta = new List<DeltaPoint>();
            foreach (var item in Form.instance.shapes)
            {
                delta.Add(new DeltaPoint(new Point(item.X - item.StartPositionX, item.Y - item.StartPositionY),item.GetHashCode().ToString()));   
            }
        }
        public override void Redo()
        {
            foreach (var item in delta)
            {
                foreach (var item1 in Form.instance.shapes)
                {
                    if (item.id==item1.GetHashCode().ToString())
                    {
                        item1.X += item.position.X;
                        item1.Y += item.position.Y;
                    }
                }
            }            
        }

        public override void Undo()
        {
            foreach (var item in delta)
            {
                foreach (var item1 in Form.instance.shapes)
                {
                    if (item.id == item1.GetHashCode().ToString())
                    {
                        item1.X -= item.position.X;
                        item1.Y -= item.position.Y;
                    }
                }
            }
        }
    }
    struct DeltaPoint
    {
        public Point position;
        public string id;
        public DeltaPoint(Point position, string id) 
        {
            this.position = position;
            this.id = id;
        }
    }
}
