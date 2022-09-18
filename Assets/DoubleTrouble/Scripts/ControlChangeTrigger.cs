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

        private GameData _gameData;
        
        private void Start() {
            if (GameData.Instance == null) {
                Log.Err("Game Data is NULL");
                return;
            }
            _gameData = GameData.Instance;
            bgSpriteRef.color = _gameData.GetPlayer(id).color;
            spriteRef.sprite = _gameData.gameInfo.characterSprites[characterType];
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if ((col.CompareTag("Player") || col.CompareTag("Player2")) == false) {
                return;
            }
            changeEvent.Raise(new ControlChangeEventData{CharacterType = characterType, PlayerInfo = _gameData.GetPlayer(id)});
        }
        
    }
}