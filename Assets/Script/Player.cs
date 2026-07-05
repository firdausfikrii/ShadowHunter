using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public CharacterController controller;
    public Transform cameraPivot;
    public Animator animator;

    [Header("Movement")]
    public float speed = 5f;

    [Header("Mouse")]
    public float sensitivity = 2f;

    private float xRotation;

    void Update()
    {
        Look();
        Move();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = transform.forward * v + transform.right * h;

        controller.Move(moveDir.normalized * speed * Time.deltaTime);

        // animasi
        animator.SetBool("isMoving", moveDir.magnitude > 0.1f);
    }
}
