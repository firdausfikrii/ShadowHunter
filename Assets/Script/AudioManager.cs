using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public AudioSource musicSource;

    [Header("Clips")]
    public AudioClip menuMusic;
    public AudioClip gameplayMusic;
    public AudioClip gameOverMusic;
    public AudioClip victoryMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic, true);
    }

    public void PlayGameplayMusic()
    {
        PlayMusic(gameplayMusic, true);
    }

    public void PlayGameOverMusic()
    {
        PlayMusic(gameOverMusic, false);
    }

    public void PlayVictoryMusic()
    {
        PlayMusic(victoryMusic, false);
    }

    void PlayMusic(AudioClip clip, bool loop)
    {
        if (musicSource.clip == clip && musicSource.isPlaying)
            return;

        musicSource.Stop();

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }
}
