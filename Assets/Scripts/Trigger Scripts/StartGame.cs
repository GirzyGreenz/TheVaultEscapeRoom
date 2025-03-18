using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject subtitleText;
    public bool alreadyTriggered = false;

    public void OnTriggerEnter()
    {
        if (alreadyTriggered == false)
        {
            subtitleText.GetComponent<TextMeshProUGUI>().text = "Good, I locked myself. Time to take a look what kind of explosive my supplier gave me and pull of a bankheist!";
            subtitleText.GetComponent<TextMeshProUGUI>().enabled = true;
            StartCoroutine(disableSubtitles());
        }
    }

    IEnumerator disableSubtitles()
    {
        yield return new WaitForSeconds(6);
        subtitleText.GetComponent<TextMeshProUGUI>().enabled = false;
        subtitleText.GetComponent<TextMeshProUGUI>().text = "No subtitle...";
    }
}
