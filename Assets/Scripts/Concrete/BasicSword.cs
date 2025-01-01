using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : MonoBehaviour
{
    [SerializeField] private Animator swordAnim;
    public float swordDamage = 20f;
    [SerializeField] private SwordTrigger swordTrig;
    // Start is called before the first frame update
    void Start()
    {
        swordAnim = GetComponentInChildren<Animator>();
        swordTrig = GetComponentInChildren<SwordTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            swordAnim.SetBool("IsSwinging", true);
            swordTrig.isSwinging = true;
        }
        else
        {
            swordAnim.SetBool("IsSwinging", false);
            swordTrig.isSwinging = false;

        }
    }

   
}
