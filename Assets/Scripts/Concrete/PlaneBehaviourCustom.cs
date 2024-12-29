using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicMeshCutter;
public class PlaneBehaviourCustom : CutterBehaviour
{
    public float DebugPlaneLength = 2;

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
                root.GetComponent<Enemy>().Die();
                var targets = root.GetComponentsInChildren<MeshTarget>();
                foreach (var target in targets)
                {
                    Cut(target, transform.position, transform.forward, null, OnCreated);
                }
            }
            
        }
    }

    void OnCreated(Info info, MeshCreationData cData)
    {
        MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
    }
}
