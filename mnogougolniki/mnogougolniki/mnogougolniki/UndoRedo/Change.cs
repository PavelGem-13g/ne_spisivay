using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnogugolnikiShapeLibrary;

namespace mnogougolniki.UndoRedo
{
    public abstract class Change
    {
        public abstract void Undo();
        public abstract void Redo();
        public static List<Shape> shapes;
    }
}
