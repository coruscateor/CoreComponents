using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;
using CoreComponents.Characters;

namespace CoreComponents.Application
{
    public abstract class AppSimpleOutput : IPutOut<SenderEventArgs<AppSimpleOutput>, string>
    {

        protected TextOutputCache myOutputCache = new TextOutputCache();

        public event Create<SenderEventArgs<AppSimpleOutput>>.ADelegate OutputCacheUpdated;

        public string GetOutput()
        {

            return myOutputCache.GetOutput();

        }

        protected virtual void myOutputCache_Fed(FedEventArgs<string, IReadOnlyCache<string>> e)
        {

            //OnOutputCacheUpdated();

        }

        public abstract void Disengage();

        public abstract void Engage();

    }
}
