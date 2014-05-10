
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items
{

    public static class LimitDelegates<T>
    {

        //public delegate void LimitReached(SenderEventArgs<T> e);

    }

    public static class FedDelegate<T, Sender>
    {

        public delegate void Fed(FedEventArgs<T, Sender> e);

    }

    //public static class FedDelegate<T>
    //{

    //    public delegate void Fed(FedEventArgs<T, ICache<T>> e);

    //}

    //public delegate void LimitReached<T>(SenderEventArgs<T> e);

    public interface IReadOnlyCache<T> : IEnumerable<T>, IEnumerable
	{
		
		//Basicaly complete
		
		//Future functionaily might include:
		
		//void FeedSource(FeedSource<T> Source);
		
		//void FeedSet(IEnumerable<T> Set);
		
		//or
		
		//IEnumerable<T> FeedSet(IEnumerable<T> Set);
		
		//event FedItem;
		
		//event FedSet;

        //event LimitDelegates<IReadOnlyCache<T>>.LimitReached Filled;

        //event LimitDelegates<IReadOnlyCache<T>>.LimitReached Emptied;

        //event LimitDelegates<IReadOnlyCache<T>>.LimitReached Emptying;

        event FedDelegate<T, IReadOnlyCache<T>>.Fed Fed;

        //event LimitDelegates<Sender>.LimitReached Filled;

        //event LimitDelegates<Sender>.LimitReached Emptied;

        //event LimitDelegates<Sender>.LimitReached Emptying;

        //event FedDelegate<T, Sender>.Fed Fed;

		//Pushes an Item onto the "top" of the cache, Removes the bottom one and returns it if it is about to grow past the maiximum. 
		
		int MaximumSize { get; set; }
		
		int Count { get; }
		
		bool IsFilled { get; }
		
	}

    public interface ICache<T> : IReadOnlyCache<T>
    {

        //new event FedDelegate<T, ICache<T>>.Fed Fed;

        T Feed(T Item);

        void Flush();

    }


    public interface ICacheInBatches<T> : ISubscribeableSets<T, ICacheInBatches<T>>
    {  

        IEnumerable<T> Feed(IEnumerable<T> Items);

        IEnumerable Feed(IEnumerable Items);

    }
}
