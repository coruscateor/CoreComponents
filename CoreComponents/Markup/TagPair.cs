
using System;
using System.Text;

namespace CoreComponents.Markup
{
	
	public interface ITagPair
	{
		
		string Opener
		{
			
			get;
			
		}
		
		string Closer
		{
			
			get;
			
		}
		
		void Open(StringBuilder SB);
		
		void Close(StringBuilder SB);
		
		void CloseL(StringBuilder SB);
		
	}
	
	public abstract class TagPair : ITagPair
	{
		
		string myOpener;
		
		string myCloser;
		
		public TagPair(TagPair Pair)
		{
			
			myOpener = Pair.Opener;
		
			myCloser = Pair.Closer;
			
		}
		
		public TagPair(string TagOpener, string TagCloser)
		{
			
			myOpener = TagOpener;
		
			myCloser = TagCloser;
			
		}
		
		public string Opener
		{
			
			get
			{
				return myOpener;
			}
			
		}
		
		public string Closer
		{
			
			get
			{
				return myCloser;
			}
			
		}
		
		public void Open(StringBuilder SB)
		{
			
			SB.Append(myOpener);
			
		}
		
		public void Close(StringBuilder SB)
		{
			
			SB.Append(myOpener);
			
		}
		
		public void CloseL(StringBuilder SB)
		{
			
			SB.AppendLine(myOpener);
			
		}
		
	}
}
