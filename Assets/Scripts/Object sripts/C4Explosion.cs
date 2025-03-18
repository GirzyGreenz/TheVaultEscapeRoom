using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class C4Explosion : MonoBehaviour
{
    public GameObject pointerArrow;
    public Player player;
    public GameObject breakableFloor;
    public Door doorToClose;
    public Image c4Sprite;
    public GameObject subtitleText;
    AudioSource audioSourcePlaceUpC4;
    public AudioClip placeUpC4Sound;

    public bool isPlaced;
    
    
    void Start()
    {
        isPlaced = false;
        audioSourcePlaceUpC4 = GetComponent<AudioSource>();
    }

    public void placeC4()
    {
        Debug.Log("PlaceC4 activated");

        if (player.hasC4 == true)
        {
            Debug.Log("Player has C4, meshrenderer placed C4 enabled");
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            audioSourcePlaceUpC4.PlayOneShot(placeUpC4Sound);
            pointerArrow.GetComponent<MeshRenderer>().enabled = false;
            isPlaced = true;
            c4Sprite.GetComponent<Image>().enabled = false;
            useSubtitles("Let's activate the bomb.");
        }
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
