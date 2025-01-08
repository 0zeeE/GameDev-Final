using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
#else
    
    Application.Quit();
#endif
    }
}
