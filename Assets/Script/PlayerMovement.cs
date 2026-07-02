using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;

        cc.Move(move * speed * Time.deltaTime);
    }
}
