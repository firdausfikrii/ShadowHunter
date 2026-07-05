using UnityEngine;

public class SmartphoneUI : MonoBehaviour
{
    public GameObject chatListImage;
    public GameObject chatContentImage;

    void Start()
    {
        chatListImage.SetActive(true);
        chatContentImage.SetActive(false);
    }

    public void OpenScamChat()
    {
        Debug.Log("OPEN SCAM CHAT");

        chatListImage.SetActive(false);
        chatContentImage.SetActive(true);
    }

    public void BackToList()
    {
        chatContentImage.SetActive(false);
        chatListImage.SetActive(true);
    }
}