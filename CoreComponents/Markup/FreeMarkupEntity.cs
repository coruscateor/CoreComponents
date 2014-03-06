
using System;

namespace CoreComponents.Markup
{

	public abstract class FreeMarkupEntity<TContents> : MarkupEntity where TContents : IMarkupContents
	{
		
		protected TContents myContents;

		public FreeMarkupEntity(ITagPair Tags) : base(Tags)
		{
		}
		
		public FreeMarkupEntity(ITagPair Tags, TContents SectionContents) : base(Tags)
		{
			
			myContents = SectionContents;
			
		}

		public TContents Contents
		{
			get
			{
				return myContents;
			}
		}
	}
}
