using EAUnity.Core;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {
    public void OnStart() {
        CustomSceneLoader.LoadScene("GameScene");
    }
}