using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{
	
	public interface IText
	{
		
		string ToString();
		
	}
	
    public interface ITextEntity : IText
    {

        

        void AppendTo(StringBuilder SB);

    }
}
