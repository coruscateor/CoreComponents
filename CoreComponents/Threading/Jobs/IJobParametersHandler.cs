using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IJobParametersHandler
    {

        IJobHandler JobHandler
        {

            get;

        }

    }

    public interface IJobParametersHandler<TJob> : IJobParametersHandler where TJob : IJob 
    {

        TJob JobHandler
        {

            get;

        }

    }

}
