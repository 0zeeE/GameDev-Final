using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
    // Start is called before the first frame update
    public EnemyMelee meleeWeapon;

    public float enemyDamage = 20f;

    public override void Start()
    {
        base.Start();
        meleeWeapon = GetComponentInChildren<EnemyMelee>();
        meleeWeapon.SetDamage(enemyDamage);
    }


    public override void ChasePlayer()
    {
        base.ChasePlayer();
    }

    public override void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        

        if(!alreadyAttacked)
        {
            //Melee animation ekle. ve Melee scriptine bak. Bunun gibi.
            //enemyAnim.SetBool("Attack", true);
            meleeWeapon.OpenCollider();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        

    }

    public override void ResetAttack()
    {
        base.ResetAttack();
        meleeWeapon.CloseCollider();
    }


}
