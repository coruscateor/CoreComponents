using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{
    
    public interface IAppendToWithIndentation : IAppendTo
    {

        void AppendTo(StringBuilder TheSB, TabIndentationLevelBuilder TheIndentation);

    }

}
