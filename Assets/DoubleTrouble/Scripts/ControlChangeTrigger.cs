using System;
using EAUnity.Event;
using UnityEngine;

namespace DoubleTrouble.Scripts {
    public class ControlChangeTrigger : MonoBehaviour {
        [SerializeField] private CharacterType characterType;
        [SerializeField] private int playerId;
        [SerializeField] private GameEvent changeEvent;
        
        private void OnTriggerEnter2D(Collider2D col) {
            if ((col.CompareTag("Player") || col.CompareTag("Player2")) == false) {
                return;
            }
            changeEvent.Raise(new ControlChangeEventData{CharacterType = characterType, PlayerId = playerId});
        }
    }
}