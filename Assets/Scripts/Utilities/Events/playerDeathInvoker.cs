using System;
using UnityEngine.Events;

namespace Utilities.Events
{
    public class playerDeathInvoker : EventInvoker
    {
        private void Start()
        {
            EventManager.AddInvoker(EventName.PlayerDeadEvent, this);
        }
        
        
    }
}