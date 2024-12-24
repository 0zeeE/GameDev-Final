using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMelee : MeleeEnemy
{
    


    public override void Die()
    {
        Destroy(this.gameObject);
    }
}
