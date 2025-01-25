using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public GameObject Stairs;
    public static Rigidbody2D rb;
    CapsuleCollider2D bc;
    public float xmove;
    public float speed;
    Vector3 size;
    public bool isJump;
    bool isRoll;
    bool isDash;
    bool isDashing;
    bool isAnimDash;
    public bool isClimb;
    public static bool isBlock;
    public Animator anim;
    public float jump = 1.5f;
    float dashCooldown = 0.5f;
    float jumpForce;
    float dashPower = 1.5f;
    float dashTimer = 0.7f;
    public float newGravity = 3f;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        size = gameObject.transform.localScale;
        isRoll = true;
        isDash = true;
        isAnimDash = false;
        isClimb = false;
        isBlock = true;
    }

    void Update()
    {
        Moving();
        Slide();
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            Jump();
        }
        Dashing();
    }

    
    private IEnumerator Dash()
    {
        
        isDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        yield return new WaitForSeconds(dashTimer);
        rb.gravityScale = newGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        isDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Dirt") || collision.gameObject.CompareTag("Glass") || collision.gameObject.CompareTag("Wood"))
        {
            isJump = false;
            anim.SetBool("IsJumping", isJump);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("stairs"))
        {
                xmove = Input.GetAxis("Vertical");
                rb.velocity = new Vector2(0, xmove * speed);
                anim.SetBool("IsClimbing", true);
                rb.gravityScale = 0f; 
        }
        if(collision.gameObject.CompareTag("stairs") == false)
        {
            anim.SetBool("IsClimbing", false);
            rb.gravityScale = newGravity;
        }
    }
    private void Moving()
    {
        if (isBlock == true)
        {
            xmove = Input.GetAxisRaw("Horizontal");
            jumpForce = Input.GetAxisRaw("Jump");

            if (isDashing) return;

            if (Input.GetButton("Horizontal"))
            {
                rb.velocity = new Vector2(xmove * speed, rb.velocity.y);
                anim.SetFloat("Speed", 1);
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
        }
        if(isBlock == false)
        {
            rb.velocity = Vector2.zero;
        }
        if (xmove > 0)
        {
            gameObject.transform.localScale = size;
        }
        if (xmove < 0)
        {
            gameObject.transform.localScale = new Vector3(-size.x, size.y, size.z);
        }

    }
    
    public static bool isSlam = false;
    void Slide()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            bc.size = new Vector2(0.2f, 0.23f);
            bc.direction = CapsuleDirection2D.Horizontal;
            anim.SetBool("IsRolling", isRoll);
            rb.velocity = new Vector2(xmove * speed * 2, rb.velocity.y);
        }
        else
        {
            bc.size = new Vector2(0.1f, 0.6499999f);
            bc.direction = CapsuleDirection2D.Vertical;
            anim.SetBool("IsRolling", false);
        }
        if ((Input.GetKey(KeyCode.LeftControl) && isJump) || (Input.GetKeyDown(KeyCode.LeftControl) && isJump))
        {
            isSlam = true;
            rb.gravityScale = 5f;
            jumpForce = 3f;
            xmove = 0f;
        }
        else
        {
            isSlam = false;
            xmove = Input.GetAxis("Horizontal");
            rb.gravityScale = newGravity;
            jumpForce = 1.5f;
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Invoke("IgnoreLayerOff", 1f);
        }
    }

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
    void Dashing()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) && isDash) ||(Input.GetKeyDown(KeyCode.LeftShift) && isDash && isJump == true))
        {
            StartCoroutine(Dash());
            isAnimDash = true;
            anim.SetBool("IsDashing", isAnimDash);

        }
        else
        {
            anim.SetBool("IsDashing", false);
        }
    }
    public void Jump()
    {
            isJump = true;
            rb.AddForce(new Vector2(0, jumpForce * jump), ForceMode2D.Impulse);
            anim.SetBool("IsJumping", isJump);
    }
}
