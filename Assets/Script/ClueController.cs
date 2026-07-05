using UnityEngine;

public class ClueController : MonoBehaviour
{
    [TextArea]
    public string clueDescription;

    public Evidence evidence;

    public void ShowNotebook()
    {
        UIManager.Instance.HideCurrentUI();

        NotebookManager.Instance.ShowNotebook(clueDescription, evidence);
    }
}
