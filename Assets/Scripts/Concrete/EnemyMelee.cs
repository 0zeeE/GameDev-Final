using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    // Start is called before the first frame update
    private float damage = 15f;
    [SerializeField] private Collider weaponCollider;
    

    void Start()
    {
        weaponCollider = GetComponent<Collider>();
        weaponCollider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            OpenCollider();
        }
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }
    public void OpenCollider()
    {
        weaponCollider.isTrigger = true;

    }

    public void CloseCollider()
    {

        weaponCollider.isTrigger = false;
        
    }


}
