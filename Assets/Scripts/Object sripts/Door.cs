using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    public AudioClip doorLocked;
    public AudioClip doorOpening;
    public AudioClip doorClosing;
    
    public bool isDoorAccesable;
    public bool isDoorAllreadyOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isDoorAllreadyOpen = false;
    }

    public void doorAcces()
    {
        if (isDoorAccesable)
        {
            if (isDoorAllreadyOpen)
            {
                animator.SetTrigger("Door closed");
                audioSource.PlayOneShot(doorClosing);
                isDoorAllreadyOpen = false;                          
            } 
            else
            {
                animator.SetTrigger("Door open");
                audioSource.PlayOneShot(doorOpening);
                isDoorAllreadyOpen = true;
            }
        } 
        else
        {
            animator.SetTrigger("Door handle");
            audioSource.PlayOneShot(doorLocked);
        }
    }
}
