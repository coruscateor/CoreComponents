using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public class SelectStatementElements : IEnumerable<QueryObject>
    {
        List<QueryObject> myListQueryObject = new List<QueryObject>();

        public SelectStatementElements() 
        {

            //myListQueryObject.ForEach(

        }

        public IEnumerator<QueryObject> GetEnumerator()
        {

            return myListQueryObject.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myListQueryObject.GetEnumerator();

        }
    }
}
