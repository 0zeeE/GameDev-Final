using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestRanged : RangedEnemy
{
    // Start is called before the first frame update
    public Image healthImage;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        UpdateHealthBar();
    }

    public override void Die()
    {
        if(isDead == false)
        {
            //Destroy(gameObject);
            Debug.Log(gameObject.name + " ded");

            isDead = true;
        }
        
    }

    public void UpdateHealthBar()
    {
        healthImage.fillAmount = GetCurrentHealth() / MaxHealth;
    }
}
