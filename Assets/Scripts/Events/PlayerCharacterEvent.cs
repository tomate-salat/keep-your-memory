using System;
using Player;
using UnityEngine.Events;

namespace Events {
    
    [Serializable] 
    public class PlayerCharacterEvent : UnityEvent<PlayerCharacter> {
        
    }
}