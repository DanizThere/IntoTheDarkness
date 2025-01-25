using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    PlayerMove player;
    public float distance = 2f;
    public float speed = 2f;
    public bool wallJump;
    void Start()
    {   
        wallJump = false;
        player = GetComponent<PlayerMove>();
    }
    public LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, layerMask);

        if (player.isJump && hit.collider != null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * player.speed);
            wallJump = true;
        }
        if(wallJump == true && Input.GetKeyDown(KeyCode.Space)) 
        {
            player.Jump();
            wallJump = false;
        }
    }
}
