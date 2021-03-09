using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnogougolnikiUndoRedo
{
    public class ChangePointMove : Change
    {
        int n;
        int deltaX;
        int deltaY;
        public ChangePointMove(int n, int deltaX, int deltaY) 
        {
            this.n = n;
            this.deltaX = deltaX;
            this.deltaY = deltaY;
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
