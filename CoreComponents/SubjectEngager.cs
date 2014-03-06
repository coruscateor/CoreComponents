using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    /*
    public interface ISubjectItemEngager
    {

        bool Engaged
        {

            get;

        }

    }
    */

    public abstract class SubjectEngager<TSubject> //: ISubjectEngager
    {

        protected TSubject mySubject;

        protected bool myEngaged;

        public SubjectEngager()
        {
        }

        public SubjectEngager(TSubject theSubject)
        {

            Engage(theSubject);
        
        }

        protected void Engage()
        {

            if (!object.Equals(mySubject, null))
            {

                if (!myEngaged)
                {

                    Disengage();

                    myEngaged = true;

                    EngageSubject();

                }

            }

        }

        protected void Engage(TSubject theSubject)
        {

            Disengage();

            if (!object.Equals(theSubject, null))
            {

                if (!object.Equals(mySubject, theSubject))
                {

                    myEngaged = true;

                    mySubject = theSubject;

                    EngageSubject();

                }

            }

        }

        protected void Disengage()
        {

            if (myEngaged)
            {

                if (!object.Equals(mySubject, null))
                {

                    myEngaged = false;

                    DisEngageSubject();

                }

            }

        }

        protected abstract void EngageSubject();

        protected abstract void DisEngageSubject();

        /*
        protected virtual void Disengage(TSubject theSubject)
        {

            myEngaged = false;
            
            if(myAssembly != theAssembly)
                myAssembly = theAssembly;    

        }
        */
    }

    /*
    public class SubjectItemEngager<TSubject> : SubjectEngager<TSubject>, ISubjectItemEngager
    {

        public SubjectItemEngager()
        {
        }

        public void EngageSubject()
        {

            Engage();

        }

        public void EngageSubject(TSubject theSubject)
        {

            Engage(theSubject);

        }

        public void DisengageSubject()
        {

            Disengage();

        }

        public bool Engaged
        {

            get
            {

                return myEngaged;

            }

        }

    }
    */
}
