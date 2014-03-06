using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.SourceAndDestination
{
    
    public interface IHasSubject<TSubject>
    {

        event Action<SenderEventArgs<IHasSubject<TSubject>>> SubjectChanged;

        //The subject object you will to listen to and respond to.
        TSubject Subject
        {

            get;
            set;

        }

        void RemoveSubject();

        bool HasASubject
        {

            get;

        }
		
		bool IsTheSubject(TSubject theSubject);
    }

}
