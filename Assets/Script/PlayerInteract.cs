using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float distance = 3f;
    public GameObject interactionText;

    void Update()
    {
        Camera cam = Camera.main;

        if (cam == null)
            return;

        Debug.DrawRay(cam.transform.position, cam.transform.forward * 5f, Color.red);

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            Interactable interact = hit.collider.GetComponentInParent<Interactable>();

            if (interact != null)
            {
                interactionText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact.Interact();
                }
            }
            else
            {
                interactionText.SetActive(false);
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }
}
