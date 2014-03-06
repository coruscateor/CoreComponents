using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents
{
    public interface IReadonlyChild<TParent> //T - parent
    {

        TParent Parent
        {

            get;

        }
		
		bool IsOrphin();

    }

    public interface IParent<TChildList> //where TChildList : IEnumerable<TChild>
    {

        TChildList Children
        {

            get;

        }

    }

    /*
    public interface IReadonlyParentChild<P, T> : IRO_Parent<P>, IReadonlyChild<T> //T - parent
    {
    }
    */

	//130610 PCS The compiler is not reading the Parent override.
	
    public interface IChild<TParent> //: IReadonlyChild<T>
    {
		
		TParent Parent
        {

            get;
            set;

        }
		
		bool IsOrphin();
		
    }

    public interface IAdjustableParent<TChildList> : IParent<TChildList> //where TParent : IEnumerable<TChild>
    {

        new TChildList Children
        {

            get;
            set;

        }

    }

    /*
    public interface IReadonlyParentChild<TChildList, TParent> : IReadonlyParent<TChildList>, IChild<TParent>, IReadonlyParentChild<TChildList, TParent> //P - Parent, T - Child
    {
    }
    */
}
