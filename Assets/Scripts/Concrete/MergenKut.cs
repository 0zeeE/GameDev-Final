using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergenKut : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera cam;
    public Animator eyeAnimator;
    public LayerMask defaultLayers;
    public LayerMask layersWantToSee;
    [SerializeField] private bool isSkillActive = false;
    public float skillDuration = 4f;
    public float skillCooldown = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Skill();
        }
    }

    public void Skill()
    {
        if (!isSkillActive)
        {
            eyeAnimator.SetBool("Blink", true);
            Invoke(nameof(OpenVision), 0.6f);
        }
        else
        {
            Debug.Log("Yetenek Bekleme süresinde");
        }
    }

    public void OpenVision()
    {
        if(!isSkillActive)
        {
            isSkillActive = true;
            cam.cullingMask = 0;
            cam.cullingMask = layersWantToSee;
            Invoke(nameof(ResetSkill), skillDuration);
        }
       
    }

    public void ResetSkill()
    {
        eyeAnimator.SetBool("Blink", true);
        Invoke(nameof(CloseVision), 0.6f);
        
    }

    public void CloseVision()
    {
        cam.cullingMask = 0;
        cam.cullingMask = defaultLayers;
        Invoke(nameof(ResetCooldown), skillCooldown);
    }

    public void ResetCooldown()
    {
        isSkillActive = false;
        Debug.Log("Mergen Kut Hazir");

    }
}
