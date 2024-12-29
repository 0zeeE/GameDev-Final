using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicMeshCutter;
public class KizaganKilic : MonoBehaviour
{
    [SerializeField] private Animator swordAnim;
    public float lifeStealAmount = 10f;
    public float swordDamage = 20f;
    private void Start()
    {
        swordAnim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            swordAnim.SetBool("IsSwinging", true);
        }
        else
        {
            swordAnim.SetBool("IsSwinging", false);
        }     
    }

    public void SetIdleState()
    {
        swordAnim.Play("Idle");
    }
}
