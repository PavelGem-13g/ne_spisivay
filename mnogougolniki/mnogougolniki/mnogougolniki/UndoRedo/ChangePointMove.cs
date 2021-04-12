using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnogugolnikiShapeLibrary;

namespace mnogougolniki.UndoRedo
{
    public class ChangePointMove : Change
    {
        Shape shape;
        int deltaX;
        int deltaY;
        public ChangePointMove(Shape shape, int deltaX, int deltaY)
        {
            this.shape = shape;
            this.deltaX = deltaX;
            this.deltaY = deltaY;
        }
        public override void Redo()
        {
            shape.X += deltaX;
            shape.Y += deltaY;
        }

        public override void Undo()
        {
            shape.X -= deltaX;
            shape.Y -= deltaY;
        }
    }
}
