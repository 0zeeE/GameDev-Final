using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    private FirstPersonController fpsController;

    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 10;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        fpsController.enabled = false;
        //GameManager Kodu buraya gelecek.
    }
}
