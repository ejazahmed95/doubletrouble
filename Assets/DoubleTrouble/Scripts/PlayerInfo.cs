using System;
using DoubleTrouble.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Game/PlayerInfo", order = 0)]
public class PlayerInfo : ObservableSO {
    public string id;
    public string pName;
    public Color color;
    [SerializeField] private int health;
    [SerializeField] private int maxAttack;
    [SerializeField] private int currentAttack;
    [SerializeField] private CharacterType activeCharacter;
    
    public CharacterType ActiveCharacter {
        get => activeCharacter;
        set {
            activeCharacter = value;
            Notify();
        }
    }

    public int CurrentAttack {
        get => currentAttack;
        set {
            currentAttack = value;
            Notify();
        }
    }

    public int Health {
        get => health;
        set {
            health = value;
            Notify();
        }
    }

    public void SetHealth(int i) {
        health = i;
        Notify();
    }
}