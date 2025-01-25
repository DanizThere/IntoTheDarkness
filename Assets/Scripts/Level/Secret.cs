using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    public GameObject Easter;
    public bool onPause;

    private void Start()
    {
        onPause = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Secret"))
        {
            onPause = true;
            gameObject.SetActive(onPause);
        }
    }
}
