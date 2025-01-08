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
    public bool isBowActive = true;
    [SerializeField] private SkinnedMeshRenderer bowMesh;
    [SerializeField] private GameObject[] smallParts;

    void Start()
    {
        bowAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isBowActive)
        {
            bowAnimator.SetBool("Aim",true);
        }
        else
        {
            bowAnimator.SetBool("Aim", false);
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            BowSwitch();
        }
    }

    IEnumerator ReloadState()
    {
        foreach (GameObject gm in arrowVisual)
        {
            if(gm.GetComponent<MeshRenderer>() != null)
            {
                gm.GetComponent<MeshRenderer>().enabled = false;

            }
        }

        yield return new WaitForSeconds(0f);

        foreach (GameObject gm in arrowVisual)
        {
            if (gm.GetComponent<MeshRenderer>() != null)
            {
                gm.GetComponent<MeshRenderer>().enabled = true;

            }
        }
    }

    public void ShootArrow()
    {
        if(isBowActive)
        {
            GameObject arrow_prefab = Instantiate(arrow, arrowSpawnPoint);
            arrow_prefab.transform.SetParent(null);
            arrow_prefab.GetComponent<Rigidbody>().AddForce(arrowSpawnPoint.forward * arrowSpeed, ForceMode.Impulse);

            Destroy(arrow_prefab, 10);
        }
        
    }

    public void DisplayArrow()
    {
        StartCoroutine(ReloadState());
    }

    public void BowSwitch()
    {
        isBowActive = !isBowActive;
        bowAnimator.enabled = !bowAnimator.enabled;
        bowAnimator.Play("Idle");
    }

    public void BowSwitch(bool param)
    {
        bowAnimator.Play("Idle");
        isBowActive = param;
        bowAnimator.enabled = param;

        bowMesh.enabled = param;
        foreach (GameObject parts in arrowVisual)
        {
            parts.SetActive(param);
        }
        foreach(GameObject parts in smallParts)
        {
            parts.SetActive(param);
        }




    }




}
