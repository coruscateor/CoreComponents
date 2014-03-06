using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.SourceAndDestination
{

    public class SubjectToSubjectBroker<TModel, TSource> : MutualBroker<TModel, TSource>
        where TModel : IHasSubject<TSource>
        where TSource : IHasSubject<TModel>
    {

        public SubjectToSubjectBroker()
        {
        }

        protected void SignUpModel(TModel Model)
        {

            Model.SubjectChanged += Model_SubjectChanged;

        }

        void Model_SubjectChanged(SenderEventArgs<IHasSubject<TSource>> Somethin)
        {

            Model.SubjectChanged -= Model_SubjectChanged;

            SetModel(default(TModel));

        }

        protected void SignUpSource(TSource Source)
        {

            Source.SubjectChanged += Source_SubjectChanged;

        }

        void Source_SubjectChanged(SenderEventArgs<IHasSubject<TModel>> Somethin)
        {

            Model.SubjectChanged -= Model_SubjectChanged;

			SetSource(default(TSource));

        }

        protected override void SetSource(TSource TheSource)
        {

            bool HasModel = Return.IsNotNull<TModel>(myModel);

            if (HasModel)
            {

                myModel.Subject = TheSource;

                if (!myModel.HasASubject)
                {

                    SignUpSource(mySource);

                }

            }

            mySource.Subject = myModel;

        }

        protected override void SetModel(TModel TheModel)
        {

            bool HasSource = Return.IsNotNull<TSource>(mySource);

            if (HasSource)
            {

                mySource.Subject = TheModel;

                if (!myModel.HasASubject)
                {

                    SignUpModel(myModel);

                }

            }

            myModel.Subject = mySource;

        }

        protected override void RemoveSource()
        {

            myModel.SubjectChanged -= Model_SubjectChanged;

            myModel.RemoveSubject();
        }

        protected override void RemoveModel()
        {

            mySource.SubjectChanged -= Source_SubjectChanged;

            mySource.RemoveSubject();
        }

    }

}
