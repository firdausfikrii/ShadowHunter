using UnityEngine;

public class Evidence : MonoBehaviour
{
    private bool collected = false;

    public void Collect()
    {
        if (collected)
            return;

        collected = true;

        MissionManager.Instance.AddEvidence();

        Debug.Log("Bukti tersimpan");
    }
}