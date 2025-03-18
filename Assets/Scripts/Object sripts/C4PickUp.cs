using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class C4PickUp : MonoBehaviour
{

    public Player player;
    public GameObject placedC4;
    public GameObject pointerArrow;
    public Image c4Sprite;
    public GameObject subtitleText;
    AudioSource audioSourcePickUpC4;
    public AudioClip pickUpC4Sound;

    void Start()
    {
        audioSourcePickUpC4 = GetComponent<AudioSource>();
    }

    public void pickUpC4()
    {
        audioSourcePickUpC4.PlayOneShot(pickUpC4Sound);
        Debug.Log("Picks up C4 enabled");
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        placedC4.GetComponent<BoxCollider>().enabled = true;
        pointerArrow.GetComponent<MeshRenderer>().enabled = true;
        player.hasC4 = true;
        c4Sprite.GetComponent<Image>().enabled = true;
        useSubtitles("I should place this in the closet to acces the vault.");
    }

    public void useSubtitles(string subtitleTextInput)
    {
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
