using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ByteWalker : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float gravity = -20f;

    private CharacterController controller;
    private Animator animator;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        bool grounded = controller.isGrounded;

        if (grounded && velocity.y < 0)
            velocity.y = -2f;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * h + transform.forward * v).normalized;

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = move * speed;
        finalMove.y = velocity.y;

        controller.Move(finalMove * Time.deltaTime);

        if (animator != null)
        {
            float animSpeed = move.magnitude;

            if (Input.GetKey(KeyCode.LeftShift))
                animSpeed = 1f;
            else
                animSpeed *= 0.5f;

            animator.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);
        }
    }
}