using System;
using System.Drawing;
using MnogugolnikiShapeLibrary;

namespace mnogougolniki.UndoRedo
{
    public class ChangeDeleteShape : Change
    {
        Shape shape;
        public ChangeDeleteShape(Shape shape)
        {
            this.shape = shape;
        }
        public override void Redo()
        {
            Form.instance.shapes.Remove(shape);
        }

        public override void Undo()
        {
            shapes.Add(shape);
        }
    }
}
