using System;
using System.Collections.Generic;
using System.Drawing;

namespace mnogougolniki.UndoRedo
{
    public class ChangeFigureMove : Change
    {
        List<Point> delta;
        public ChangeFigureMove()
        {
            delta = new List<Point>();
            foreach (var item in Form.instance.shapes)
            {
                delta.Add(new Point(item.X - item.StartPositionX, item.Y - item.StartPositionY));   
            }
        }
        public override void Redo()
        {
            for (int i = 0; i < Form.instance.shapes.Count && i < delta.Count; i++)
            {
                shapes[i].X += delta[i].X;
                shapes[i].Y += delta[i].Y;
            }
        }

        public override void Undo()
        {
            for (int i = 0; i < Form.instance.shapes.Count && i < delta.Count; i++)
            {
                shapes[i].X -= delta[i].X;
                shapes[i].Y -= delta[i].Y;
            }
        }
    }
}
