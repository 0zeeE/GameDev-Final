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

    //kilic ve kalkani yaptiktan sonra buraya gel.

    void Start()
    {
        mergenKut = GetComponent<MergenKut>();
        kizaganKut = GetComponent<KizaganKut>();
        semrukKut = GetComponent<SemrukBurkutKut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeInventory()
    {
        if(mergenKut.mergenKutEnabled)
        {
            //DefaultBow kendisini kapatacak. Mergen yayi acik olacak. Diger kilic ve kalkanlarda da ayni istem yapilacak.
            defaultBow.BowSwitch();
            
        }
    }

    public void SwitchtoBow()
    {
        if (mergenKut.mergenKutEnabled)
        {
            //DefaultBow kendisini kapatacak. Mergen yayi acik olacak. Diger kilic ve kalkanlarda da ayni istem yapilacak.
            mergenBow.BowSwitch();

        }
        else
        {
            defaultBow.BowSwitch();
        }
    }
}
