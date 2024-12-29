using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private MergenKut mergenKut;
    [SerializeField] private KizaganKut kizaganKut;
    [SerializeField] private SemrukBurkutKut semrukKut;

    [SerializeField] private PlayerHealth playerHp;
    [SerializeField] private FirstPersonController fpsController;
    void Awake()
    {
        mergenKut = GetComponent<MergenKut>();
        kizaganKut = GetComponent<KizaganKut>();
        semrukKut = GetComponent<SemrukBurkutKut>();
        playerHp = GetComponent<PlayerHealth>();
        fpsController = GetComponent<FirstPersonController>();
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStats()
    {
        if(mergenKut.mergenKutEnabled)
        {
            playerHp.maxHealth = 120f;
            fpsController.walkSpeed = fpsController.walkSpeed * 1.1f;
            fpsController.sprintSpeed = fpsController.sprintSpeed * 1.1f;
            Debug.Log("Mergen Kut secildi.");
        }
        else if(kizaganKut.kizaganKutEnabled)
        {
            playerHp.maxHealth = 180f;
            playerHp.damageReduction = 10f;
            fpsController.walkSpeed = fpsController.walkSpeed * 1.2f;
            fpsController.sprintSpeed = fpsController.sprintSpeed * 1.2f;
            Debug.Log("Kizagan Kut secildi.");

        }
        else if(semrukKut.semrukKutEnabled)
        {
            playerHp.maxHealth = 250f;
            playerHp.damageReduction = 25f;
            fpsController.walkSpeed = fpsController.walkSpeed * 1.5f;
            fpsController.sprintSpeed = fpsController.sprintSpeed * 1.3f;
            fpsController.jumpPower = fpsController.jumpPower * 1.5f;
            Debug.Log("Semruk Burkut secildi.");
        }
        else
        {
            Debug.Log("Kut Secilmedi.");
        }
    }
}
