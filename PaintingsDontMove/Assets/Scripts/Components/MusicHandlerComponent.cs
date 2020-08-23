using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandlerComponent : MonoBehaviour
{

    public AudioSource mainSong;
    public AudioSource mainFlute;

    private float volume = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(timeManipulation.ZAWARUDO)
        {
            mainSong.volume = 0;
            mainFlute.volume = volume * 1.8f;
        }
        else
        {
            mainSong.volume = volume;
            mainFlute.volume = 0;
        }
    }
}
