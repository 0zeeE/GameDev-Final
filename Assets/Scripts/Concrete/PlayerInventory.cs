using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private MergenKut mergenKut;
    [SerializeField] private KizaganKut kizaganKut;
    [SerializeField] private SemrukBurkutKut semrukKut;

    [SerializeField] private Bow defaultBow;
    [SerializeField] private Bow mergenBow;
    [SerializeField] private GameObject basicSword;
    [SerializeField] private GameObject kizaganKilic;
    [SerializeField] private GameObject burkutKalkan;

    //kilic ve kalkani yaptiktan sonra buraya gel.

    private void Awake()
    {
        mergenKut = GetComponent<MergenKut>();
        kizaganKut = GetComponent<KizaganKut>();
        semrukKut = GetComponent<SemrukBurkutKut>();
    }
    void Start()
    {
        InitialiseInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchPrimary();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchSecondary();
        }
    }



    public void SwitchPrimary()
    {
        if (semrukKut.semrukKutEnabled == false)
        {
            if(kizaganKut.kizaganKutEnabled)
            {
                defaultBow.BowSwitch(false);
                
                kizaganKilic.GetComponent<KizaganKilic>().OpenSword();

            }
            else if(mergenKut.mergenKutEnabled)
            {
                mergenBow.BowSwitch(false);
                basicSword.GetComponent<BasicSword>().OpenSword();

            }
            else
            {
                defaultBow.BowSwitch(false);
            
                basicSword.GetComponent<BasicSword>().OpenSword();

            }
        }

    }

    public void SwitchSecondary()
    {
        if (semrukKut.semrukKutEnabled == false)
        {
            if (kizaganKut.kizaganKutEnabled)
            {
                defaultBow.BowSwitch(true);
                
                kizaganKilic.GetComponent<KizaganKilic>().CloseSword();

            }
            else if (mergenKut.mergenKutEnabled)
            {
                mergenBow.BowSwitch(true);
                basicSword.GetComponent<BasicSword>().CloseSword();
            }
            else
            {
                defaultBow.BowSwitch(true);
                basicSword.GetComponent<BasicSword>().CloseSword();

            }
        }
    }

    public void InitialiseInventory()
    {
        if(semrukKut.semrukKutEnabled)
        {
            burkutKalkan.SetActive(true);

            basicSword.GetComponent<BasicSword>().CloseSword();
            kizaganKilic.GetComponent<KizaganKilic>().CloseSword();
            defaultBow.BowSwitch(false);
            mergenBow.BowSwitch(false);


        }
        else if(mergenKut.mergenKutEnabled)
        {
            burkutKalkan.SetActive(false);
            defaultBow.BowSwitch(false);

            mergenBow.BowSwitch(true);

            basicSword.GetComponent<BasicSword>().CloseSword();
            kizaganKilic.GetComponent<KizaganKilic>().CloseSword();
        }
        else if(kizaganKut.kizaganKutEnabled)
        {
            burkutKalkan.SetActive(false);

            mergenBow.BowSwitch(false);
            defaultBow.BowSwitch(false);

            basicSword.GetComponent<BasicSword>().CloseSword();
            kizaganKilic.GetComponent<KizaganKilic>().OpenSword();
        }
        else
        {
            burkutKalkan.SetActive(false);

            mergenBow.BowSwitch(false);
            defaultBow.BowSwitch(true);

            basicSword.GetComponent<BasicSword>().CloseSword();
            kizaganKilic.GetComponent<KizaganKilic>().CloseSword();
        }
    }
}
