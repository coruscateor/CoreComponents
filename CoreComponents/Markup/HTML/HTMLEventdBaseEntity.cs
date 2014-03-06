using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;
using CoreComponents.Items;

namespace CoreComponents.Markup.HTML
{

    public interface IHTMLEventdBaseEntity<TEvent> where TEvent : ITextEntity
    {

        TEvent Events
        {

            get;

        }

    }

    public abstract class HTMLEventdBaseEntity<TAttributes, TEvents> : XBaseEntity<TAttributes>, IHTMLEventdBaseEntity<TEvents>
        where TAttributes : ITextEntity
        where TEvents : ITextEntity
    {

        protected TEvents myEvents;

        public HTMLEventdBaseEntity()
        {
        }

        public HTMLEventdBaseEntity(ITagPair Pair)
            : base(Pair)
        {
        }

        public TEvents Events
        {

            get
            {

                return myEvents;

            }

        }

        public override ParentedList<MarkupEntity, MarkupEntity> Children
        {
            get
            {
                return null;
            }
        }

        public override bool HasChildren
        {
            get
            {
                return false;
            }
        }

        protected override void Append(StringBuilder SB)
        {

        }

    }
}
