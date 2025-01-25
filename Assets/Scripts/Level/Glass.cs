using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public float hpGlass = 1;
    PlayerMove player;
    void Start()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Punch"))
        {
            hpGlass--;
            Debug.Log(hpGlass);
        }
    }
    private void Update()
    {
        if (hpGlass < 1)
        {
            Destroy(gameObject);
        }
    }
}
