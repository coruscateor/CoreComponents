using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{
    
    public interface IAppend
    {

        void Append(StringBuilder TheSB);

        void Append(StringBuilder TheSB, TabIndentationLevelBuilder TheIndentation);

    }

}
