using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource moveSound;
    public AudioSource backgroundMusic;

    bool backgroundMute = true;
    void Start()
    {
       // backgroundMusic.mute = backgroundMute;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            backgroundMute = !backgroundMute;
            backgroundMusic.mute = backgroundMute;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
           // moveSound.Play();
            moveSound.loop = true;
        }
        if(!Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A)) 
        {
            moveSound.loop = false;
        }
    }
}
