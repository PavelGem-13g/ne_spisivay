using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MnogougolnikiUndoRedo
{
    public class ChangeColor : Change
    {
        Color oldColor;
        Color newColor;
        public ChangeColor(Color oldColor, Color newColor)
        {
            this.oldColor = oldColor;
            this.newColor = newColor;
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
