using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicMeshCutter;
public class PlaneBehaviourCustom : CutterBehaviour
{
    public float DebugPlaneLength = 2;
    [SerializeField] private KizaganKilic kilic;

    [ContextMenu("Rammus")]
    public void Cut()
    {
        var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var root in roots)
        {
            if (!root.activeInHierarchy)
                continue;
            if(root.GetComponent<Enemy>() != null && root.GetComponent<Enemy>().isCloseToPlayer)
            {
                if(root.GetComponent<Enemy>().canSliceEnemy)
                {
                    root.GetComponent<Enemy>().Die();
                    var targets = root.GetComponentsInChildren<MeshTarget>();
                    foreach (var target in targets)
                    {
                        Cut(target, transform.position, transform.forward, null, OnCreated);
                    }
                }
                else
                {
                    root.GetComponent<Enemy>().TakeDamage(kilic.swordDamage);
                }
                
            }
            
        }
    }

    void OnCreated(Info info, MeshCreationData cData)
    {
        MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
    }
}
