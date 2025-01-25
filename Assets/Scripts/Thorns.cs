using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    public GameObject thorns;
    public Transform positionSpawn;
    public float timer = 0;
    public float timeDestroy = 2.5f;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 2)
        {
            timer = 0;
            Thor();
        }
    }
    GameObject clone;
    // Update is called once per frame
    void Thor()
    {
        clone = Instantiate(thorns, positionSpawn.position, Quaternion.identity);
            Destroy(clone,timeDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(clone);
        }
    }
}
