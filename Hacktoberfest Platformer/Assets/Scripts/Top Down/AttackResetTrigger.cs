using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackResetTrigger : MonoBehaviour
{

    [SerializeField]
    private Animator attackAnimator;
    ///-///////////////////////////////////////////////////////////
    ///
    private void SetAttackAnimation()
    {
        attackAnimator.SetTrigger("Attack");

    }


    ///-///////////////////////////////////////////////////////////
    ///
    public void EndAttackAnimation()
    {
        attackAnimator.SetBool("isAttacking", false);
    }
}
