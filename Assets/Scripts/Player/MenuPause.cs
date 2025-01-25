using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseCanvas;
    bool onPause = false;
    public AudioSource Sound;
    public int level;
    public void toMenu()
    {
        SceneManager.LoadScene(0);
        Sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            onPause = !onPause;
            pauseCanvas.SetActive(onPause);
            Time.timeScale = 0f;
            Sound.volume = 0.2f;
        }
        if(!onPause) 
        { 
            Time.timeScale = 1f;
            Sound.volume = 1f;
        }
    }

    public void pauseOff()
    {
            onPause = !onPause;
            pauseCanvas.SetActive(onPause);
    }
    public void Restart()
    {
        SceneManager.LoadScene(level);
    }
}
