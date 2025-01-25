using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector3 respawnPoint;
    public TMPro.TMP_Text batter;
    public void StartLoad()
    {
        SceneManager.LoadScene(2);
    }

    public void GameExit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene(1);
    }

    public void Url()
    {
        Application.OpenURL("https://t.me/VBezdnyDevblog");
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        if(SaveManager.instance.hasLoaded)
        {
            respawnPoint = SaveManager.instance.activeSave.respawnPos;
            PlayerMove.instance.transform.position = respawnPoint;
            
        }       
        else
        {
            respawnPoint = PlayerMove.instance.transform.position;
            SaveManager.instance.activeSave.respawnPos = respawnPoint;
        }
    }
}
