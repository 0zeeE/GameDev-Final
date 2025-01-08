using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    public string[] characterDescriptions; // Karakter bilgileri
    public TMP_Text characterInfoText; // UI Text bileþeni
    public int selectedCharacter = 0;

    private void Start()
    {
        UpdateCharacterInfo();
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        UpdateCharacterInfo();
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
        UpdateCharacterInfo();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        //SceneManager.LoadScene("First Scene");
        if(selectedCharacter == 0)
        {
            SceneManager.LoadScene("Kat 7-8 Mergen");
        }
        if(selectedCharacter == 1)
        {
            SceneManager.LoadScene("Kat 7-8 Kizagan");
        }
        if(selectedCharacter == 2)
        {
            SceneManager.LoadScene("Kat 7-8 Semruk");
        }
        
    }

    private void UpdateCharacterInfo()
    {
        if (characterInfoText != null && characterDescriptions.Length > selectedCharacter)
        {
            characterInfoText.text = characterDescriptions[selectedCharacter];
        }
    }
}
