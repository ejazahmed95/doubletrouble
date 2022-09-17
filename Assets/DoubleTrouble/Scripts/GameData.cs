using EAUnity.Core;
using UnityEngine;

public class GameData : SingletonBehaviour<GameData> {
    public GameInfo gameInfo;

    public PlayerInfo GetPlayer(int id) => gameInfo.players[id];
}

