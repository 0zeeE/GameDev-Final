using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicMeshCutter;
public class KizaganKilic : MonoBehaviour
{
    [SerializeField] private Animator swordAnim;
    public float lifeStealAmount = 10f;
    public float swordDamage = 20f;
    public bool canAttack = true;
    [SerializeField] private MeshRenderer swordMesh;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private GameObject[] particles;
    private void Start()
    {
        swordAnim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canAttack)
        {
            swordAnim.SetBool("IsSwinging", true);
        }
        else
        {
            swordAnim.SetBool("IsSwinging", false);
        }     
    }

    public void CloseSword()
    {
        canAttack = false;
        swordMesh.enabled = false;
        swordAnim.Play("Idle");
        trail.enabled = false;
        foreach (GameObject gm in particles)
        {
            gm.SetActive(false);
        }
        
    }

    public void OpenSword()
    {
        swordMesh.enabled = true;
        canAttack = true;
        trail.enabled = true;
        foreach (GameObject gm in particles)
        {
            gm.SetActive(true);
        }
    }
}
