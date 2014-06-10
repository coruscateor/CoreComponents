using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Jobs
{

    public class QuickCurrentJob : QuickJob
    {

        public QuickCurrentJob()
        {
        }

        public QuickCurrentJob(bool TheUsesMemoryBarrier) : base(TheUsesMemoryBarrier)
        {
        }

        public void Success()
        {

            State = QuickJobState.Success;

        }

        public void Error()
        {

            State = QuickJobState.Error;

        }
        
    }

}
