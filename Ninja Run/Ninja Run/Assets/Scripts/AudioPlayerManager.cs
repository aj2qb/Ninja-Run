using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    public GameObject ninja; 

    void Update()
    {
        if(ninja.GetComponent<NinjaController>().gameOver)
        {
            this.GetComponent<AudioSource>().enabled = false; 
        }
    }
}
