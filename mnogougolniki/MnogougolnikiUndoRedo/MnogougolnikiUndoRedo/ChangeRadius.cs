using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnogougolnikiUndoRedo
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
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
