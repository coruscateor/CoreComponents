using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public interface IUndoRedo : IUndo
    {

        void Redo();

    }

}
