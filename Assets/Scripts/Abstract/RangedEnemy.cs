using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedEnemy : Enemy
{
    public Transform weaponAttackPoint;
    public AudioSource shootSound;
    public GameObject projectile;
    public float projectileSpeed = 32f;
    public float inaccuracyAmount = 0.1f;
    public override void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        weaponAttackPoint.LookAt(player);
        

        if (!alreadyAttacked)
        {
            //Attack code here
            if(shootSound != null)
            {
                shootSound.Play();

            }

            Vector3 randomTransform = new Vector3(Random.Range(-inaccuracyAmount, inaccuracyAmount), Random.Range(-inaccuracyAmount, inaccuracyAmount), Random.Range(-inaccuracyAmount, inaccuracyAmount));
            Rigidbody rb = Instantiate(projectile, weaponAttackPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce((weaponAttackPoint.transform.forward + randomTransform) * projectileSpeed, ForceMode.Impulse);
            rb.AddForce(weaponAttackPoint.transform.up * 1f, ForceMode.Impulse);

            Destroy(rb.gameObject, 3);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }


   

    
}
