using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PalletTransporter : MonoBehaviour
{

    Animator palletLoaderAnimator;
    Animator storageShelfAnimator;

    public GameObject palletLoader;
    public GameObject storageShelf;
    public GameObject breakableWall;
    public Player player;
    public KeycardSlot keycardSlot;
    public GameObject subtitleText;
    AudioSource audioSourcePushButton;
    public AudioClip pushButtonSound;
    AudioSource audioSourceDrivePalletLoader;
    public AudioClip DrivePalletLoaderSound;
    AudioSource audioSourceBreakWall;
    public AudioClip BreakWallSound;

    public bool wallBrokeDown;
    public bool transporterAlreadyCrashed;



    void Start()
    {
        transporterAlreadyCrashed = false;
        wallBrokeDown = false;
        palletLoaderAnimator = palletLoader.GetComponent<Animator>();
        storageShelfAnimator = storageShelf.GetComponent<Animator>();
        audioSourcePushButton = GetComponent<AudioSource>();
        audioSourceDrivePalletLoader = palletLoader.GetComponent<AudioSource>();
        audioSourceBreakWall = breakableWall.GetComponent<AudioSource>();
    }

    public void drivePalletTransporter()
    {
        //must change in future to if keycard is inserted
        if(keycardSlot.isKeyCardInserted == false)
        {
            audioSourcePushButton.PlayOneShot(pushButtonSound);
            palletLoaderAnimator.SetTrigger("Push button");
            useSubtitles("Maybe I can find something to activate the keycard slot next to this button.");
        } else if(transporterAlreadyCrashed == false)
        {
            transporterAlreadyCrashed = true;
            palletLoaderAnimator.SetTrigger("Keycard inserted");
            audioSourceDrivePalletLoader.PlayOneShot(DrivePalletLoaderSound);
            StartCoroutine(fallOverShelfTrigger());
        }
    }

    IEnumerator fallOverShelfTrigger()
    {
        Debug.Log("test fallOverShelfTrigger()");
        yield return new WaitForSeconds(3);
        storageShelfAnimator.SetTrigger("Fall over");
        StartCoroutine(breakWall());
    }

    IEnumerator breakWall()
    {
        yield return new WaitForSeconds(2);
        breakableWall.GetComponent<MeshRenderer>().enabled = false;
        breakableWall.GetComponent<BoxCollider>().enabled = false;
        audioSourceBreakWall.PlayOneShot(BreakWallSound);
        useSubtitles("Jezus, the storrage shelf broke the wall.");
        wallBrokeDown = true;
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


