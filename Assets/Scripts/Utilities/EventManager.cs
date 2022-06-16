using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void OnUpdateHealth(float value);
    public static OnUpdateHealth onHealthChange;

}
