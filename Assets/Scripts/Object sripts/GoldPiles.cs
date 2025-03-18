using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldPiles : MonoBehaviour
{
    public GameObject subtitleText;

    void Start()
    {
        
    }

    public void interactWithGoldBarPile()
    {
        useSubtitles("This is to much to carry. Maybe I should only take the gold bars on the tables.");
    }

    public void useSubtitles(string subtitleTextInput)
    {
        Debug.Log(subtitleTextInput);
        subtitleText.GetComponent<TextMeshProUGUI>().text = subtitleTextInput;
        subtitleText.GetComponent<TextMeshProUGUI>().enabled = true;
        StartCoroutine(disableSubtitles());
    }

    IEnumerator disableSubtitles()
    {
        yield return new WaitForSeconds(4);
        subtitleText.GetComponent<TextMeshProUGUI>().enabled = false;
        subtitleText.GetComponent<TextMeshProUGUI>().text = "No subtitle...";
    }
}
