using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector director;
    public AudioSource radioSound;

    private bool hasPlayed = false;

    void Start()
    {
        director.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector pd)
    {
        if (hasPlayed)
            return;

        hasPlayed = true;

        UIManager.Instance.OpenDialogue();
        MissionManager.Instance.ShowObjective("Pergi ke papan kasus.");

        radioSound.Play();
    }
}
