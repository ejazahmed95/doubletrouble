using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Game/PlayerInfo", order = 0)]
public class PlayerInfo : ScriptableObject {
    public string id;
    public string pName;
    public Color color;
}