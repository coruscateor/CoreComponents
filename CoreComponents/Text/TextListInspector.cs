
using System;
using System.Collections;
using System.Collections.Generic;
using CoreComponents.Items;

namespace CoreComponents.Text
{

    public static class TextListInspector  //<TTextEntity> where TTextEntity : ITextEntity
    {

        static TextListInspector()
        {
        }

        //public ReadonlyList<TTextEntity> Gather<TTextEntity>(IEnumerable<ITextEntity> Items) where TTextEntity : ITextEntity
        //{

        //    List<TTextEntity> GatheredItems = new List<TTextEntity>();

        //    foreach (ITextEntity Item in Items)
        //    {

        //        if (Item is TTextEntity)
        //        {

        //            GatheredItems.Add((TTextEntity)Item);

        //        }

        //    }

        //    return new ReadonlyList<TTextEntity>(GatheredItems);

        //}

        public static List<TTextEntity> Gather<TTextEntity>(IEnumerable<ITextEntity> Items) where TTextEntity : ITextEntity
        {

            List<TTextEntity> GatheredItems = new List<TTextEntity>();

            foreach (ITextEntity Item in Items)
            {

                if (Item is TTextEntity)
                {

                    GatheredItems.Add((TTextEntity)Item);

                }

            }

            return GatheredItems;

        }

        public static TTextEntity[] GatherToArray<TTextEntity>(IEnumerable<ITextEntity> Items) where TTextEntity : ITextEntity
        {

            List<TTextEntity> GatheredItems = new List<TTextEntity>();

            foreach (ITextEntity Item in Items)
            {

                if (Item is TTextEntity)
                {

                    GatheredItems.Add((TTextEntity)Item);

                }

            }

            return GatheredItems.ToArray();

        }

        public static List<TTextEntity> Exclude<TTextEntity>(IEnumerable<ITextEntity> Items) where TTextEntity : ITextEntity
        {

            List<TTextEntity> IncludedItems = new List<TTextEntity>();

            foreach (ITextEntity Item in Items)
            {

                if (!(Item is TTextEntity))
                {

                    IncludedItems.Add((TTextEntity)Item);

                }

            }

            return IncludedItems;

        }

        public static TTextEntity[] ExcludeToArray<TTextEntity>(IEnumerable<ITextEntity> Items) where TTextEntity : ITextEntity
        {

            List<TTextEntity> IncludedItems = new List<TTextEntity>();

            foreach (ITextEntity Item in Items)
            {

                if (!(Item is TTextEntity))
                {

                    IncludedItems.Add((TTextEntity)Item);

                }

            }

            return IncludedItems.ToArray();

        }
    }
    
}
