using EAUnity.Core;
using EAUnity.Event;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GenericDictionary<CharacterType, BaseCharacter> characters;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int id = 0;

    private BaseCharacter _activeCharacter;
    
    public void ActivateCharacter(CharacterType type) {
        _activeCharacter = GetCharacter(type);
        playerInput.SwitchCurrentActionMap(_activeCharacter.ActionMap);
    }

    private BaseCharacter GetCharacter(CharacterType type) {
        return characters[type];
    }

    public void OnControlChange(IGameEventData data) {
        if (Utils.TryConvertVal(data, out ControlChangeEventData changeData) == false) return;
        if (changeData.PlayerId != id) return;
        
        ActivateCharacter(changeData.CharacterType);
    }
}