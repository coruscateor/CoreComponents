using System;
using System.Collections;
using System.Collections.Generic;
using CoreComponents.Data;

namespace CoreComponents.Items
{

	public abstract class ConcealedSourcedList<TSource, TItem> : ConcealedList<TItem> where TSource : IGenericProvider<TSource>
	{

        protected TSource mySource;

        protected bool myEngaged;

		public ConcealedSourcedList(TSource theSource)
		{
			
			Engage(theSource);
			
		}

        protected void Engage()
        {

            if (!object.Equals(mySource, null))
            {

                if (!myEngaged)
                {

                    myEngaged = true;

                    mySource.SourceChanged += TheSourceChanged;

                }

            }

        }
		
		protected void Engage(TSource theSource)
		{

            Disengage();

            if (!object.Equals(theSource, null))
            {

                if (!object.Equals(theSource, mySource))
                {

                    myEngaged = true;

                    theSource = mySource;

                    mySource.SourceChanged += TheSourceChanged;

                }

            }

		}

        protected void Disengage()
        {

            if (myEngaged)
            {

                if (!object.Equals(mySource, null))
                {

                    myEngaged = false;

                    mySource.SourceChanged -= TheSourceChanged;

                }

            }

        }

        protected virtual void TheSourceChanged(SenderEventArgs<TSource> e)
        {
            //Disengage from old source, engage new one.
            Engage(e.Sender);

        }

	}
	
}
