
using System;

namespace CoreComponents.Markup
{
	
	
	public class OpenParentPair : TagPair
	{
		
		public OpenParentPair() : base("<", ">")
		{
		}
		
	}
	
	public class CloseParentPair : TagPair
	{
		
		public CloseParentPair() : base("</", ">")
		{
		}
		
	}
	
	public class ElementPair : TagPair
	{
		
		public ElementPair() : base("<", "/>")
		{
		}
		
	}
	
	public class XCommentPair : TagPair
	{
		
		public XCommentPair() : base("<!--", "-->")
		{
		}
		
	}
	
	public class QuestionMarkPair : TagPair
	{
		
		public QuestionMarkPair() : base("<?", "?>")
		{
		}
		
	}
	
	public class PHPPair : TagPair
	{
		
		public PHPPair () : base("<?php", "?>")
		{
		}
		
	}
	
	public class ASPXPair : TagPair
	{
		
		public ASPXPair() : base("<%", "%>")
		{
		}
		
	}
	
	public class ASPXCommentPair : TagPair
	{
		
		public ASPXCommentPair() : base("<%--", "--%>")
		{
		}
		
	}

    public class ASPXBindingPair : TagPair
	{

        public ASPXBindingPair() : base("<%#", "%>")
		{
		}
		
	}

    public class ASPXPagePair : TagPair
    {

        public ASPXPagePair() : base("<%@", "%>")
        {
        }

    }
}
