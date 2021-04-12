using System;
using System.Drawing;
using MnogugolnikiShapeLibrary;

namespace mnogougolniki.UndoRedo
{
    public class ChangeColor : Change
    {
        Color oldColor;
        Color newColor;
        int type;
        public ChangeColor(Color oldColor, Color newColor, int type)
        {
            this.oldColor = oldColor;
            this.newColor = newColor;
            this.type = type;
        }
        public override void Redo()
        {
            if (type==0)
            {
                Shape.FillColor = newColor;
            }
            if (type==1)
            {
                Shape.LineColor = newColor;
            }
        }

        public override void Undo()
        {
            if (type == 0)
            {
                Shape.FillColor = oldColor;
            }
            if (type == 1)
            {
                Shape.LineColor = oldColor;
            }
        }
    }
}
