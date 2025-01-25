using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 position = new Vector3(0, -2.282379f, 0);
    private Vector3 direction = Vector3.zero;
    float smooth = 0f;

   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.transform.localScale = new Vector3(4.5f, 0.21f, 0);
            position = new Vector3(0, -0.8f, 0);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1.4f, 0.21f, 0);
            position = new Vector3(0, -2.282379f, 0);
        }
        Idle();
    }

    void Idle()
    {
        Vector3 targetposition = player.position + position;
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref direction, smooth);
    }

}

