using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySliceRadius : MonoBehaviour
{
    private SphereCollider enemyCol;
    public float radius = 10f;
    private void Start()
    {
        if (enemyCol == null)
        {
            SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
            sc.isTrigger = true;
            enemyCol = sc;
        }
        enemyCol.radius = radius;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Zart");

            GetComponent<Enemy>().isCloseToPlayer = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Enemy>().isCloseToPlayer = false;
        }
    }
}
