using UnityEngine;

public class NPCVoiceController : MonoBehaviour
{
    public AudioSource voice;
    public Animator animator;

    private bool IsTalking;

    void Update()
    {
        if (voice.isPlaying)
        {
            if (!IsTalking)
            {
                animator.SetBool("IsTalking", true);
                IsTalking = true;
            }
        }
        else
        {
            if (IsTalking)
            {
                animator.SetBool("IsTalking", false);
                IsTalking = false;
            }
        }
    }
}