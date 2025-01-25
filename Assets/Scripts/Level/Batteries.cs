using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("PlayerCollect");
            Destroy(gameObject, 5f);
            HPHUD.HpHeal();
        }
    }
}
