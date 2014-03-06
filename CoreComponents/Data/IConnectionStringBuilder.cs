using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public interface IConnectionStringBuilder
    {

        void Add(string ParameterName);

        void Remove(string ParameterName);

        bool IsIncluded(string ParameterName);

        IEnumerable<KeyValuePair<string, string>> IncludedPrameters();

        bool IsAutoAdding();

        void InverseAutoAdd();

        string ConnectionType
        {
            get;
        }

        string ToString();

    }
}
