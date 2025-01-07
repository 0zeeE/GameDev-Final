using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 teleportPosition; // I��nlanma hedefi
    public GameObject player;        // Oyuncu
    public TextMeshProUGUI messageText; // UI Text i�in referans
    public string teleportMessage = "1. Kat"; // G�sterilecek mesaj
    public float messageDuration = 10f; // Mesaj�n g�r�nme s�resi (saniye)

    private void OnTriggerEnter(Collider other)
    {
        // Tetikleyiciye giren oyuncu ise
        if (other.gameObject == player)
        {
            // Oyuncuyu ���nla
            player.transform.position = teleportPosition;

            // Mesaj� g�ster
            StartCoroutine(ShowMessage());
        }
    }

    private System.Collections.IEnumerator ShowMessage()
    {
        // Mesaj� ayarla ve g�r�n�r yap
        messageText.text = teleportMessage;
        messageText.gameObject.SetActive(true);

        // Belirli s�re bekle
        yield return new WaitForSeconds(messageDuration);

        // Mesaj� gizle
        messageText.gameObject.SetActive(false);
    }
}
