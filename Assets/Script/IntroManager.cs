using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class IntroManager : MonoBehaviour
{
    [Header("Timeline")]
    public PlayableDirector timeline;

    [Header("Audio")]
    public AudioSource radioAudio;
    public AudioSource chiefAudio;

    [Header("Chief")]
    public Animator chiefAnimator;

    [Header("Gameplay")]
    public Camera cutsceneCamera;
    public Camera gameplayCamera;

    [Header("Gameplay UI")]
    public GameObject gameplayUI;

    [Header("Player Movement")]
    public MonoBehaviour playerMovement;

    void Start()
    {
        AudioManager.Instance.PlayGameplayMusic();
        
        playerMovement.enabled = false;

        gameplayCamera.gameObject.SetActive(false);

        gameplayUI.SetActive(false); // UI gameplay disembunyikan

        timeline.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector pd)
    {
        StartCoroutine(PlayRadioThenChief());
    }

    IEnumerator PlayRadioThenChief()
    {
        if (radioAudio != null)
        {
            radioAudio.Play();
            yield return new WaitWhile(() => radioAudio.isPlaying);
        }

        // Chief mulai bicara
        chiefAnimator.SetBool("IsTalking", true);
        chiefAudio.Play();

        // Tunggu chief selesai bicara
        yield return new WaitWhile(() => chiefAudio.isPlaying);

        // Chief diam
        chiefAnimator.SetBool("IsTalking", false);

        // Pindah kamera
        cutsceneCamera.gameObject.SetActive(false);
        gameplayCamera.gameObject.SetActive(true);

        // Aktifkan gameplay
        playerMovement.enabled = true;

        // Tampilkan UI Gameplay
        gameplayUI.SetActive(true);
    }
}
