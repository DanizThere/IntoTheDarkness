using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject BlocksRed;
    public GameObject BlocksGreen;
    public GameObject Key;
    public int keys;
    public int enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            keys++;
            Destroy(Key);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Door") && keys > 0 && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(BlocksGreen);
            keys--;
        }
    }

    private void Update()
    {
        KeyOpen();
    }

    void KeyOpen()
    {
        if (Enemy == null)
        {
            enemies--;
        }
        if (enemies == 0)
            Destroy(BlocksRed);
    }
}
