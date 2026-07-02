using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactionText;

    public float distance = 3f;

    void Start()
    {
        interactionText.SetActive(true);
    }

    void Update()
    {
        if (UIManager.Instance.IsUIOpen)
            return;
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            Interactable interact = hit.collider.GetComponent<Interactable>();

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
