using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemrukBurkutKut : MonoBehaviour
{
    public bool semrukKutEnabled = false;
    public float regenAmount = 5f;
    public float regenTimePeriod = 1f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if(semrukKutEnabled)
        {
            timer += Time.deltaTime;
            if(timer >= regenTimePeriod)
            {
                GetComponent<PlayerHealth>().AddHealth(regenAmount);
                timer = 0;

            }
        }
    }
}
