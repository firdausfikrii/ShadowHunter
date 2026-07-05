using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject panelUI;

    [Header("Interaction")]
    public bool canInteract = true;

    public void Interact()
    {
        if (!canInteract)
            return;

        Evidence evidence = GetComponent<Evidence>();

        UIManager.Instance.OpenUI(panelUI, evidence);
    }
}