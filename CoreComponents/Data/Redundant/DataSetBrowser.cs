using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents.Items.Browsing;

namespace CoreComponents.Data.SchemaRetrieval
{

    public class DataSetBrowser : SetBrowser<DataSet, DataTable>, ISetBrowser<DataSet, DataTable>
    {

        //protected int myCurrentIndex;

        //protected DataSet mySet;

        public DataSetBrowser()
        {
        }

        public DataSetBrowser(DataSet Set)
        {

            Reset(Set);

        }

        //public DataSet Set
        //{

        //    get
        //    {

        //        return mySet;

        //    }
        //    set
        //    {

        //        mySet = value;

        //        First();

        //    }

        //}

        #region ITraverseonlySetBrowser<DataSet,DataTable> Members

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>>.GimmieSomethin MaximumLimitReached;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>>.GimmieSomethin MinimumLimitReached;

        //public event Gimmie<IndexChangedEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>, DataTable>>.GimmieSomethin ItemFetched;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>>.GimmieSomethin OutOfBounds;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>>.GimmieSomethin NoContent;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>>.GimmieSomethin SetChanged;

        //protected void OnMaximumLimitReached()
        //{

        //    if (MaximumLimitReached != null)
        //        MaximumLimitReached(new SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>(this));

        //}

        //protected void OnMinimumLimitReached()
        //{

        //    if (MinimumLimitReached != null)
        //        MinimumLimitReached(new SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>(this));

        //}

        //protected void OnItemFetched(DataTable item)
        //{

        //    if (ItemFetched != null)
        //        ItemFetched(new IndexChangedEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>, DataTable>(this, item, myCurrentIndex));

        //}

        //protected void OnOutOfBounds()
        //{

        //    if (OutOfBounds != null)
        //        OutOfBounds(new SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>(this));

        //}

        //protected void OnNoContent()
        //{

        //    if (NoContent != null)
        //        NoContent(new SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>(this));

        //}

        //protected void OnSetChanged()
        //{

        //    if(SetChanged != null)
        //        SetChanged(new SenderEventArgs<ITraverseonlySetBrowser<DataSet, DataTable>>(this));

        //}

        //public bool HasContents()
        //{

        //    if (mySet != null) {

        //        if (MaximumIndex < MinimumIndex)
        //        {

        //            if (myCurrentIndex > -1)
        //                myCurrentIndex = -1;

        //            return false;

        //        } else if (myCurrentIndex == -1)
        //            myCurrentIndex = 0;

        //        return true;

        //    }

        //    return false;

        //}

        //public bool IsInExtremities()
        //{

        //    if(CurrentIndex <= MinimumIndex)
        //        return true;
        //    else if (CurrentIndex >= MaximumIndex)
        //        return true;

        //    return false;

        //}

        protected override void InavalidateIndex()
        {

            if (mySet.Tables.Count < MinimumIndex)
            {

                myCurrentIndex = MinimumIndex;

            }

        }

        //up the index
        public override void Forward()
        {

            if(!isFetching)
            {

                if (HasContents)
                {

                    int next = myCurrentIndex + 1;

                    if (next <= MaximumIndex)
                    {

                        isFetching = true;
                        

                        if (myCurrentIndex == MinimumIndex)
                        {

                            OnOutOfMinimumLimit();

                        }

                        myCurrentIndex = next;

                        DataTable item = mySet.Tables[myCurrentIndex];

                        OnItemFetched(item);

                        isFetching = false;

                        if (myCurrentIndex == MaximumIndex)
                        {

                            OnMaximumLimitReached();

                        }

                    } else
                    {

                        OnOutOfBounds();

                    }

                } else
                {

                    OnNoContent();

                }

            }

        }

        public override void Back()
        {

            if(!isFetching)
            {

                if (HasContents)
                {

                    int next = myCurrentIndex - 1;

                    if (next >= MinimumIndex)
                    {

                        isFetching = true;

                        if (myCurrentIndex == MaximumIndex)
                        {

                            OnOutOfMaximumLimit();

                        }

                        myCurrentIndex = next;

                        DataTable item = mySet.Tables[myCurrentIndex];

                        OnItemFetched(item);

                        isFetching = false;

                        if (myCurrentIndex == MinimumIndex)
                        {

                            OnMinimumLimitReached();

                        }

                    } else
                    {

                        OnOutOfBounds();

                    }

                } else
                {

                    OnNoContent();

                }
            }

        }

        public override void First()
        {

            
            if (!isFetching)
            {

                if (HasContents)
                {

                    isFetching = true;

                    if (myCurrentIndex == MaximumIndex)
                    {

                        OnOutOfMaximumLimit();

                    }

                    myCurrentIndex = MinimumIndex;

                    OnItemFetched(mySet.Tables[myCurrentIndex]);

                    isFetching = false;

                    OnMinimumLimitReached();

                } else
                {

                    OnNoContent();

            }

            }

        }

        public override void Last()
        {

           if (!isFetching)
           {

                if (HasContents)
                {

                    isFetching = true;

                    if (myCurrentIndex == MinimumIndex)
                    {

                        OnOutOfMinimumLimit();

                    }

                    myCurrentIndex = MaximumIndex;

                    OnItemFetched(mySet.Tables[MaximumIndex]);

                    isFetching = false;

                    OnMaximumLimitReached();

                    

                } else
                {

                    OnNoContent();

                }
          }

        }

        public override void Current()
        {


            //if(!isFetching)
            //{

                if (HasContents)
                {

                    isFetching = true;

                    OnItemFetched(mySet.Tables[myCurrentIndex]);

                    isFetching = false;

                } else
                {

                    OnNoContent();

                }

            //}

        }

        public override void SkipTo(int Index)
        {

            if (!isFetching)
            {

                if (HasContents)
                {

                    if (Index != myCurrentIndex) 
                    {

                            if (Index <= MaximumIndex && Index >= MinimumIndex)
                            {

                                isFetching = true;

                                //int lastIndex = myCurrentIndex;

                                if (myCurrentIndex == MinimumIndex)
                                {

                                    OnOutOfMinimumLimit();

                                } else if (myCurrentIndex == MaximumIndex)
                                {

                                    OnOutOfMaximumLimit();

                                }

                                myCurrentIndex = Index;

                                OnItemFetched(mySet.Tables[myCurrentIndex]);

                                isFetching = false;

                                if (myCurrentIndex == MinimumIndex)
                                {

                                    OnMinimumLimitReached();

                                    return;

                                } else if (myCurrentIndex == MaximumIndex)
                                {

                                    OnMaximumLimitReached();

                                    return;

                                }
                                //OnItemFetched(item);

                        } else
                        {

                            OnOutOfBounds();

                        }

                    }
                }

                } else
                {

                    OnNoContent();

                }

        }

        public override int MaximumIndex
        {
            get
            {
                if (mySet != null)
                {

                    if (mySet.Tables.Count > 1)
                        return mySet.Tables.Count - 1;
                    else
                        return 0;

                } else
                    return 0;

            }
        }

        public override int MinimumIndex
        {
            get
            {
                if (mySet != null)
                {

                    if (mySet.Tables.Count >= 1)
                        return 1;
                    else
                        return 0;

                } else
                    return 0;

            }
        }

        public static string NoName
        {
    
            get
            {
                return "<None>";
            }

        }

    }


        //public int CurrentIndex
        //{
        //    get
        //    {
        //        return myCurrentIndex;
        //    }
        //}

        //public int Count
        //{
        //    get
        //    {
        //        if (mySet != null)
        //            return mySet.Tables.Count;
        //        else
        //            return 0;
        //    }
        //}

        #endregion

        #region ISetBrowser<DataSet,DataTable> Members

        //public DataSet Set
        //{
        //    get
        //    {

        //        return mySet;

        //    }
        //    set
        //    {

        //        Reset(value);

        //        //mySet = value;

        //        //First();

        //        //OnSetChanged();

        //    }
        //}

        #endregion

        //public static implicit operator ITraverseonlySetBrowser<object, object>(DataSetBrowser Browser)
        //{

        //    return (ITraverseonlySetBrowser<object, object>)Browser;

        //}

}
