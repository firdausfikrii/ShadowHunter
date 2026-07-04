using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        // arah camera
        dir = cam.TransformDirection(dir);
        dir.y = 0;

        controller.Move(dir * speed * Time.deltaTime);
    }
}
