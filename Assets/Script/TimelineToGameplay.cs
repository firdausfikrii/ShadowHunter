using UnityEngine;
using UnityEngine.Playables;

public class TimelineToGameplay : MonoBehaviour
{
    public PlayableDirector timeline;

    public Camera cutsceneCamera;
    public Camera gameplayCamera;

    public MonoBehaviour playerMovement;

    void Start()
    {
        // Matikan gameplay
        playerMovement.enabled = false;

        // Aktifkan kamera cutscene
        cutsceneCamera.gameObject.SetActive(true);
        gameplayCamera.gameObject.SetActive(false);

        // Dengarkan event selesai timeline
        timeline.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Ganti kamera
        cutsceneCamera.gameObject.SetActive(false);
        gameplayCamera.gameObject.SetActive(true);

        // Aktifkan gameplay
        playerMovement.enabled = true;

    }
}