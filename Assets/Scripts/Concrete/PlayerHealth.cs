using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField] private float currentHealth;
    public float damageReduction = 0f; //yuzdelik olarak dusun
    private FirstPersonController fpsController;
    private Rigidbody rb;
    public bool isDead = false;

    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    Die();
        //}
    }

    public void TakeDamage(float damage)
    {
        float reducedDamage = 0;

        if(damageReduction > 0)
        {
            reducedDamage = damage * (1 - (1 / damageReduction));

        }
        else
        {
            reducedDamage = damage;
        }

        currentHealth -= reducedDamage;
        
        if(currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 10;

        if(currentHealth <= 0)
        {
            isDead = true;

            Die();
        }
    }

    public void Die()
    {
        fpsController.enabled = false;
        rb.constraints = RigidbodyConstraints.None;
        //GameManager Kodu buraya gelecek.
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
