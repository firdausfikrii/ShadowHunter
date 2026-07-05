using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

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
    public GameObject thankYouUI;

    [Header("Player Movement")]
    public MonoBehaviour playerMovement;

    [Header("Gameplay UI")]
    public GameObject gameplayCanvas;

    [Header("Cutscene")]
    public GameObject outroCamera;

    public CanvasGroup shadowCanvas;
    public RectTransform shadowTransform;

    public PlayableDirector outroTimeline;

    private void Awake()
    {
        Instance = this;
    }

    void HideGameplayUI()
    {
        gameplayCanvas.SetActive(false);
    }

    public void StartOutro()
    {
        StartCoroutine(PlayOutro());
    }

    IEnumerator PlayOutro()
    {
        HideGameplayUI();
        //-----------------------
        // Logo Shadow Phish
        //-----------------------

        shadowUI.SetActive(true);

        shadowCanvas.alpha = 0;
        shadowTransform.localScale = Vector3.one * 0.5f;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * 2f;

            shadowCanvas.alpha = t;
            shadowTransform.localScale = Vector3.Lerp(Vector3.one * 0.5f, Vector3.one, t);

            yield return null;
        }

        yield return new WaitForSeconds(1f);

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

        outroCamera.SetActive(true);
        outroTimeline.Play();

        yield return new WaitForSeconds((float)outroTimeline.duration);

        victoryUI.SetActive(true);
        yield return new WaitForSeconds(4f);
        victoryUI.SetActive(false);

        ShowThankYou();
    }

    void ShowThankYou()
    {
        thankYouUI.SetActive(true);

        playerMovement.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
