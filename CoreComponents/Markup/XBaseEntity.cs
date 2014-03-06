using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Text;

namespace CoreComponents.Markup
{

    public interface IXBaseEntity<TAttributes> : IMarkupEntity  //<TMarkupEntity>
        where TAttributes : ITextEntity
    {

        TAttributes Attributes
        {

            get;

        }

        bool HasAttributes
        {

            get;

        }


    }

    public abstract class XBaseEntity<TAttributes> : MarkupEntity, IXBaseEntity<TAttributes> where TAttributes : ITextEntity
    {
        //, TMarkupEntity
        protected TAttributes myAttributes;

        public XBaseEntity()
            : base("Children")
        {
        }

        public XBaseEntity(ITagPair Pair) : base(Pair, "Children")
        {
        }

        public virtual TAttributes Attributes
        {

            get
            {

                return myAttributes;

            }

        }

        public virtual bool HasAttributes
        {

            get
            {

                return object.Equals(myAttributes, default(TAttributes));

            }

        }

        protected static void WriteNoNamespaceElement(XBaseEntity<TAttributes> Entity, StringBuilder SB) //where TAttributes : ITextEntity
        {

            OpenName(Entity, statElementPair, SB);

            AddSpace(SB);

            if (Entity.HasAttributes)
            {

                Entity.Attributes.AppendTo(SB);

            }

            CloseTagL(statElementPair, SB);

        }

        protected static void WriteNoNamespaceElement(XBaseEntity<TAttributes> Entity, ITagPair Tags, StringBuilder SB) //where TAttributes : ITextEntity
        {
            OpenName(Entity, statElementPair, SB);

            if (Entity.HasAttributes)
            {
                AddSpace(SB);

                Entity.Attributes.AppendTo(SB);

                AddSpace(SB);
            }

            CloseTagL(statElementPair, SB);

        }

        protected static void WriteNoNamespaceElementWithChildren(XBaseEntity<TAttributes> Entity, ITagPair Tags, StringBuilder SB) //where TAttributes : ITextEntity
        {
            OpenName(Entity, statOpenParentPair, SB);

            if (Entity.HasAttributes)
            {

                AddSpace(SB);

                Entity.Attributes.AppendTo(SB);

                AddSpace(SB);

            }

            CloseTagL(statOpenParentPair, SB);

            AppendChildrenCloseTagL(Entity, SB);

        }

    }
}
