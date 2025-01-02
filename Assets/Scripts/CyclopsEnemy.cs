using System.Collections;
using UnityEngine;

public class CyclopsEnemy : Enemy
{
    [Header("Boss Specific Properties")]
    public float roarRange = 15f; // Roar i�in oyuncunun menzili
    public float roarCooldown = 10f; // Roar yapabilece�i s�re aral���
    private bool canRoar = true;

    public override void Update()
    {
        base.CheckPlayerState();

        if (!isDead && playerInSightRange && Vector3.Distance(transform.position, player.position) <= roarRange && canRoar)
        {
            Roar();
        }
        else if (!playerInSightRange && !playerInAttackRange)
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

    private void Roar()
    {
        canRoar = false;
        enemyAnim.SetTrigger("Roar");

        Invoke(nameof(ResetRoar), roarCooldown);
    }

    private void ResetRoar()
    {
        canRoar = true;
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
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            int attackType = Random.Range(0, 3); // 0 = Attack1, 1 = Attack2, 2 = PowerAttack

            switch (attackType)
            {
                case 0:
                    enemyAnim.SetTrigger("Attack1");
                    break;
                case 1:
                    enemyAnim.SetTrigger("Attack2");
                    break;
                case 2:
                    enemyAnim.SetTrigger("PowerAttack");
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


