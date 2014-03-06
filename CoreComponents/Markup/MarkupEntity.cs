using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Items;
using CoreComponents.Text;

namespace CoreComponents.Markup
{
    public abstract class MarkupEntity : TextEntity, IMarkupEntity<ParentedList<MarkupEntity, MarkupEntity>, MarkupEntity>  //, IChild<MarkupEntity>  //<MarkupEntity>, IChild<MarkupEntity>
    {

        ChildToParentAdapter<MarkupEntity, MarkupEntity, IParentedList<MarkupEntity, MarkupEntity>> myAdapter; 
		
        protected ParentedList<MarkupEntity, MarkupEntity> myChildren;

		protected ITagPair myTags;

        public static readonly OpenParentPair statOpenParentPair = new OpenParentPair();
        public static readonly CloseParentPair statCloseParentPair = new CloseParentPair();
        public static readonly ElementPair statElementPair = new ElementPair();
        public static readonly XCommentPair statXCommentPair = new XCommentPair();
        public static readonly QuestionMarkPair statQuestionMarkPair = new QuestionMarkPair();
        public static readonly PHPPair statPHPPair = new PHPPair();
        public static readonly ASPXPair statASPXPair = new ASPXPair();
        public static readonly ASPXCommentPair statASPXCommentPair = new ASPXCommentPair();


        public MarkupEntity(string ParentCollectionName)
        {

            myAdapter = new ChildToParentAdapter<MarkupEntity, MarkupEntity, IParentedList<MarkupEntity, MarkupEntity>>(this, ParentCollectionName);

        }

        public MarkupEntity(ITagPair Tags)
        {

            myTags = Tags;

            myAdapter = null;

        }

        public MarkupEntity(ITagPair Tags, string ParentCollectionName)
		{
			
			myTags = Tags;

            myAdapter = new ChildToParentAdapter<MarkupEntity, MarkupEntity, IParentedList<MarkupEntity, MarkupEntity>>(this, ParentCollectionName);

		}

        //public abstract string Name
        //{

        //    get;

        //}

        //public abstract string Namespace
        //{

        //    get;

        //}

        //public abstract bool HasName
        //{
        //    get;
        //}

        //public abstract bool HasNamespace
        //{
        //    get;
        //}


        public virtual string Name
        {

            get
            {
                return string.Empty;
            }

        }

        public virtual string Namespace
        {

            get
            {
                return string.Empty;
            }

        }

        public virtual bool HasName
        {
            get
            {
                return false;
            }
        }

        public virtual bool HasNamespace
        {
            get
            {
                return false;
            }
        }

        public ITagPair Tags
        {
            get
            {
                return myTags;
            }
        }

        protected static bool IsPairType<TTag>(ITagPair Tags) where TTag : ITagPair
        {

            return Tags is TTag;

        }


        //e.g output: "<"
		protected static void OpenTag(ITagPair Tags, StringBuilder SB)
		{
			
			SB.Append(Tags.Opener);
			
		}

        //e.g output: "<Name"
        protected static void OpenName(IMarkupEntity Entity, ITagPair Tags, StringBuilder SB)
        {

            OpenTag(Tags, SB);

            SB.Append(Entity.Name);
        }

        //e.g output: "<Namespace:Name"
        protected static void OpenNameSpace(IMarkupEntity Entity, ITagPair Tags, StringBuilder SB)
        {

            OpenTag(Tags, SB);

            SB.Append(Entity.Namespace);

            SB.Append(':');

            SB.Append(Entity.Name);

        }

        //e.g output: ">"
        protected static void CloseTag(ITagPair Tags, StringBuilder SB)
        {

            SB.Append(Tags.Closer);

        }

        //e.g output: ">\n"
        protected static void CloseTagL(ITagPair Tags, StringBuilder SB)
        {

            SB.Append(Tags.Closer);

        }

        //e.g output: "<Name>", </Name>
        protected static void FullNameTag(IMarkupEntity Entity, ITagPair Tags, StringBuilder SB)
        {

            SB.Append(Tags.Opener);

            SB.Append(Entity.Name);

            SB.Append(Tags.Closer);

        }

        //e.g output: "<Name:Namespace>", </Name:Namespace>
        protected static void FullNameSpaceTag(IMarkupEntity Entity, ITagPair Tags, StringBuilder SB)
        {

            SB.Append(Tags.Opener);

            SB.Append(Entity.Name);

            SB.Append(':');

            SB.Append(Entity.Namespace);

            SB.Append(Tags.Closer);

        }

        //e.g output: "<Name>\n"
        protected static void FullNameTagL(IMarkupEntity Entity, ITagPair Tags, StringBuilder SB)
        {

            SB.Append(Tags.Opener);

            SB.Append(Entity.Name);

            SB.AppendLine(Tags.Closer);

        }

        //e.g output: "<Name:Namespace>\n", "</Name:Namespace>\n"
        protected static void FullNameSpaceTagL(IMarkupEntity Entity, ITagPair Tags, StringBuilder SB)
        {

            SB.Append(Tags.Opener);

            SB.Append(Entity.Name);

            SB.Append(':');

            SB.Append(Entity.Namespace);

            SB.AppendLine(Tags.Closer);

        }

        protected static void Initalise(MarkupEntity Parent, ParentedList<MarkupEntity, MarkupEntity> Children)
        {

            Children = new ParentedList<MarkupEntity, MarkupEntity>(Parent); //(IParentedList<MarkupEntity, MarkupEntity>)

        }

        protected static void AppendChildren(IMarkupEntity<ParentedList<MarkupEntity, MarkupEntity>, MarkupEntity> Parent, StringBuilder SB)
        {

            foreach (TextEntity Child in Parent.Children)
            {

                Child.AppendTo(SB);

            }

        }

        protected static void AppendChildrenCloseTagL(IMarkupEntity<ParentedList<MarkupEntity, MarkupEntity>, MarkupEntity> Parent, StringBuilder SB)
        {

            AppendChildren(Parent, SB);

            CloseTagL(statCloseParentPair, SB);

        }


        public MarkupEntity Parent
        {
            get
            {
                return myAdapter.OwnersParent;
            }
            set
            {
                myAdapter.SetParent(value);
            }
        }

        public bool IsOrphin()
        {

            return myAdapter.OwnerIsOrphin();

        }

        public abstract ParentedList<MarkupEntity, MarkupEntity> Children
        {

            get;

        }

        public abstract bool HasChildren
        {

            get;

        }

        /*
        protected override void Append(StringBuilder SB)
        {
            throw new NotImplementedException();
        }
        */


        //#region IRO_Parent<ParentedList<MarkupEntity,MarkupEntity>> Members

        //public ParentedList<MarkupEntity, MarkupEntity> Childern
        //{

        //}

        //#endregion
    }
    
    /*      
	public abstract class NamedMarkupEntity : MarkupEntity
	{
		
		protected string myName;
	
		public NamedMarkupEntity(ITagPair Tags) : base(Tags)
		{
			
		}
		
		public override string Name
		{
			
			get
			{
				return myName;
			}
			
		}
		
		public override bool HasName
		{
			get
			{
				return myName.Length > 0;
			}
		}
		
				
	}
	
	public abstract class NamespacedMarkupEntity : NamedMarkupEntity
	{
		
		protected string myNamespace;
	
		public NamespacedMarkupEntity(ITagPair Tags) : base(Tags)
		{
			
		}
	
		public override string Namespace
		{
			
			get
			{
				return myNamespace;
			}
			
		}
		
		public override bool HasNamespace
		{
			get
			{
				return myName.Length > 0;
			}
		}
				
	}
	
	public abstract class NamedAttributinalMarkupEntity<T> : NamedMarkupEntity where T : ITextEntity
	{
		
		protected T myAttributes;
		
		public NamedAttributinalMarkupEntity(ITagPair Tags) : base(Tags)
		{
		}
		
		public T Attributes
		{
			get
			{
				return myAttributes;
			}
		}
		
	}
	
	public abstract class NamespacedAttributinalMarkupEntity<T> : NamespacedMarkupEntity //where T : ITextEntity
	{
		
		protected T myAttributes;
		
		public NamespacedAttributinalMarkupEntity(ITagPair Tags) : base(Tags)
		{
		}
		
		public T Attributes
		{
			get
			{
				return myAttributes;
			}
		}
		
	}
	
	public interface IMarkupEntityParent<TChildren> where TChildren : ISubscribeableList<ITextEntity>
	{
		
		TChildren Children
		{
			
			get;
			
		}
		
	}
	
	public abstract class NamedMarkupEntityParent<TChildren> : NamedMarkupEntity, IMarkupEntityParent<TChildren> where TChildren : ISubscribeableList<ITextEntity>
	{
		
		protected TChildren myChildren;
		
		public NamedMarkupEntityParent(ITagPair Tags) : base(Tags)
		{
		}
		
		public TChildren Children
		{
			
			get
			{
				return myChildren;
			}
			
		}
		
	}
	
	public abstract class NamespacedMarkupEntityParent<TChildren> : NamespacedMarkupEntity, IMarkupEntityParent<TChildren> where TChildren : ISubscribeableList<ITextEntity>
	{
		
		protected TChildren myChildren;
		
		public NamespacedMarkupEntityParent(ITagPair Tags) : base(Tags)
		{
		}
		
		public TChildren Children
		{
			
			get
			{
				return myChildren;
			}
			
		}
		
	}

    public abstract class NamedAttributinalMarkupEntityParent<TAttributes, TChildren> : NamedAttributinalMarkupEntity<TAttributes>, IMarkupEntityParent<TChildren> where TChildren : ISubscribeableList<ITextEntity> where TAttributes : ITextEntity
	{
		
		protected TChildren myChildren;
		
		public NamedAttributinalMarkupEntityParent(ITagPair Tags) : base(Tags)
		{
		}
		
		public TChildren Children
		{
			
			get
			{
				return myChildren;
			}
			
		}
		
	}

    public abstract class NamespacedAttributinalMarkupEntityParent<TAttributes, TChildren> : NamespacedAttributinalMarkupEntity<TAttributes>, IMarkupEntityParent<TChildren> where TChildren : ISubscribeableList<ITextEntity> //where TAttributes : ITextEntity
	{
		
		protected TChildren myChildren;
		
		public NamespacedAttributinalMarkupEntityParent(ITagPair Tags) : base(Tags)
		{
		}
		
		public TChildren Children
		{
			
			get
			{
				return myChildren;
			}
			
		}
		
	}

    public enum MarkupType
    {
        XML,
        HTML,
        ASP,
        RAILS

    }
     * */
}
