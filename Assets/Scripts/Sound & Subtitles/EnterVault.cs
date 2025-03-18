using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Entervault : MonoBehaviour
{
    public GameObject subtitleText;

    public void OnTriggerEnter()
    {
        StartCoroutine(waitForTrigger());
    }

    IEnumerator waitForTrigger()
    {
        yield return new WaitForSeconds(4);
        subtitleText.GetComponent<TextMeshProUGUI>().text = "Now I'm in the vault, I should pick up some loot.";
        subtitleText.GetComponent<TextMeshProUGUI>().enabled = true;
        StartCoroutine(disableSubtitles());
    }

    IEnumerator disableSubtitles()
    {
        yield return new WaitForSeconds(6);
        subtitleText.GetComponent<TextMeshProUGUI>().enabled = false;
        subtitleText.GetComponent<TextMeshProUGUI>().text = "No subtitle...";
    }
}
