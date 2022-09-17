using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo", menuName = "Game/GameInfo", order = 0)]
public class GameInfo : ScriptableObject {
    public List<PlayerInfo> players;
    public Sprite controlChangeBg;
    public GenericDictionary<CharacterType, Sprite> characterSprites;
}