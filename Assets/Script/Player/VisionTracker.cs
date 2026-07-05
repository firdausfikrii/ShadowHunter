using UnityEngine;

public class VisionTracker : MonoBehaviour
{
    [Header("Player")]
    public Transform playerBody;

    [Header("Camera")]
    public float sensitivity = 180f;

    private float xRotation;
    private bool canLook = true;

    private void Start()
    {
        LockMouse();
    }

    private void LateUpdate()
    {
        if (!canLook)
            return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // ============================
    // LOCK MOUSE (Saat Bermain)
    // ============================
    public void LockMouse()
    {
        canLook = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ============================
    // UNLOCK MOUSE (Saat Pause)
    // ============================
    public void UnlockMouse()
    {
        canLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}