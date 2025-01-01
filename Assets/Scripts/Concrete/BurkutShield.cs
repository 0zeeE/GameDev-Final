using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurkutShield : MonoBehaviour
{
    private Animator shieldAnim;
    [SerializeField] private Hovl_DemoLasers lazer;
    [SerializeField] private Animator moonShield;
    void Start()
    {
        lazer = GetComponent<Hovl_DemoLasers>();
        shieldAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            SwitchType();   
        }
    }

    public void SwitchType()
    {
        lazer.sunMode = !lazer.sunMode;
        shieldAnim.SetBool("Switch", !shieldAnim.GetBool("Switch"));
        moonShield.SetBool("Open", !moonShield.GetBool("Open"));
    }
}
