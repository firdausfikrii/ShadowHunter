using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject panelUI;

    public void Interact()
    {
        Evidence evidence = GetComponent<Evidence>();

        UIManager.Instance.OpenUI(panelUI, evidence);
    }
}