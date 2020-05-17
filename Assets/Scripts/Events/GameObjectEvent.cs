using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events {
    
    [Serializable] public class GameObjectEvent : UnityEvent<GameObject> { }
}