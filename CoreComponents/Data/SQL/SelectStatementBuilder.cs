using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Data;
using CoreComponents.Items;

namespace CoreComponents.Data.SQL
{
    public class SelectStatementBuilder : SelectStatementElements, IEnumerable<IQueryObject>
    {

        //protected StringBuilder mySB;

        //public delegate void ErrorDelegate(ErrorEventArgs<SelectStatementBuilder> Parameter);

        //public event ErrorDelegate Error;

        protected bool myIsDistinct;

        protected bool myIsAssemblingQuery;

        protected List<string> myUpToList = new List<string>();

        //protected bool myIsSelectingAll;

        //protected Queue<string> myPostionInStament = new Queue<string>();

        protected LinkedList<string> myPostionInStament = new LinkedList<string>();

        //protected List<object> myDbSelectionObjects = new List<object>();

        //protected ReadOnlyList<object> myRODbSelectionObjects;

        protected List<IQueryObject> myQueryObjects = new List<IQueryObject>();

        protected object myLockObject = new object();

        public SelectStatementBuilder() 
        {

            //myRODbSelectionObjects = new ReadOnlyList<object>(myDbSelectionObjects);
            
            //mySB = new StringBuilder();
            //System.Collections.Generic
            //AppendSELECT_Value();

        }

        protected void OnError(Exception TheException) 
        {

            //if (Error != null) 
            //{

            //    Error(new ErrorEventArgs<SelectStatementBuilder>(this, TheException)); 

            //}

        }

        protected void OnError(string TheMessage) 
        {

            //if (Error != null) 
            //{

            //    Error(new ErrorEventArgs<SelectStatementBuilder>(this, TheMessage)); 

            //}

        }

        //public SelectStatementBuilder(StringBuilder TheSB)
        //{

            //mySB = new StringBuilder(TheSB.ToString());

            //AppendSELECT_Value();

        //}

        public bool IsSelectingAll 
        {

            get 
            {

                return myQueryObjects.Count > 0;

            }

        }

        public bool IsAssemblingQuery 
        {

            get 
            {

                return myIsAssemblingQuery;

            }

        }

        public bool IsDistinct 
        {

            get 
            {

                return myIsDistinct;

            }

            set 
            {

                lock (myLockObject) 
                {

                    if (!myIsAssemblingQuery)
                    {

                        myIsDistinct = value;

                    } //Error
                }

            }

        }

        protected virtual void Selecting() 
        {

            if (!myUpToList.Contains(ANSI.SELECT)) 
            {

                myUpToList.Add(ANSI.SELECT);

            }
            //mySB.Append(ANSI.SELECT);
            
            //myPostionInStament.Add(ANSI.SELECT, true);

        }

        public virtual SelectStatementBuilder SelectAll() 
        {

            lock (myLockObject)
            {

                if (myIsAssemblingQuery)
                {

                    OnError("Curently Active.");
                    
                }
                else
                {

                    Selecting();

                    myQueryObjects.Clear();

                }
            }

            return this;

        }

        public virtual SelectStatementBuilder Select(params IQueryObject[] TheQueryObjects) 
        {

            lock (myLockObject)
            {

                if (myIsAssemblingQuery)
                {

                    OnError("Curently Active.");

                }
                else
                {

                    Selecting();

                }

                return this;
            }

        }

        //Get every table or result set queried.
        public ReadOnlyList<ITableObject> TableObjectList()
        {
            lock (myLockObject)
            {
                List<ITableObject> ITOList = new List<ITableObject>();

                foreach (IQueryObject IQO in myQueryObjects)
                {

                    if (!ITOList.Contains(IQO.FromTable))
                    {

                        ITOList.Add(IQO.FromTable);

                    }

                }

                return new ReadOnlyList<ITableObject>(ITOList);

            }

        }

        public SelectStatementBuilder Where(IQueryObject ArgLeft, string Operator, IQueryObject ArgRight) 
        {

            return this;

        }

        public SelectStatementBuilder Where(IQueryObject ArgLeft, string Operator, string ArgRight)
        {

            return this;

        }

        /*
        public virtual SelectStatementBuilder Select(params object[] TheColumns) 
        {

            myIsSelectingAll = false;

            Selecting();

            //mySB.Append(" ");

            //for (int i = 0; i < TheColumnNames.Length; i++)
            //{

                //object  TheColumnNames[i];

                //mySB.Append();

                //if (i != TheColumnNames.Length) 
                //{

                    //mySB.Append(", ");

                //}

            //}

            return this;

        }
        */

        /*
        public virtual SelectStatementBuilder From() 
        {

            return this;

        }
        */
        /*
        public virtual SelectStatementBuilder From(params string[] TheTables)
        {

            return From(new List<string>(TheTables));

        }
        */
        /*
        public virtual SelectStatementBuilder From(IEnumerable<string> TheTables)
        {

            //Lazy<List<object>> LazyAddToList = new Lazy<List<object>>();

            //Lazy<List<object>> LazyRejectList = new Lazy<List<object>>();

            List<object> AcceptedList = new List<object>();

            List<object> RejectedList = new List<object>();


            foreach (string ParamTableObject in TheTables) 
            {

                //myDbSelectionObjects.Contains(ParamTableObject, 

                foreach (object TableObject in myDbSelectionObjects) 
                {

                    if(TableObject is string) 
                    {
                        if (ParamTableObject != TableObject.ToString()) 
                        {

                            AcceptedList.Add(ParamTableObject);

                            continue;

                        }

                        RejectedList.Add(ParamTableObject);

                    }
                    else if (TableObject is KeyValuePair<string, string>) 
                    {

                        KeyValuePair<string, string> TableWithAlias = (KeyValuePair<string, string>)TableObject;

                        if (ParamTableObject != TableWithAlias.Key) 
                        {
                        }
                        else if (ParamTableObject != TableWithAlias.Value) 
                        {
                        }

                    }
                    else if (TableObject is DbTable) 
                    {
                    }
                    else if (TableObject is KeyValuePair<string, DbTable>) 
                    {
                    }

                }

            }

            return this;

        }
        */
        /*
        public virtual SelectStatementBuilder From(params DbTable[] TheTables)
        {

            return From(new List<DbTable>(TheTables));

        }

        public virtual SelectStatementBuilder From(IEnumerable<DbTable> TheTables)
        {

            return this;

        }
        */
        //KeyValuePair<string, string> - alias, table
        /*
        public virtual SelectStatementBuilder From(params KeyValuePair<string, string>[] TheTables)
        {

            return From(new List<KeyValuePair<string, string>>(TheTables));

        }

        public virtual SelectStatementBuilder From(IEnumerable<KeyValuePair<string, string>> TheTables)
        {

            return this;

        }

        public virtual SelectStatementBuilder From(params KeyValuePair<string, DbTable>[] TheTables)
        {

            return From(new List<KeyValuePair<string, DbTable>>(TheTables));

        }

        public virtual SelectStatementBuilder From(IEnumerable<KeyValuePair<string, DbTable>> TheTables)
        {

            return this;

        }
        */
        /*
        public virtual SelectStatementBuilder From(params object[] TheTables) 
        {

            return this;

        }
        */
        /*
        public virtual SelectStatementBuilder Where() 
        {

            return this;

        }

        public bool IsSelectingAll 
        {

            get 
            {

                return myIsSelectingAll;

            }

        }

        public ReadOnlyList<object> DbSelectionObjects 
        {

            get 
            {

                return myRODbSelectionObjects;

            }

        }
        */
        public void Assemble() 
        {
        }

        public IEnumerator<IQueryObject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
