using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class EmptyEnumerator : IEnumerator
    {

        public EmptyEnumerator()
        { 
        }

        public object Current
        {

            get
            {
                
                return null;
            
            }

        }

        public bool MoveNext()
        {

            return false;

        }

        public void Reset()
        {
        }

    }

    public class EmptyEnumerator<TItem> : IEnumerator<TItem>
    {

        public EmptyEnumerator()
        {
        }

        public TItem Current
        {

            get
            {
                
                return default(TItem);
            
            }

        }

        public bool MoveNext()
        {

            return false;

        }

        public void Reset()
        {
        }

        public void Dispose()
        {
        }
        
        object IEnumerator.Current
        {

            get
            {
                
                return Current;
            
            }

        }

    }

}
