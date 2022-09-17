﻿using EAUnity.Core;
using EAUnity.Event;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GenericDictionary<CharacterType, BaseCharacter> characters;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerInfo playerInfo;

    private BaseCharacter _activeCharacter;

    private void Start() {
        Random.InitState((int) System.DateTime.Now.Ticks);
        foreach (var (key, baseCharacter) in characters) {
            baseCharacter.SetPlayerInfo(playerInfo);
        }
    }
    
    public void ActivateCharacter(CharacterType type) {
        _activeCharacter = GetCharacter(type);
        playerInput.SwitchCurrentActionMap(_activeCharacter.ActionMap);
    }

    private BaseCharacter GetCharacter(CharacterType type) {
        return characters[type];
    }

    public void OnControlChange(IGameEventData data) {
        if (Utils.TryConvertVal(data, out ControlChangeEventData changeData) == false) return;
        if (changeData.PlayerInfo.id != playerInfo.id) return;
        
        ActivateCharacter(changeData.CharacterType);
    }

    public void OnItemPicked(PickupItem item) {
        playerInfo.CurrentAttack++;
        //itemObjectPool.RemoveItem(item);
    }
}