using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application.Visual
{
    public interface ISimpleVisualComponent
    {

        void Hide();

        void Show();

        bool Visible
        {

            get;

        }

    }
}
