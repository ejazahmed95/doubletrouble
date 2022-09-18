using EAUnity.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuCharacter : BaseCharacter {
    [SerializeField] private Diamond playerDiamond;
    [SerializeField] private float attackRange;
    [SerializeField] private int attackPoints;
    
    [SerializeField] private Vector2 teleportRangeX;
    [SerializeField] private Vector2 teleportRangeY;

    #region Input Handlers


    #endregion

    public void OnTeleport(InputAction.CallbackContext ctx) {
        if(ctx.performed == false) return;
        if (CanTeleport() == false) {
            Log.Debug($"{playerInfo.id}: cannot teleport right now ");
            return;
        }
        playerInfo.CurrentAttack -= attackPoints;
        var xPos = Random.Range(teleportRangeX.x, teleportRangeX.y);
        var yPos = Random.Range(teleportRangeY.x, teleportRangeY.y);
        playerDiamond.transform.localPosition = new Vector3(xPos, yPos);
    }
    
    private bool CanTeleport() {
        return playerInfo.CurrentAttack >= attackPoints && (playerDiamond.transform.position - transform.position).magnitude < attackRange;
    }
}
