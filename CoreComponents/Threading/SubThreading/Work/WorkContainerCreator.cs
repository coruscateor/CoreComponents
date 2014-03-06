using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public static class WorkContainerCreator
    {

        public static IWorkContainer Create(Type TheTypeOfWorkContainer)
        {

            return Activator.CreateInstance(TheTypeOfWorkContainer) as IWorkContainer;

        }

        public static IWorkContainer Create(Type TheTypeOfWorkContainer, params object[] TheParameters)
        {

            return Activator.CreateInstance(TheTypeOfWorkContainer, TheParameters) as IWorkContainer;

        }

        public static IWorkContainer Create(Type TheTypeOfWorkContainer, IEnumerable<object> TheParameters)
        {

            return Activator.CreateInstance(TheTypeOfWorkContainer, TheParameters.ToArray()) as IWorkContainer;

        }

        public static IWorkContainer Create<TWorkContainer>() where TWorkContainer : IWorkContainer, new()
        {

            return new TWorkContainer();

        }

    }

    public static class WorkContainerCreator<T1, T2>
    {

        public static IWorkContainer<T1, T2> Create(Type TheTypeOfWorkContainer)
        {

            return Activator.CreateInstance(TheTypeOfWorkContainer) as IWorkContainer<T1, T2>;

        }

        public static IWorkContainer<T1, T2> Create(Type TheTypeOfWorkContainer, params object[] TheParameters)
        {

            return Activator.CreateInstance(TheTypeOfWorkContainer, TheParameters) as IWorkContainer<T1, T2>;

        }

        public static IWorkContainer<T1, T2> Create(Type TheTypeOfWorkContainer, IEnumerable<object> TheParameters)
        {

            return Activator.CreateInstance(TheTypeOfWorkContainer, TheParameters.ToArray()) as IWorkContainer<T1, T2>;

        }

        public static IWorkContainer<T1, T2> Create<TWorkContainer>() where TWorkContainer : IWorkContainer<T1, T2>, new()
        {

            return new TWorkContainer();

        }

    }

}
