using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public class AsynchronousDoNothingContainer : IAsynchronousWorkContainer
    {

        public AsynchronousDoNothingContainer()
        { 
        }

        public bool IsBusy
        {

            get 
            {
                
                return false;
            
            }

        }

        public void Execute()
        {
            
        }

    }

}
