using System;
using UnityEngine;


public class BaseCharacter : MonoBehaviour {

    [SerializeField] protected string actionMap;
    [SerializeField] protected SpriteRenderer characterSprite; 
    protected PlayerInfo playerInfo;
    private LineRenderer _lineRenderer;

    public string ActionMap => actionMap;

    private void Awake() {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    public void Init(PlayerInfo pInfo, bool active) {
        playerInfo = pInfo;
        characterSprite.color = playerInfo.color;
        Activate(active);
    }

    public void Activate(bool active) {
        if (_lineRenderer) {
            _lineRenderer.enabled = active;
        }
    }
}
