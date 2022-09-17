using System;
using UnityEngine;
using UnityEngine.Events;

public class Diamond : MonoBehaviour {
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private SpriteRenderer spriteRef;
    [SerializeField] private int health = 10;
    [SerializeField] private UnityEvent<PlayerInfo> onDeadCb = new();
    
    private void Start() {
        playerInfo.SetHealth(health);
        spriteRef.color = playerInfo.color;
    }

    public void Damage(int amount) {
        health -= amount;
        if (health < 0) {
            playerInfo.SetHealth(0);
            onDeadCb.Invoke(playerInfo);
            return;
        }
        playerInfo.SetHealth(health);
    }
}
