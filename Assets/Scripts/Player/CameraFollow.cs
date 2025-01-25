using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float dumping = 0.25f;
    private Vector3 pos = new Vector3(2f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;


    [SerializeField] private Transform player;

    void Update()
    {
        Vector3 targetPos = player.position + pos;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dumping);
    }

}
