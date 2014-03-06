using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Items;


namespace CoreComponents.Markup
{

    public abstract class AXComment : FreeMarkupEntity<TextContents>
    {

        public AXComment() : base(null)
        {
        }

        public AXComment(ITagPair Pair) : base(Pair)
        {
        }

        protected override void Append(StringBuilder SB)
        {

            OpenTag(myTags, SB);

            AddSpace(SB);

            SB.Append(Contents.Text);

            AddSpace(SB);

            CloseTagL(myTags, SB);

        }

    }

    public class XComment : AXComment
    {

        public XComment() : base(statXCommentPair)
        {
        }

        protected override void Append(StringBuilder SB)
        {

            OpenTag(myTags, SB);

            AddSpace(SB);

            SB.Append(Contents.Text);

            AddSpace(SB);

            CloseTagL(myTags, SB);

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
    }
}
