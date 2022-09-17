using System;
using EAUnity.Core;
using EAUnity.Event;
using UnityEngine;

namespace DoubleTrouble.Scripts {
    public class ControlChangeTrigger : MonoBehaviour {
        [SerializeField] private CharacterType characterType;
        [SerializeField] private GameEvent changeEvent;
        [SerializeField] private int id;
        
        [SerializeField] private SpriteRenderer bgSpriteRef;
        [SerializeField] private SpriteRenderer spriteRef;

        private void Start() {
            if (GameData.Instance == null) {
                Log.Err("Game Data is NULL");
                return;
            }
            bgSpriteRef.color = GameData.Instance.GetPlayer(id).color;
            spriteRef.sprite = GameData.Instance.gameInfo.characterSprites[characterType];
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if ((col.CompareTag("Player") || col.CompareTag("Player2")) == false) {
                return;
            }
            changeEvent.Raise(new ControlChangeEventData{CharacterType = characterType, PlayerInfo = GameData.Instance.GetPlayer(id)});
        }
        
    }
}