using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : MonoBehaviour
{
    [SerializeField] private Animator swordAnim;
    public float swordDamage = 20f;
    [SerializeField] private GameObject swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        swordAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            swordAnim.SetBool("IsSwinging", true);
        }
        else
        {
            swordAnim.SetBool("IsSwinging", false);

        }
    }

    public void OpenTrigger()
    {
        swordCollider.SetActive(true);
    }

    public void CloseTrigger()
    {
        swordCollider.SetActive(false);
    }

   
}
