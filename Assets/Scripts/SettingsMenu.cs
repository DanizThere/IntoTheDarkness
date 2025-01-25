using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject Sound;
    public GameObject Graphics;
    public GameObject Settings;
    public GameObject Key;
    void Start()
    {
        Sound.SetActive(false);
        Graphics.SetActive(false);
        Key.SetActive(false);
        Settings.SetActive(true);
    }

    public void ToSound()
    {
        Sound.SetActive(true);
    }

    public void ToGraphics()
    {
        Graphics.SetActive(true);
    }

    public void ToKey()
    {
        Key.SetActive(true);
    }

    public void ToSettingsMenu()
    {
        Settings.SetActive(true);
        Sound.SetActive(false);
        Graphics.SetActive(false);
        Key.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ScreenRes(int index)
    {
        switch(index)
        {
            case 0: Screen.SetResolution(800, 600, true); break;
            case 1: Screen.SetResolution(1024, 800, true); break;
            case 2: Screen.SetResolution(1280, 720, true); break;
            case 3: Screen.SetResolution(1440, 1080, true); break;
            case 4: Screen.SetResolution(1920, 1080, true); break;
        }
    }

    public void FullMonitor()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void CloseGraphics()
    {
        Graphics.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
