using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Reflect
{

    public class InvocationEntryResultToParameter
    {

        protected int myIndex = -1;

        protected string myName;

        protected InvocationEntry myInvocationEntry;

        protected ParameterPreference myParameterPreference = ParameterPreference.Index;

        public InvocationEntryResultToParameter()
        {
        }

        public InvocationEntryResultToParameter(InvocationEntry TheInvocationEntry, int TheIndex)
        {

            myInvocationEntry = TheInvocationEntry;

            myIndex = TheIndex;

        }

        public InvocationEntryResultToParameter(InvocationEntry TheInvocationEntry, string TheName)
        {

            myInvocationEntry = TheInvocationEntry;

            myName = TheName;

        }

        public InvocationEntryResultToParameter(InvocationEntry TheInvocationEntry, int TheIndex, string TheName)
        {

            myInvocationEntry = TheInvocationEntry;

            myIndex = TheIndex;

            myName = TheName;

        }

        public int Index
        {

            get
            {

                return myIndex;

            }
            set
            {

                myIndex = value;

            }

        }

        public bool HasIndex
        {

            get
            {

                return myIndex > -1;

            }

        }

        public void ResetIndex()
        {

            if(myIndex == -1)
                myIndex = -1;

        }

        public string Name
        {

            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }

        }

        public bool HasName
        {

            get
            {

                return myName != null && myName.Length > 0;

            }

        }

        public void ResetName()
        {

            if(myName != null)
                myName = null;

        }

        public InvocationEntry InvocationEntry
        {

            get
            {

                return myInvocationEntry;

            }
            set
            {

                myInvocationEntry = value;

            }

        }

        public bool HasInvocationEntry
        {

            get
            {

                return myInvocationEntry != null;

            }

        }

        public void ResetInvocationEntry()
        {

            if(myInvocationEntry != null)
                myInvocationEntry = null;

        }

        public ParameterPreference ParameterPreference
        {

            get
            {

                return myParameterPreference;

            }
            set
            {

                myParameterPreference = value;

            }
 
        }
        
        public void ResetParameterPreference()
        {

            if(myParameterPreference != Reflect.ParameterPreference.Index)
                myParameterPreference = Reflect.ParameterPreference.Index;

        }

        public void Reset()
        {

            if(myIndex == -1)
                myIndex = -1;

            if(myName != null)
                myName = null;

            if(myInvocationEntry != null)
                myInvocationEntry = null;

            if(myParameterPreference != Reflect.ParameterPreference.Index)
                myParameterPreference = Reflect.ParameterPreference.Index;

        }

    }

}
