using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Start is called before the first frame update
    public float arrowSpeed;
    [SerializeField] private Transform arrowSpawnPoint;
    public GameObject arrow;
    private Animator bowAnimator;
    public GameObject[] arrowVisual;

    void Start()
    {
        bowAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            bowAnimator.SetBool("Aim",true);
        }
        else
        {
            bowAnimator.SetBool("Aim", false);
        }
    }

    IEnumerator ReloadState()
    {
        foreach (GameObject gm in arrowVisual)
        {
            gm.GetComponent<MeshRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(0f);

        foreach (GameObject gm in arrowVisual)
        {
            gm.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void ShootArrow()
    {
        GameObject arrow_prefab = Instantiate(arrow, arrowSpawnPoint);
        arrow_prefab.GetComponent<Rigidbody>().AddForce(arrowSpawnPoint.forward * arrowSpeed, ForceMode.Impulse);

        Destroy(arrow_prefab, 10);
    }

    public void DisplayArrow()
    {
        StartCoroutine(ReloadState());
    }

    

    
}
