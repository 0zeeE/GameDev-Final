using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 teleportPosition; // Iþýnlanma hedefi
    public GameObject player;        // Oyuncu
    public TextMeshProUGUI messageText; // UI Text için referans
    public string teleportMessage = "1. Kat"; // Gösterilecek mesaj
    public float messageDuration = 10f; // Mesajýn görünme süresi (saniye)

    private void OnTriggerEnter(Collider other)
    {
        // Tetikleyiciye giren oyuncu ise
        if (other.gameObject == player)
        {
            // Oyuncuyu ýþýnla
            player.transform.position = teleportPosition;

            // Mesajý göster
            StartCoroutine(ShowMessage());
        }
    }

    private System.Collections.IEnumerator ShowMessage()
    {
        // Mesajý ayarla ve görünür yap
        messageText.text = teleportMessage;
        messageText.gameObject.SetActive(true);

        // Belirli süre bekle
        yield return new WaitForSeconds(messageDuration);

        // Mesajý gizle
        messageText.gameObject.SetActive(false);
    }
}
