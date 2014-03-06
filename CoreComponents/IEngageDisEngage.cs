using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IEngage
    {

        //void Engage();

        object EngagedWith
        {

            get;

        }

        bool IsEngaged
        {
            get;
        }

    }

    public interface IEngage<TSubject> : IEngage
    {

        void Engage(TSubject Subject);

        new TSubject EngagedWith
        {

            get;

        }

    }


    public interface IDisEngage
    {

        void DisEngage();

        /*
        object EngagedWith
        {

            get;

        }
        */

        bool IsEngaged
        {
            get;
        }

    }

    public interface IEngageDisEngage : IEngage, IDisEngage
    {
    }

    public interface IEngageDisEngage<TSubject> : IEngageDisEngage, IEngage<TSubject>
    {
    }
}
