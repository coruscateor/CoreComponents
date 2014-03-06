using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;

namespace CoreComponents.Data.SchemaRetrieval
{
    public interface ISchemaSubCollection : IReadonlyHasName
    {

        bool UseRestrictionValues
        {

            get;
            set;

        }

        void InverseUseRestrictionValues();

        string[] RestrictionValues();

        bool CanProcureValues();

    }

    public interface IEditableValuesSubcollection
    {

        List<string> RestrictionValueCollection
        {

            get;

        }

    }

    public interface IRestrictedSubCollection : IEditableValuesSubcollection, ISchemaSubCollection
    {
    }

    public interface IGenericSchemaSubCollection : IRestrictedSubCollection, IHasName
    {
    }

    //Any table specific subcollections should implament the following interface.

    public interface ICacheQuerySubCollection : ISchemaSubCollection 
    {

        DataTable GetTable();

        //void Refresh();

    }

    public interface IRegulatedSubCollection : ICacheQuerySubCollection, IRestrictedSubCollection, IReadonlyChild<SchemaSubCollectionSet<IRegulatedSubCollection>>
    {
    }

}
