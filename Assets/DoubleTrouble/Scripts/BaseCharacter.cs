using UnityEngine;


public class BaseCharacter : MonoBehaviour {

    [SerializeField] protected string actionMap;
    [SerializeField] protected SpriteRenderer characterSprite; 
    protected PlayerInfo playerInfo;
    
    public string ActionMap => actionMap;
    
    public void SetPlayerInfo(PlayerInfo pInfo) {
        playerInfo = pInfo;
        characterSprite.color = playerInfo.color;
    }
    
}
