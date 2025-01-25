using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStuck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject key;
    public GameObject door;
    int keyWeHave = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            keyWeHave++;
            Destroy(key);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (keyWeHave == 1 && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(door);
            keyWeHave--;
        }
    }
}
