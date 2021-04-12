using MnogugolnikiShapeLibrary;
using System.Drawing;

namespace mnogougolniki.UndoRedo
{
    public class ChangeAddShape : Change
    {
        int x;
        int y;
        int type;
        Shape shape;
        public ChangeAddShape(int x, int y, int type, Shape shape)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.shape = shape;
        }
        public ChangeAddShape(Point location, int type, Shape shape)
        {
            this.x = location.X;
            this.y = location.Y;
            this.shape = shape;
            this.type = type;
        }
        public override void Redo()
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

        public override void Undo()
        {
            shapes.Remove(shape);
        }
    }
}
