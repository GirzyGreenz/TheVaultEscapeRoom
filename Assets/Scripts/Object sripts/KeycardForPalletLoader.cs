using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeycardForPalletLoader : MonoBehaviour
{
    public Player player;
    public Image keycardImage;
    public GameObject subtitleText;
    AudioSource audioSourcePickUpKeyCard;
    public AudioClip PickUpKeyCardSound;


    void Start()
    {
        audioSourcePickUpKeyCard = GetComponent<AudioSource>();
    }

    public void pickUpKeyCard()
    {
        audioSourcePickUpKeyCard.PlayOneShot(PickUpKeyCardSound);
        player.hasKeyCard = true;
        keycardImage.GetComponent<Image>().enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        useSubtitles("This could be usefull.");
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
