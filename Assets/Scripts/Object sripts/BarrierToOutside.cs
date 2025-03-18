using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarrierToOutside : MonoBehaviour
{
    public Player player;
    public GameObject barriere;
    public GameObject subtitleText;
    public PalletTransporter palletTransporter;

    public void OnTriggerEnter()
    {
        if (player.moneyCounter >= 10 && player.goldBarCounter >= 10 && palletTransporter.wallBrokeDown == true)
        {
            useSubtitles("Ah yes, freedom!");
            barriere.GetComponent<BoxCollider>().enabled = false;
        } else if (palletTransporter.wallBrokeDown == true)
        {
            useSubtitles("I can't go yet with so little money and gold. Maybe I should grab some more...");
        }       
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
