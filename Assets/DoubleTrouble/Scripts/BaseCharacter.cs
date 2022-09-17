using UnityEngine;


public class BaseCharacter : MonoBehaviour {

    [SerializeField] protected string actionMap;
    [SerializeField] protected SpriteRenderer characterSprite;
    
    public string ActionMap => actionMap;
    
    public void SetColor(Color playerColor) {
        characterSprite.color = playerColor;
    }
}
