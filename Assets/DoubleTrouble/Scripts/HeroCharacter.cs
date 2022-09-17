using UnityEngine;
using UnityEngine.InputSystem;

public class HeroCharacter : BaseCharacter {

    [SerializeField] private Diamond enemyDiamond;
    [SerializeField] private float attackRange;
    
    #region Input Handlers


    #endregion

    public void OnAttack(InputAction.CallbackContext ctx) {
        if (CanAttack() == false) return;
        enemyDiamond.Damage(1);
    }
    
    private bool CanAttack() {
        return playerInfo.CurrentAttack > 0 && (enemyDiamond.transform.position - transform.position).magnitude < attackRange;
    }

}
