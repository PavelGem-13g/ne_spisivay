using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnogugolnikiShapeLibrary;
using mnogougolniki;

namespace mnogougolniki.UndoRedo
{
    public class ChangeRadius : Change
    {
        int deltaRadius;
        public ChangeRadius(int deltaRadius)
        {
            this.deltaRadius = deltaRadius;
        }
        public override void Redo()
        {
            Shape.R += deltaRadius;
            Form.instance.radiusForm.ChangeRadius(deltaRadius);
        }

        public override void Undo()
        {
            Shape.R -= deltaRadius;
            Form.instance.radiusForm.ChangeRadius(-deltaRadius);
        }
    }
}
