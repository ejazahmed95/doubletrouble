using EAUnity.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroCharacter : BaseCharacter {

    [SerializeField] private Diamond enemyDiamond;
    [SerializeField] private float attackRange;
    [SerializeField] private AudioClip attackSfx;

    #region Input Handlers


    #endregion

    public void OnAttack(InputAction.CallbackContext ctx) {
        if(ctx.phase != InputActionPhase.Performed) return;
        if (CanAttack() == false) {
            Log.Debug($"{playerInfo.id}: Cannot attack right now");
            return;
        }
        enemyDiamond.Damage(1);
        playerInfo.CurrentAttack -= 1;
        AudioManager.Instance.Play(attackSfx);
    }
    
    private bool CanAttack() {
        return playerInfo.CurrentAttack > 0 && (enemyDiamond.transform.position - transform.position).magnitude < attackRange;
    }

}
