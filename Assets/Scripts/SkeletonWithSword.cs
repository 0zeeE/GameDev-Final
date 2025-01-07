using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWithSword : MeleeEnemy
{
    public override void Update()
    {
        base.CheckPlayerState();

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrol(); // Devriye fonksiyonu
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer(); // Oyuncuyu kovala
        }
        else if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer(); // Oyuncuya sald�r
        }
    }


    public override void Patrol()
    {
        base.Patrol();
        enemyAnim.SetBool("isWalking", true);
        Debug.Log("Patrol animasyonu tetiklendi mi? " + enemyAnim.GetBool("isWalking"));
    }

    public override void ChasePlayer()
    {
        base.ChasePlayer();
        enemyAnim.SetBool("isWalking", false);
        enemyAnim.SetBool("isRunning", true);
        Debug.Log("Chase animasyonu tetiklendi mi? " + enemyAnim.GetBool("isRunning"));
    }

    public override void AttackPlayer()
    {
        Debug.Log("Attack ba�lad�!");
        agent.SetDestination(transform.position);


        if (!alreadyAttacked)
        {
            transform.LookAt(player);
            enemyWeapon.GetComponent<EnemyMelee>().OpenCollider();
            int attackType = Random.Range(0, 2); // 0 = Attack1, 1 = Attack2, 2 = PowerAttack

            switch (attackType)
            {
                case 0:
                    enemyAnim.SetTrigger("Attack1");
                    break;
                case 1:
                    enemyAnim.SetTrigger("Attack2");
                    break;
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (!isDead)
        {
            enemyAnim.SetTrigger("Hit");
        }
    }

    public override void Die()
    {
        if (!isDead)
        {
            isDead = true;
            enemyAnim.SetTrigger("Death");
            agent.enabled = false;
            Destroy(gameObject, 5f); // �l�mden sonra 5 saniye sonra yok et
        }
    }
}
