using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mnogougolniki;

namespace mnogougolniki.UndoRedo
{
    public class ChangeShapeType : Change
    {
        int type;
        int oldType;
        public ChangeShapeType(int type, int oldType)
        {
            this.type = type;
            this.oldType = oldType;
        }
        public override void Redo()
        {
            Form.instance.shapeType = oldType;
        }

        public override void Undo()
        {
            Form.instance.shapeType = type;
        }
    }
}
