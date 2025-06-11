using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp
{
    public class Notifier
    {
        public delegate void Notify(string message);
        public event Notify OnAction;

        public void TriggerEvent(string message)
        {
            OnAction?.Invoke(message);
        }
    }
}
