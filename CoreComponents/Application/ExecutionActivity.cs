using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Application
{

    public interface IExecutionActivity<TCommand>
    {

        TCommand Command
        {

            get;
            set;
        }

        Delegate Action
        {

            get;
            set;

        }

        void Process(TCommand Input);

    }

    public abstract class ExecutionActivity<TCommand> : IExecutionActivity<TCommand> //, TResult> //where TResult
    {

        protected TCommand myCommand;

        protected Delegate myAction;

        protected bool myHasArguments;

        protected Type[] myGenericArgs;

        protected bool myHasGenericArgs;

        public TCommand Command
        {

            get
            {

                return myCommand;

            }
            set
            {

                myCommand = value;

            }

        }

        public Delegate Action
        {

            get
            {

                return myAction;

            }
            set
            {

                myAction = value;

                MethodInfo meth = myAction.Method;

                //Cannot return a value.

                if (typeof(void) != meth.ReturnType)
                {

                    if (Return.IsGreaterThanZero(meth.GetParameters().Length))
                        myHasArguments = true;
                    else
                        myHasArguments = false;

                    myGenericArgs = meth.GetGenericArguments();

                    if (Return.IsGreaterThanZero(myGenericArgs.Length))
                        myHasGenericArgs = true;
                    else
                        myHasArguments = false;

                }

            }

        }
         
        public virtual void Process(TCommand Input)
        {

            if (IsValid(Input))
            {

                if (myHasArguments)
                {

                    //myAction.DynamicInvoke(

                } else
                {

                    myAction.DynamicInvoke(null);

                }
            }

        }

        protected abstract bool IsValid(TCommand Input);

    }
}
