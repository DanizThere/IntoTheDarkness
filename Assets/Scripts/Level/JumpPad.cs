using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public LayerMask layerMask;
    public float force = 5f;
    public GameObject entity;
    private void OnCollisionStay2D(Collision2D collision)
    {

            Debug.Log("я типа подкидываю");
            entity.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
        
    }
}
