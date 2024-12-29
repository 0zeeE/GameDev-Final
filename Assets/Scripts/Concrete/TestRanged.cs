using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRanged : RangedEnemy
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    

    public override void Die()
    {
        if(isDead == false)
        {
            //Destroy(gameObject);
            Debug.Log(gameObject.name + " ded");

            isDead = true;
        }
        
    }
}
