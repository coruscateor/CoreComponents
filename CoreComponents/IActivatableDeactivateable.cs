using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IActivateable : IIsActive 
    {

        void Activate();
		
		event Action<SenderEventArgs<IActivateable>> Activated;
		
    }
	
	public interface IActivateableCantDeactivate : IActivateable
    {

        event Action<SenderEventArgs<IActivateable>> Deactivated;

    }

    public interface IIsActive
    {

        bool IsActive
        {

            get;

        }

    }

    public interface IDeactivateable : IIsActive
    {
		
        void Deactivate();

        event Action<SenderEventArgs<IDeactivateable>> Deactivated;

    }
	
	public interface IDeactivateableCantActivate : IDeactivateable
    {

        event Action<SenderEventArgs<IDeactivateable>> Activated;		

    }

	public interface IActivateDeactivate : IDeactivateable, IActivateable
    {
    }
	
}
