using System.Collections;
using UnityEngine;

public class OutroManager : MonoBehaviour
{
    public static OutroManager Instance;

    [Header("Chief")]
    public Animator chiefAnimator;

    [Header("Chief Audio")]
    public AudioSource chiefAudio;

    public AudioClip outroClip;

    [Header("UI")]
    public GameObject shadowUI;
    public GameObject victoryUI;

    [Header("Player Movement")]
    public MonoBehaviour playerMovement;

    private void Awake()
    {
        Instance = this;
    }

    public void StartOutro()
    {
        StartCoroutine(PlayOutro());
    }

    IEnumerator PlayOutro()
    {
        //-----------------------
        // Logo Shadow Phish
        //-----------------------

        shadowUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        //-----------------------
        // Chief bicara
        //-----------------------

        chiefAnimator.SetBool("IsTalking", true);

        chiefAudio.clip = outroClip;

        chiefAudio.Play();

        yield return new WaitWhile(() => chiefAudio.isPlaying);

        chiefAnimator.SetBool("IsTalking", false);

        //-----------------------
        // Victory
        //-----------------------

        shadowUI.SetActive(false);

        victoryUI.SetActive(true);
        playerMovement.enabled = false;
    }
}
