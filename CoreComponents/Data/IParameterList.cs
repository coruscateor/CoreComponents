using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace CoreComponents.Data
{

    public interface IParameterList<TParameter> : IList<TParameter>, IToArray<TParameter> where TParameter : DbParameter, new()
    {

        void AddRange(IEnumerable<TParameter> TheCollection);

        void Add(object TheValue);

        void Add(string TheName, object TheValue);

        void Swap(int FirstIndex, int SecondIndex);

        void Set(int Index, object TheValue);

        void Set(int Index, string TheName, object TheValue);

        bool TrySet(int Index, object TheValue);

        bool TrySet(int Index, string TheName, object TheValue);

        void AddTo(DbParameterCollection TheCollection);

        void AddToAndClear(DbParameterCollection TheCollection);

        void AddTo(DbCommand TheCommand);

        void AddToAndClear(DbCommand TheCommand);

        void SetParametersOf(DbParameterCollection TheCollection);

        void SetParametersOf(DbCommand TheCommand);

        void GetFrom(object TheObject);

        void GetFromItems(IDictionary<string, object> Items);

        void GetFromItems(dynamic Items);

        void SetFrom(object TheObject);

        void SetFromItems(IDictionary<string, object> Items);

        void SetFromItems(dynamic Items);

        bool RemoveFirst();

        bool RemoveLast();

    }

}
