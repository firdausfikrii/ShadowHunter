using System.Collections;
using UnityEngine;

public class TelephoneDialogue : MonoBehaviour
{
    [Header("UI")]
    public GameObject instructionPanel;
    public GameObject callImage;
    public GameObject hotspotParent;

    [Header("Audio")]
    public AudioSource voiceAudio;

    public void StartInvestigation()
    {
        // Sembunyikan petunjuk
        instructionPanel.SetActive(false);

        // Pastikan gambar telepon belum muncul
        callImage.SetActive(false);

        // Hotspot belum bisa diklik
        hotspotParent.SetActive(false);

        // Mulai rekaman
        StartCoroutine(PlayRecording());
    }

    IEnumerator PlayRecording()
    {
        voiceAudio.Play();

        // Tunggu sampai voice selesai
        while (voiceAudio.isPlaying)
        {
            yield return null;
        }

        // Setelah voice selesai baru tampilkan gambar
        callImage.SetActive(true);

        // Baru hotspot aktif
        hotspotParent.SetActive(true);
    }
}