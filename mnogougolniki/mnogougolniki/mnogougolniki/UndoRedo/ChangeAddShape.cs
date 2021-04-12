using MnogugolnikiShapeLibrary;
using System.Drawing;
using System;

namespace mnogougolniki.UndoRedo
{
    public class ChangeAddShape : Change
    {
        Shape shape;
        public ChangeAddShape(Shape shape)
        {
            this.shape = shape;
        }

        public override void Redo()
        {
            Form.instance.shapes.Add(shape);
        }

        public override void Undo()
        {
            Form.instance.shapes.Remove(shape);
        }
    }
}
