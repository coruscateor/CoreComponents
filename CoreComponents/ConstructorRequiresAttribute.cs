using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor)]
    public class ConstructorRequiresAttribute : Attribute
    {

        protected Type[] myRequiredTypes;

        public ConstructorRequiresAttribute(params Type[] TheRequiredTypes)
        {

            myRequiredTypes = TheRequiredTypes;

        }

        public Type[] RequiredTypes
        {

            get
            {

                return myRequiredTypes.Clone() as Type[];

            }

        }

        public int Count
        {

            get
            {
                
                return myRequiredTypes.Length;

            }

        }

    }

    //'<' unexpected : attributes cannot be generic


    //public class ConstructorRequiresAttribute<T1> : ConstructorRequiresAttribute
    //{

    //    public ConstructorRequiresAttribute() : base(typeof(T1))
    //    {
    //    }

    //}

    //public class ConstructorRequiresAttribute<T1, T2> : ConstructorRequiresAttribute
    //{

    //    public ConstructorRequiresAttribute()
    //        : base(typeof(T1), typeof(T2))
    //    {
    //    }

    //}

    //public class ConstructorRequiresAttribute<T1, T2, T3> : ConstructorRequiresAttribute
    //{

    //    public ConstructorRequiresAttribute()
    //        : base(typeof(T1), typeof(T2), typeof(T3))
    //    {
    //    }

    //}

    //public class ConstructorRequiresAttribute<T1, T2, T3, T4> : ConstructorRequiresAttribute
    //{

    //    public ConstructorRequiresAttribute()
    //        : base(typeof(T1), typeof(T2), typeof(T3), typeof(T4))
    //    {
    //    }

    //}

    //public class ConstructorRequiresAttribute<T1, T2, T3, T4, T5> : ConstructorRequiresAttribute
    //{

    //    public ConstructorRequiresAttribute()
    //        : base(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5))
    //    {
    //    }

    //}

    //public class ConstructorRequiresAttribute<T1, T2, T3, T4, T5, T6> : ConstructorRequiresAttribute
    //{

    //    public ConstructorRequiresAttribute()
    //        : base(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6))
    //    {
    //    }

    //}

}
