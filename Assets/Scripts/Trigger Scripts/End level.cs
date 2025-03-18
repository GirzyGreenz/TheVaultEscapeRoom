using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endlevel : MonoBehaviour
{
    public void OnTriggerEnter()
    {
        SceneManager.LoadScene("Finish", LoadSceneMode.Single);
    }
}
