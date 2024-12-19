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
    public GameObject arrowVisual;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootArrow()
    {
        GameObject arrow_prefab = Instantiate(arrow, arrowSpawnPoint);
        arrow_prefab.GetComponent<Rigidbody>().AddForce(Vector3.forward * arrowSpeed, ForceMode.Impulse);

        Destroy(arrow_prefab, 10);
    }

    

    
}
