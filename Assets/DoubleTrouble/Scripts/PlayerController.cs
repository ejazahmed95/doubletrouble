using EAUnity.Core;
using EAUnity.Event;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GenericDictionary<CharacterType, BaseCharacter> characters;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private ObjectPool<PickupItem> pickupsPool;
    [SerializeField] private CameraFollow playerCam;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject gameOverObj;

    [SerializeField] private AudioClip switchSfx;
    [SerializeField] private AudioClip pickupSfx;
   
    private BaseCharacter _activeCharacter;

    private void Start() {
        Random.InitState((int) System.DateTime.Now.Ticks);
        playerInfo.ActiveCharacter = CharacterType.Hero;
        foreach (var (key, baseCharacter) in characters) {
            baseCharacter.Init(playerInfo, key==playerInfo.ActiveCharacter);
        }
        _activeCharacter = GetCharacter(CharacterType.Hero);
    }

    private void ActivateCharacter(CharacterType type) {
        _activeCharacter.Activate(false);
        _activeCharacter = GetCharacter(type);
        playerInfo.ActiveCharacter = type;
        _activeCharacter.Activate(true);
        playerInput.SwitchCurrentActionMap(_activeCharacter.ActionMap);
        playerCam.target = _activeCharacter.transform;
        AudioManager.Instance.Play(switchSfx);
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
        playerInfo.CurrentAttack += 1;
        AudioManager.Instance.Play(pickupSfx);
        pickupsPool.RemoveObject(item);
    }

    public void OnDeadCb(PlayerInfo info) {
        gameOverObj.SetActive(true);
        gameOverText.text = $"{info.id} Lost!";
    }
}