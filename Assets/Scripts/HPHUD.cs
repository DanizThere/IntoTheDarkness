using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class HPHUD : MonoBehaviour
{
    public static int hp = 100;
    public static int damage = 0;
    bool Un = false;
    public TMPro.TMP_Text HpOnCanvas;
    public int scene;
    ulong frameVideo;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject HP;

    public int weight = 50;
    public float timer = 0f;
    void Start()
    {
        SetMaxValue(hp);
        gameOver.SetActive(false);
        gameOverMenu.SetActive(false);
        frameVideo = (ulong) video.frameCount;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            timer = 0;
            MinusHp();
        }
        SetValue(hp);
        if (Player.transform.position.y < -weight)
        {
            SetMenu();
        }
    }
    // Update is called once per frame
    void UnOff()
    {
        Un = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && !Un)
        {
            hp -= damage;
            Un = true;
            HpOnCanvas.text = hp.ToString();
            Invoke("UnOff", 1f);
            if(hp <= 0)
            {
                SetMenu();
                HpHeal();
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "InstaKill" && !Un)
        {
            SetMenu();
            HpHeal();
        }
    }
    
    void SetMenu()
    {
        Player.SetActive(false);
        video.Prepare();
        video.loopPointReached += video_loopPointReached;
        gameOver.SetActive(true);
        HP.SetActive(false);
    }
    void SetMenuButton()
    {
        gameOverMenu.SetActive(true);
    }

    private void video_loopPointReached(VideoPlayer source)
    {
        gameOver.SetActive(false);
        SetMenuButton();
    }

    public void MinusHp()
    { 
            hp--;
            HpOnCanvas.text = hp.ToString();
        if (hp <= 0) { SetMenu();
            HpHeal();
        }
  
    }

    public Slider bar;

    public void SetMaxValue(int hp)
    {
        bar.maxValue = hp;
        bar.value = hp;
    }
    public void SetValue(int hp)
    {
        bar.value = hp;
    }
    public static void HpHeal()
    {
        HPHUD.hp = (100 - HPHUD.hp) + HPHUD.hp;
    }
}


