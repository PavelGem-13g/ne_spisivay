using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnogougolnikiUndoRedo
{
    public class ChangeFigureMove : Change
    {
        int deltaX;
        int deltaY;
        public ChangeFigureMove(int deltaX, int deltaY) 
        {
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
