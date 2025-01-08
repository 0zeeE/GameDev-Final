using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport2 : MonoBehaviour
{
    public string sceneName;
    public GameObject player;        // Oyuncu
    


    private void OnTriggerEnter(Collider other)
    {
        // Tetikleyiciye giren oyuncu ise
        if (other.gameObject == player)
        {
            SceneManager.LoadScene(sceneName);

        }
    }


}
