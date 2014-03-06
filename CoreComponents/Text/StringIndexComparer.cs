using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{

    public struct StringIndexComparer
    {

        string myValue;

        int myCurrentIndex;

        //public StringIndexComparer()
        //{

        //    myValue = null;

        //    myCurrentIndex = 0;

        //}

        public StringIndexComparer(string TheValue)
        {

            myCurrentIndex = 0;

            myValue = TheValue;

        }

        public StringIndexComparer(string TheValue, int TheInitalIndex = 0)
        {

            myValue = TheValue;

            if(myValue.Length <= TheInitalIndex)
                TheInitalIndex = myValue.Length - 1;

            myCurrentIndex = TheInitalIndex;

        }

        public string Value
        {

            get
            {

                return myValue;

            }
            set
            {

                myValue = value;

            }
        
        }

        public bool HasValue
        {

            get
            {

                return myValue != null && myValue.Length > 0;

            }

        }

        public int CurrentIndex
        {

            get
            {

                return myCurrentIndex;

            }
        
        }

        public StringIndexResult Check(char TheChar)
        {

            if(HasValue)
            {

                int MaxIndex = myValue.Length - 1;

                if(MaxIndex > myCurrentIndex)
                {

                    if(myValue[myCurrentIndex] == TheChar)
                    {

                        if(MaxIndex > myCurrentIndex)
                        {

                            myCurrentIndex++;

                            return StringIndexResult.Advanced;

                        }
                        else
                            return StringIndexResult.Completed;

                    }

                }

            }

            return StringIndexResult.Failed;

        }

        public void Reset()
        {

            myCurrentIndex = 0;

        }

    }

    public enum StringIndexResult
    {

        Failed,
        Advanced,
        Completed

    }

}
