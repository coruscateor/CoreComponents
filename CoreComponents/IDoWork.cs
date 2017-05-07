using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public interface IDoWork
    {

        void DoWork();

    }

    public interface IDoWork<T>
    {

        void DoWork(T p);

    }

    public interface IDoWork<T1, T2>
    {

        void DoWork(T1 p1, T2 p2);

    }

    public interface IDoWork<T1, T2, T3>
    {

        void DoWork(T1 p1, T2 p2, T3 p3);

    }

    public interface IDoWork<T1, T2, T3, T4>
    {

        void DoWork(T1 p1, T2 p2, T3 p3, T4 p4);

    }

}
