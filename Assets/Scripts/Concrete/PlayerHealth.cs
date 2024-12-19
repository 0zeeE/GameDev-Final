using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
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
}
