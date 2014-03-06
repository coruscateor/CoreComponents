using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{

    public interface IGenericProvider<TSender>  //IGenericProvider<TSource> //S: IDeactivateableCantActivate
	{

        //event Gimmie<SenderEventArgs<IGenericProvider<TSource>>>.GimmieSomethin SourceChanged;

        event Action<SenderEventArgs<TSender>> SourceChanged;
		
	}

    public interface IOpenSourceProvider<TSource>
    {

        TSource Source
        {

            get;

        }

    }
	
}
