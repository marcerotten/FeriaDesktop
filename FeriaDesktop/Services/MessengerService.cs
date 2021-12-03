using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Services
{
    public class MessengerService
    {

        object _Suscriber;
        Action<object> _Action;
        public void Send<SalesDataMsg>(SalesDataMsg message)
        {
            _Action(message);
        }
        public void Suscribe<SalesDataMsg>(SalesDataMsg suscriber, Action<object> action)
        {

        }
    }
}    

