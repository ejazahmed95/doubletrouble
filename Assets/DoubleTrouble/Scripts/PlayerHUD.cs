using System;
using EAUnity.Core;
using EAUnity.Event;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    [SerializeField] private TMP_Text abilityText;
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private PlayerInfo playerInfo;

    private void Start() {
        GetComponent<Image>().color = playerInfo.color * 0.8f;
    }
    
    public void UpdateText(IGameEventData data) {
        Log.Info($"Updating Text!! {playerInfo.id} = {playerInfo.CurrentAttack}");
        attackText.text = $"Attack Points: {playerInfo.CurrentAttack}";
        healthText.text = $"Health       : {playerInfo.Health}";

        abilityText.text = playerInfo.ActiveCharacter switch {
            CharacterType.Hero => $"Hero       : Attack Diamond",
            CharacterType.Menu => $"Menu       : Teleport Diamond",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
}