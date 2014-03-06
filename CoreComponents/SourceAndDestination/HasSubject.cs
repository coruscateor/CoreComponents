
using System;

namespace CoreComponents.SourceAndDestination
{
    
	public abstract class HasSubject<TSubject> : IHasSubject<TSubject> where TSubject : IHasSubject<TSubject>
	{
		
		protected TSubject mySubject;

		public event Action<SenderEventArgs<IHasSubject<TSubject>>> SubjectChanged;
		
		public HasSubject()
		{
		}
		
		public HasSubject(TSubject Subject)
		{
			
			mySubject = Subject;
			
		}
		
		protected void OnSubjectChanged()
		{
			
			if(SubjectChanged != null)
				SubjectChanged(new SenderEventArgs<IHasSubject<TSubject>>(this));
			
		}

        public TSubject Subject
        {

            get
			{
				
				return mySubject;
				
			}
            set
			{
				
				mySubject = value;
				
				OnSubjectChanged();
				
			}

        }

        public void RemoveSubject()
		{
			
			mySubject = default(TSubject);
			
			OnSubjectChanged();
			
		}

        public bool HasASubject
        {

            get
			{
				
				return Return.IsNull<TSubject>(mySubject);
				
			}

        }
		
		public bool IsTheSubject(TSubject theSubject)
		{
			
			return mySubject.Equals(theSubject);
			
		}
		
	}

}
