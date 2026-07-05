using UnityEngine;

public class ReportCard : MonoBehaviour
{
    public ReportManager reportManager;

    [TextArea]
    public string evidenceText;

    public void SelectEvidence()
    {
        reportManager.AddEvidence(evidenceText);

        gameObject.SetActive(false);
    }
}