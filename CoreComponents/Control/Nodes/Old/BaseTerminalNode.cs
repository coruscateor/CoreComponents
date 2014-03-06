using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control.Nodes
{

    public abstract class BaseTerminalNode
    {

        public BaseTerminalNode()
        {
        }

        public bool GetNext(object TheValue, IPathNode NextNode)
        {

            return false;

        }

        int NextCount
        {

            get
            {

                return 0;

            }

        }

        public bool IsTerminal
        {

            get
            {

                return true;

            }

        }

        public bool Contains(IPathNode TheNextNode)
        {

            return false;

        }

        [NotSupported]
        public void SetNext(IPathNode TheNextNode)
        {

            throw new NotSupportedException();

        }

        [NotSupported]
        public void SetNext(IPathNode[] TheNextNodes)
        {

            throw new NotSupportedException();

        }

        [NotSupported]
        public void SetNextParams(params IPathNode[] TheNextNodes)
        {

            throw new NotSupportedException();

        }

        [NotSupported]
        public void ClearNext()
        {

            throw new NotSupportedException();

        }

    }

}
