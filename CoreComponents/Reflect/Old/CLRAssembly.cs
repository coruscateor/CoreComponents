using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CoreComponents.Data;

namespace CoreComponents.Reflect
{

    public class CLRAssembly : SubjectEngager<Assembly>, IGenericProvider<CLRAssembly>, IOpenSourceProvider<Assembly>, IActivateDeactivate
    {

        CLRTypeList myCLRTypeList;

        public event Gimmie<SenderEventArgs<IActivateable>>.GimmieSomethin Activated;

        public event Gimmie<SenderEventArgs<IDeactivateable>>.GimmieSomethin Deactivated;

        public event Gimmie<SenderEventArgs<CLRAssembly>>.GimmieSomethin SourceChanged;

        public CLRAssembly() : base(null)
        {
        }

        public CLRAssembly(Assembly theAssembly) : base(theAssembly)
        {
        }

        protected void Initalise()
        {

            myCLRTypeList = new CLRTypeList(this);

        }
		
		public void LoadFile(string path)
		{

            Engage(Assembly.LoadFile(path));

            OnSourceChanged();

            Activate();
			
		}

        public void Load(string assemblyString)
        {

            Engage(Assembly.Load(assemblyString));

            OnSourceChanged();

            Activate();

        }

        protected void OnActivated()
        {

            if (Activated != null)
                Activated(new SenderEventArgs<IActivateable>(this));

        }

        protected void OnDeactivated()
        {

            if (Deactivated != null)
                Deactivated(new SenderEventArgs<IDeactivateable>(this));

        }

        protected void OnSourceChanged()
        {

            if (SourceChanged != null)
                SourceChanged(new SenderEventArgs<CLRAssembly>(this));

        }

        public void Activate()
        {

            Engage();

            OnActivated();

        }

        public void Deactivate()
        {

            Disengage();

            OnDeactivated();

        }

        public bool IsActive
        {

            get
            {

                return myEngaged;

            }

        }

        protected override void EngageSubject()
        {

            //mySubject.

            //myCLRTypeList.

        }

        protected override void DisEngageSubject()
        {

        }


        public Assembly Source
        {

            get
            {
                return mySubject;
            }

        }

        public CLRTypeList Types
        {

            get
            {

                return myCLRTypeList;

            }

        }

    }
}
