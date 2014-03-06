using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CoreComponents.Items
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Listed item type</typeparam>
    /// <typeparam name="R">ChangedHandler args</typeparam>
    /// <typeparam name="e">ChangedRangeHandler args</param>
    /// 

    //public delegate void ChangedHandler<T>(ChangedEventArgs<T> args);

    //public delegate void ChangedRangeHandler<T>(ChangedRangeEventArgs<T> args);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">This is the "Item" Added or Removed.</typeparam>
    /// <typeparam name="Sender">The Type of the sender of the event.</typeparam>
    /// 
    /*
    public static class ChangedHandlers<T, Sender>
    {
        public delegate void ChangedHandler(ChangeEventArgs<T, Sender> args);

        public delegate void ChangedRangeHandler(ChangeRangeEventArgs<T, Sender> args);

    }
    */

    public interface ISubscribeableSet<T, Sender> : IEnumerable<T>, IEnumerable //, ICloneable
    {
        //public delegate void ChangedHandler(R args);

        //public delegate void ChangedRangeHandler(E args);
        /*
        event ChangedHandlers<T, Sender>.ChangedHandler Added;

        event ChangedHandlers<T, Sender>.ChangedHandler Adding;

        event ChangedHandlers<T, Sender>.ChangedHandler Removed;

        event ChangedHandlers<T, Sender>.ChangedHandler Removing;

        event Gimmie<SenderEventArgs<Sender>>.GimmieSomethin Clearing;

        event Gimmie<SenderEventArgs<Sender>>.GimmieSomethin Cleared;
         */

        //event Create<ChangeEventArgs<T, Sender>>.ADelegate Added;

        //event Create<ChangeEventArgs<T, Sender>>.ADelegate Removed;

        //event Create<SenderEventArgs<Sender>>.ADelegate Cleared;

        //event LimitReached<ICache<T>> Filled;

        //event LimitReached<ICache<T>> Emptied;
        
//      event ChangedRangeHandler RemovedSet;
//    	
//    	event ChangedRangeHandler AddedSet;

    }

    public interface ISubscribeableSets<T, Sender> : ISubscribeableSet<T, Sender>
    {

        //event ChangedHandlers<T, Sender>.ChangedRangeHandler AddedSet;

        //event ChangedHandlers<T, Sender>.ChangedRangeHandler AddingSet;

        //event ChangedHandlers<T, Sender>.ChangedRangeHandler RemovedSet;

        //event ChangedHandlers<T, Sender>.ChangedRangeHandler RemovingSet;

        //event Create<ChangeRangeEventArgs<T, Sender>>.ADelegate AddedSet;

        //event Create<ChangeRangeEventArgs<T, Sender>>.ADelegate RemovedSet;

    }

    public interface ICountableIndexable<T> : IEnumerable<T>
    {

        T this[int index]
        {

            get;

        }

        int Count
        {

            get;

        }

    }

    public interface ICountableNameableIndexable<T> : ICountableIndexable<T>
    {

        T this[string name]
        {

            get;

        }

    }

    public interface IIndexableCollection<T> : ICollection<T>, ICountableIndexable<T>
    {
    }

    public interface IIndexableNamedCollection<T> : IIndexableCollection<T>, ICountableNameableIndexable<T>
    {
    }


    public interface IIndexableEnumeration<T> : IEnumerable<T>
    {

        T this[int index]
        {

            get;

        }

    }


    public interface IIndexableNamedEnumeration<T> : IIndexableEnumeration<T>
    {

        T this[string name]
        {

            get;

        }

    }


    public interface IEditableList<T> : IList<T>
    {

        void AddRange(IEnumerable<T> items);

        //void RemoveRange(IEnumerable<T> items);

        void RemoveRange(int index, int count);

        void RemoveAll(Predicate<T> match);

        void Reverse();

        void Reverse(int index, int count);

        IList<T> RetriveReversed();

        IList<T> RetriveReversed(int index, int count);

    } 

    public interface ISubscribeableIndexable<T, Sender> : IIndexableCollection<T>, ISubscribeableSets<T, Sender> 
    {
    }

    public interface ISubscribeableIndexableEditableList<T, Sender> : IIndexableCollection<T>, ISubscribeableSets<T, Sender>, IEditableList<T>
    {
    }

    /// <summary>
    /// T - Listed item type
    /// R - Subscribing object
    /// E - Change reason
    /// </summary>
    /// <typeparam name="T">Listed item type</typeparam>
    /// <typeparam name="R">ChangedHandler args</typeparam>
    /// <typeparam name="E">ChangedRangeHandler args</typeparam>

    //public interface ISubscribeableList<T /*, ChangedHandler, ChangedRangeHandler*/> : IList<T>, ICollection<T>, ISubscribeableIndexable<T /*, ChangedHandler, ChangedRangeHandler*/>
    //{

    //    event ChangedRangeHandler<T> RemovedSet;

    //    event ChangedRangeHandler<T> AddedSet;

    //}

}
