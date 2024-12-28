using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicMeshCutter;

[RequireComponent(typeof(LineRenderer))]

public class MouseBehaviourCustom : MouseBehaviour
{
    public LineRenderer LR => GetComponent<LineRenderer>();
    private Vector3 _from;
    private Vector3 _to;
    private bool _isDragging;
    //public EnemyAI enemy;
    public bool isKatanaSelected = false;


    [SerializeField] private GameObject katana;

    protected override void Update()
    {
        base.Update();
        if (isKatanaSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;

                var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 0.05f);
                _from = Camera.main.ScreenToWorldPoint(mousePos);
            }

            if (_isDragging)
            {
                var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 0.05f);
                _to = Camera.main.ScreenToWorldPoint(mousePos);
                VisualizeLine(true);
            }
            else
            {
                VisualizeLine(false);
            }

            if (Input.GetMouseButtonUp(0) && _isDragging)
            {
                Cut();
                _isDragging = false;
            }
        }

    }

    private void Cut()
    {
        Plane plane = new Plane(_from, _to, Camera.main.transform.position);
        katana.GetComponent<Animator>().SetBool("IsSwinging", true);
        var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var root in roots)
        {


            if (!root.activeInHierarchy)
                continue;
            if (root.GetComponent<Enemy>() != null && root.GetComponent<Enemy>().isCloseToPlayer)
            {
                root.GetComponent<Enemy>().Die();

                var targets = root.GetComponentsInChildren<MeshTarget>();
                foreach (var target in targets)
                {

                    Cut(target, _to, plane.normal, null, OnCreated);
                }
            }

        }
    }

    void OnCreated(Info info, MeshCreationData cData)
    {
        MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
    }
    private void VisualizeLine(bool value)
    {
        if (LR == null)
            return;

        LR.enabled = value;

        if (value)
        {
            LR.positionCount = 2;
            LR.SetPosition(0, _from);
            LR.SetPosition(1, _to);
        }
    }
}
