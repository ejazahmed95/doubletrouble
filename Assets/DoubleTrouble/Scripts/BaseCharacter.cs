using System;
using UnityEngine;


public class BaseCharacter : MonoBehaviour {

    [SerializeField] protected string actionMap;
    [SerializeField] protected SpriteRenderer characterSprite; 
    protected PlayerInfo playerInfo;
    private LineRenderer _lineRenderer;

    public string ActionMap => actionMap;

    private void Start() {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    public void SetPlayerInfo(PlayerInfo pInfo) {
        playerInfo = pInfo;
        characterSprite.color = playerInfo.color;
    }

    public void Activate(bool active) {
        if (_lineRenderer) {
            _lineRenderer.enabled = active;
        }
    }
}
