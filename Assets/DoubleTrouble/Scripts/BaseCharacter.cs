using UnityEngine;


public class BaseCharacter : MonoBehaviour {

    [SerializeField] protected string actionMap;
    
    public string ActionMap => actionMap;
}
