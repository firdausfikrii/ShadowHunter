using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public CharacterController controller;
    public Transform cam;
    public Animator animator;

    [Header("Movement")]
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h, 0f, v).normalized;

        // kalau tidak ada input → stop animasi & return
        if (input.magnitude < 0.1f)
        {
            animator.SetBool("isMoving", false);
            return;
        }

        // arah relative camera (lebih aman pakai forward/right)
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 moveDir = camForward * input.z + camRight * input.x;

        // gerak player
        controller.Move(moveDir.normalized * speed * Time.deltaTime);

        // rotasi player ke arah jalan
        transform.forward = moveDir.normalized;

        // animasi
        animator.SetBool("isMoving", true);
    }
}
