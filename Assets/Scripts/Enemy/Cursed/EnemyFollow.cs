using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public GameObject playerTr;
    public GameObject En;
    public float hp;
    bool un = false;
    bool attack;
    public Animator anim;

    private void Start()
    { 
        hp = 100;
        Debug.Log(hp);
    }

    void Update()
    {
        Walking();

        if (hp <= 0)
        {
            Destroy(En);
            Debug.Log(hp);
        }
    }

    void Walking()
    {
        if(transform.position.x - playerTr.transform.position.x > -5 || transform.position.x - playerTr.transform.position.x < 5)
        {        
        }
        if(transform.position.x - playerTr.transform.position.x > 0)
        {
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Punch") && !un)
        {
            un = true;
            hp -= CombatSystem.damage;
            Debug.Log(hp);
            Invoke("UnOff", 1f);
        }

    }
    void UnOff()
    {
        un = false;
    }
    public GameObject[] crap;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("InstaKill"))
            Destroy(gameObject);
    }

}
