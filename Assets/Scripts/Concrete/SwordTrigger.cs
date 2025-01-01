using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    public bool isSwinging = false;
    float damage;
    [SerializeField] private BasicSword sword;
    // Start is called before the first frame update
    void Start()
    {
        damage = sword.swordDamage;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && isSwinging)
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
