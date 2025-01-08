using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CyclopsEnemy : Enemy
{
    [Header("Boss Specific Properties")]
    public float roarRange = 15f; // Roar için oyuncunun menzili
    public float roarCooldown = 10f; // Roar yapabileceði süre aralýðý
    private bool canRoar = true;
    public Image healthImage;
    public override void Update()
    {
        base.CheckPlayerState();

        if (!isDead && playerInSightRange && Vector3.Distance(transform.position, player.position) <= roarRange && canRoar)
        {
            Roar();
        }
        else if (!isDead && !playerInSightRange && !playerInAttackRange)
        {
            Patrol(); // Devriye fonksiyonu
        }
        else if (!isDead && playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer(); // Oyuncuyu kovala
        }
        else if (!isDead && playerInSightRange && playerInAttackRange)
        {
            AttackPlayer(); // Oyuncuya saldýr
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
        Debug.Log("Attack baþladý!");
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
            UpdateHealthBar();
        }
    }

    public override void Die()
    {
        if (!isDead)
        {
            agent.enabled = false;
            isDead = true;
            enemyAnim.SetTrigger("Death");
            Invoke(nameof(nextLevel), 5f);
            Destroy(gameObject, 5f); // Ölümden sonra 5 saniye sonra yok et
        }
    }

    public void UpdateHealthBar()
    {
        healthImage.fillAmount = GetCurrentHealth() / MaxHealth;
    }

    private void nextLevel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().lockCursor = false;

        SceneManager.LoadScene("Cutscene3");
    }
}


