using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Sprite res1, res2;
    BoxCollider2D door;
    SpriteRenderer sr;
    void Start()
    {
        door = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            door.size = new Vector2(0.3884411f, 2f);
            door.offset = new Vector2(0.4517183f, 0);
            sr.sprite = res1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Punch") && Input.GetKeyDown(KeyCode.L))
        {
            sr.sprite = res2;
            door.isTrigger = true;
        }
    }
}
