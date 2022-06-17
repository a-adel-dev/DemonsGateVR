using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    private static PlayerHealth _invoker;
    private static UnityAction _listener;


    
    public static void AddInvoker(PlayerHealth invoker)
    {
        _invoker = invoker;
        if (_listener != null)
        {
            invoker.AddPLayerDeadEventListener(_listener);
        }
    }

    public static void AddListener(UnityAction handler)
    {
        _listener = handler;
        if (_invoker != null)
        {
            _invoker.AddPLayerDeadEventListener(_listener);   
        }
    }

}
