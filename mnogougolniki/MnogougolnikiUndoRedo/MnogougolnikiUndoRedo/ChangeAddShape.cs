using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnogougolnikiUndoRedo
{
    public class ChangeAddShape : Change
    {
        int x;
        int y;
        public ChangeAddShape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override void Redo()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
