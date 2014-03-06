using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Something

namespace CoreComponents
{
    interface IRunnable
    {

        void Run();

    }

    interface IShutDownable
    {

        void ShutDown();

    }

    interface IRunnableShutDownable : IRunnable, IShutDownable
    {
    }

    interface IPRunnable<T>
    {

        void Run(T args);

    }

    interface IPShutDownable<T>
    {

        void ShutDown(T args);

    }

    interface IPRunnableShutDownable<T> : IPRunnable<T>, IPShutDownable<T>
    {
    }

    //Generic Interfaces

    interface IRunnable<T>
    {

        T Run(); 

    }

    interface IShutDownable<T>
    {

        T ShutDown();

    }

    interface IRunnableShutDownable<T> : IRunnable<T>, IShutDownable<T>
    {
    }

    interface IPRunnable<T, V>
    {

        T Run(V args);

    }

    interface IPShutDownable<T, V>
    {

        T ShutDown(V args);

    }

    interface IPRunnableShutDownable<T, V> : IPRunnable<T, V>, IPShutDownable<T, V>
    {
    }

}
