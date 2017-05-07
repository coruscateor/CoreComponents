using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public interface IDoWorkR<T>
    {

        T DoWork();

    }

    public interface IDoWorkR<TResult, T>
    {

        TResult DoWork(T p);

    }

    public interface IDoWorkR<TResult, T1, T2>
    {

        TResult DoWork(T1 p1, T2 p2);

    }

    public interface IDoWorkR<TResult, T1, T2, T3>
    {

        TResult DoWork(T1 p1, T2 p2, T3 p3);

    }

    public interface IDoWorkR<TResult, T1, T2, T3, T4>
    {

        TResult DoWork(T1 p1, T2 p2, T3 p3, T4 p4);

    }

}
