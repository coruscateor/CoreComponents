using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Items;
using CoreComponents.Markup.HTML.Attributes;

namespace CoreComponents.Markup.HTML
{
    public class Form : HTMLEventdBaseEntity<StandardAttributes, StandardEvents>
    {

        protected ITagPair myClosingTags;

        public Form() : base(MarkupEntity.statOpenParentPair)
        {

            myClosingTags = MarkupEntity.statCloseParentPair;

            Initalise(this, myChildren);

        }

        public override string Name
        {
            get
            {

                return "Form";

            }
        }

        public override bool HasName
        {
            get
            {
                
                return true;

            }
        }

        public override ParentedList<MarkupEntity, MarkupEntity> Children
        {
            get
            {
                return myChildren;
            }
        }

        public override bool HasChildren
        {
            get
            {
                return myChildren.Count > 0;
            }
        }

        //protected override void Append(StringBuilder SB)
        //{
        //    //OpenName(this, myTags, SB);
        //}
    }
}
