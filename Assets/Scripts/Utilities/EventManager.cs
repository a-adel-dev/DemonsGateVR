using System;
using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields

    private static Dictionary<EventName, List<EventInvoker>> invokers = new Dictionary<EventName, List<EventInvoker>>();
    private static Dictionary<EventName, List<UnityAction>> listeners = new Dictionary<EventName, List<UnityAction>>();

    #endregion


    public static void Initialize()
    {
        foreach (EventName name in Enum.GetValues(typeof(EventName)))
        {
            if (!invokers.ContainsKey(name))
            {
                invokers.Add(name, new List<EventInvoker>());
                listeners.Add(name, new List<UnityAction>());
            }
            else
            {
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }

    public static void AddInvoker(EventName eventName, EventInvoker invoker)
    {
        foreach (UnityAction listener in listeners[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        invokers[eventName].Add(invoker);
    }


    public static void AddListener(EventName eventName, UnityAction listener)
    {
        foreach (EventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        listeners[eventName].Add(listener);
    }

    public static void RemoveInvoker(EventName eventName, EventInvoker invoker)
    {
        invokers[eventName].Remove(invoker);
    }
}

public enum EventName
{
    PlayerDeadEvent,
}
