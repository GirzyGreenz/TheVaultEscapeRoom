using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VaultDoor : MonoBehaviour
{
    public GameObject subtitleText;

    public void interactWithVaultDoor()
    {
        subtitleText.GetComponent<TextMeshProUGUI>().text = "This door is sealed tight. I seams no one heard the explosion. But how do I get out?";
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
