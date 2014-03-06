
using System;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Markup
{
	
	public interface IMarkupContents : ITextEntity
	{
		bool ContainsMarkup
		{
			get;
		}
	}


    public abstract class MarkupContents<TItem> : IMarkupContents
    {

        protected TItem myItem;

        public TItem Item
        {
        
            get {

                return myItem;

            }

        }
		
        public MarkupContents()
        {
        }

        public virtual bool ContainsMarkup
        {
            get
            {
                return false;
            }
        }

        public virtual void AppendTo(StringBuilder SB)
        {
        }
		
    }

    public class ReadonlyTextContents : IMarkupContents
    {

        protected string myText;

        public ReadonlyTextContents()
        {
        }

        public ReadonlyTextContents(string Contents)
        {

            myText = Contents;

        }

        public string Text
        {
        
            get {

                return myText;

            }
            

        }
		
        public virtual bool ContainsMarkup
        {
            get
            {
                return false;
            }
        }

        public void AppendTo(StringBuilder SB)
        {

            SB.Append(myText);

        }
		
    }

    public class TextContents : ReadonlyTextContents
    {

        public TextContents()
        {
        }

        public TextContents(string Contents) : base(Contents)
        {
        }

        public new string Text
        {

            get
            {

                return myText;

            }
            set
            {

                myText = value;

            }

        }

    }

}
