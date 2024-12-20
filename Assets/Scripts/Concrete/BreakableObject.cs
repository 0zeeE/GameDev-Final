using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    [SerializeField] private GameObject wall;
    public float maxHealth = 20f;
    public float currentHealth;
    [SerializeField] private ParticleSystem breakParticle;
    public Material particleMaterial;

    // Start is called before the first frame update
    void Start()
    {
        particleMaterial = this.gameObject.GetComponent<Renderer>().material;
        this.gameObject.tag = "Breakable";
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth -= 20;

        if(currentHealth <= 0)
        {
            Break();
        }
    }

    void Break()
    {
        if(breakParticle != null)
        {
            ParticleSystem particle = Instantiate(breakParticle, transform.position,Quaternion.Euler(-90,0,0), null);
            particle.GetComponent<ParticleSystemRenderer>().material = particleMaterial;

            particle.Play();
        }
        Destroy(this.gameObject);


    }
}
