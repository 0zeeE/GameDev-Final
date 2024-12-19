using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : MonoBehaviour
{
    public float MaxHealth = 100;
    [SerializeField] private float currentHealth;
    public bool isDead = false;
    public float moveSpeed = 10f;
    public Animator enemyAnim;
    public Transform player;

    //Enemy Navigation
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol
    public Vector3 walkPoint;
    public bool walkPointset;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool isEnemyMustStay = false; //Enemy sabit mi durmali ?
    public bool isEnemyCanChase = true;
    public virtual void Start()
    {
        SetStartVariables();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CheckPlayerState();
    }

    public virtual void SetStartVariables()
    {
        if(GetComponent<Animator>() != null)
        {
            enemyAnim = GetComponent<Animator>();
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        currentHealth = MaxHealth;
    }

    public void CheckPlayerState()
    {
        if (!isDead)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange && !isEnemyMustStay)
            {
                Patrol();
            }
            if (playerInSightRange && !playerInAttackRange && isEnemyCanChase)
            {
                ChasePlayer();
            }
            if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer();
            }
        }
    }

    public virtual void Patrol()
    {
        if (!walkPointset)
        {
            SearchWalkPoint();
        }
        if (walkPointset)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointset = false;
        }
    }

    private void SearchWalkPoint()
    {
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);
        float RandomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointset = true;
        }

    }

    public virtual void ChasePlayer()
    {
        agent.SetDestination(player.position);
        

    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    //Bu metot her bir enemy tipi icin tamamlanmasi gerekmekte. Melee ve Ranged Karakterler vardýr cunku.
    public abstract void AttackPlayer();

    public abstract void Die();


}
