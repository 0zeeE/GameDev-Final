using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private MergenKut mergenKut;
    [SerializeField] private KizaganKut kizaganKut;
    [SerializeField] private SemrukBurkutKut semrukKut;
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

    }
}
