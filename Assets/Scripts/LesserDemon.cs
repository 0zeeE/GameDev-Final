using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserDemon : MeleeEnemy
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
            AttackPlayer(); // Oyuncuya saldýr
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
        Debug.Log("Attack baþladý!");
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
                    gameObject.GetComponent<Enemy>().agent.speed = 0f;
                    break;
                case 1:
                    enemyAnim.SetTrigger("Attack2");
                    gameObject.GetComponent<Enemy>().agent.speed = 0f;
                    break;
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void SetIsAttacking()
    {
        gameObject.GetComponent<Enemy>().agent.speed = 3.5f; // Karakterin dönmesi gereken hýz
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
            Destroy(gameObject, 5f); // Ölümden sonra 5 saniye sonra yok et
        }
    }
}
