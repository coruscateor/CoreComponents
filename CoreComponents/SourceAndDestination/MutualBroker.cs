using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.SourceAndDestination
{

    //PCS This concerns the source/destination issue Ive been grappling with.
    //The purpose of this component is to get to objects to listen to each other.
    //For instance you have a source that needs to listen to its destination and vice versa.
    //i.e. a code model listening to a file object for changes 
    //or a ui component listening for changes in a database source.
    public abstract class MutualBroker<TModel, TSource>
    {

        protected TModel myModel;
        protected TSource mySource;

        public event Action<ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>> ModelAdding;

        public event Action<ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>> ModelAdded;

        public event Action<ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>> ModelRemoving;

        public event Action<ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>> ModelRemoved;

        public event Action<ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>> SourceAdding;

        public event Action<ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>> SourceAdded;

        public event Action<ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>> SourceRemoving;

        public event Action<ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>> SourceRemoved;

        public MutualBroker()
        {
        }

        public MutualBroker(TModel theModel)
        {

            if (Return.IsNotNull<TModel>(theModel))
            {

                myModel = theModel;

                SetModel(theModel);

            }

        }

        public MutualBroker(TSource theSource)
        {

            if (Return.IsNotNull<TSource>(theSource))
            {

                mySource = theSource;

                SetSource(theSource);

            }

        }

        public MutualBroker(TSource theSource, TModel theModel)
        {

            if (Return.IsNotNull<TModel>(theModel))
            {

                myModel = theModel;

                SetModel(theModel);

            }

            if (Return.IsNotNull<TSource>(theSource))
            {

                mySource = theSource;

                SetSource(theSource);

            }

        }

        protected void OnModelAdding(TModel Item)
        {

            if (ModelAdding != null)
                ModelAdding(new ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>(this, Item));

        }

        protected void OnModelAdded(TModel Item)
        {

            if (ModelAdded != null)
                ModelAdded(new ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>(this, Item));

        }

        protected void OnModelRemoving()
        {

            if (ModelRemoving != null)
                ModelRemoving(new ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>(this, myModel));

        }

        protected void OnModelRemoved()
        {

            if (ModelRemoved != null)
                ModelRemoved(new ChangeEventArgs<TModel, MutualBroker<TModel, TSource>>(this, myModel));


        }

        protected void OnSourceAdding(TSource Item)
        {

            if (SourceAdding != null)
                SourceAdding(new ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>(this, Item));


        }

        protected void OnSourceAdded(TSource Item)
        {

            if (SourceAdded != null)
                SourceAdded(new ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>(this, Item));


        }

        protected void OnSourceRemoving()
        {

            if (SourceRemoving != null)
                SourceRemoving(new ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>(this, mySource));

        }

        protected void OnSourceRemoved()
        {

            if (SourceRemoved != null)
                SourceRemoved(new ChangeEventArgs<TSource, MutualBroker<TModel, TSource>>(this, mySource));

        }

        public TModel Model
        {

            get
            {

                return myModel;

            }
            set
            {

                if (Return.IsNotNull<TModel>(myModel))
                {
                    OnModelRemoving();

                    RemoveModel();

                    OnSourceRemoved();
                }

                myModel = value;

                if (Return.IsNotNull<TModel>(myModel))
                {

                    OnModelAdding(myModel);

                    SetModel(myModel);

                    OnModelAdded(myModel);

                }
            }

        }

        public TSource Source
        {

            get
            {

                return mySource;

            }
            set
            {

                if (Return.IsNotNull<TSource>(mySource))
                {

                    OnSourceRemoving();

                    RemoveSource();

                    OnModelRemoved();

                }

                mySource = value;

                if (Return.IsNotNull<TSource>(mySource))
                {

                    OnSourceAdding(mySource);

                    SetSource(value);

                    OnSourceAdded(mySource);

                }

            }

        }

        protected abstract void SetSource(TSource TheSource);

        protected abstract void SetModel(TModel TheModel);

        protected abstract void RemoveSource();

        protected abstract void RemoveModel();

    }

}
