using System;
using System.Drawing;
using MnogugolnikiShapeLibrary;

namespace mnogougolniki.UndoRedo
{
    public class ChangeDeleteShape : Change
    {
        int x;
        int y;
        int type;
        Shape shape;
        public ChangeDeleteShape(int x, int y, int type, Shape shape)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.shape = shape;
        }
        public ChangeDeleteShape(Point location, int type, Shape shape)
        {
            this.x = location.X;
            this.y = location.Y;
            this.type = type;
            this.shape = shape;
        }
        public override void Redo()
        {
            shapes.Remove(shape);
        }

        public override void Undo()
        {
            if (type == 0)
            {
                shapes.Add(new Sqare(x, y));
            }
            if (type == 1)
            {
                shapes.Add(new Circle(x, y));
            }
            if (type == 2)
            {
                shapes.Add(new Triangle(x, y));
            }
            shape = shapes[shapes.Count - 1];
        }
    }
}
