﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    [AttributeUsage(AttributeTargets.Property)]
    public class JobResultAttribute : Attribute
    {

        public JobResultAttribute()
        {
        }

    }

}
