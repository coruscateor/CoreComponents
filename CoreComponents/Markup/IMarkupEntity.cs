using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Items;
using CoreComponents.Text;

namespace CoreComponents.Markup
{
    public interface IMarkupEntity //: IChild<IMarkupEntity>
    {

       		
		string Name
		{
			get;
		}
		
		string Namespace
		{
			get;
		}
		
		bool HasName
		{
			get;
		}
		
		bool HasNamespace
		{
			get;
		}

        ITagPair Tags
        {
            get;
        }

    }

    public interface IMarkupEntity<TChildList, TParent> : IMarkupEntity, IParent<TChildList>, IChild<TParent>
        where TParent : IMarkupEntity
        //where TChildList : IParentedList<IMarkupEntity, IMarkupEntity>
    {
    }

    //public interface IMarkupEntity : IMarkupEntity, IChild<IMarkupEntity>
    //{
    //}
}
