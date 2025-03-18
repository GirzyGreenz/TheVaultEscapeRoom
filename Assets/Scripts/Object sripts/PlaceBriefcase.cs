using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBriefcase : MonoBehaviour
{
    public GameObject briefcaseTop;
    public GameObject briefcaseBottom;
    public GameObject simpleC4;
    public GameObject arrowBriefcase;
    public GameObject c4Button;
    public GameObject c4ButtonBlock;
    public GameObject c4ButtonCollection;
    AudioSource audioSourceplaceBrief;
    public AudioClip placeBriefCaseSound;

    void Start()
    {
        audioSourceplaceBrief = GetComponent<AudioSource>();
    }

    public void placeBriefCaseDown()
    {
        audioSourceplaceBrief.PlayOneShot(placeBriefCaseSound);
        briefcaseTop.GetComponent<MeshRenderer>().enabled = true;
        briefcaseBottom.GetComponent<MeshRenderer>().enabled = true;
        simpleC4.GetComponent<MeshRenderer>().enabled = true;
        arrowBriefcase.GetComponent<MeshRenderer>().enabled = false;
        c4Button.GetComponent<MeshRenderer>().enabled = true;
        c4ButtonBlock.GetComponent<MeshRenderer>().enabled = true;

        simpleC4.GetComponent<BoxCollider>().enabled = true;
        c4ButtonCollection.GetComponent<BoxCollider>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;
    }


}
