using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public abstract class BaseTLAsyncActionFunc<T> : IDisposable
    {

        protected readonly SThreadLocal<T> myTL;

        public BaseTLAsyncActionFunc()
        {

            myTL = new SThreadLocal<T>();

        }

        public BaseTLAsyncActionFunc(bool trackAllValues)
        {

            myTL = new SThreadLocal<T>(trackAllValues);

        }

        public BaseTLAsyncActionFunc(Func<T> valueFactory)
        {

            myTL = new SThreadLocal<T>(valueFactory);

        }

        public BaseTLAsyncActionFunc(Func<T> valueFactory, bool trackAllValues)
        {

            myTL = new SThreadLocal<T>(valueFactory, trackAllValues);

        }
        
        public bool IsValueCreated
        {

            get
            {

                return myTL.IsValueCreated;

            }

        }

        public IList<T> Values
        {

            get
            {

                return myTL.Values;

            }

        }

        public void Dispose()
        {

            myTL.Dispose();

        }

    }

}
