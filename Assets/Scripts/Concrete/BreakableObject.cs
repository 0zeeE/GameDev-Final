using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    [SerializeField] private GameObject objectToBreak;
    public float maxHealth = 20f;
    public float currentHealth;
    [SerializeField] private ParticleSystem breakParticle;
    [SerializeField] private Material particleMaterial;
    [SerializeField] private Mesh mesh;
    public bool useObjectMesh = false;

    // Start is called before the first frame update
    void Start()
    {
        particleMaterial = this.objectToBreak.GetComponent<Renderer>().material;
        this.gameObject.tag = "Breakable";
        currentHealth = maxHealth;
        if(objectToBreak.GetComponent<MeshFilter>() != null)
        {
            mesh = objectToBreak.GetComponent<MeshFilter>().mesh;
        }

       
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
        if(breakParticle != null && mesh != null && useObjectMesh )
        {
            ParticleSystem particle = Instantiate(breakParticle, transform.position,Quaternion.Euler(-90,0,0), null);
            particle.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            particle.GetComponent<ParticleSystemRenderer>().mesh = mesh;

            particle.Play();
        }
        if (breakParticle != null && !useObjectMesh)
        {
            ParticleSystem particle = Instantiate(breakParticle, transform.position, Quaternion.Euler(-90, 0, 0), null);
            particle.GetComponent<ParticleSystemRenderer>().material = particleMaterial;

            particle.Play();
        }

        Destroy(this.gameObject);


    }
}
