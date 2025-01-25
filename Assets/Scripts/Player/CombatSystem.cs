using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public static float damage = 0;
    public GameObject Punch;
    public float nextTimeAttack = 1f;
    public float attackRate = 2f;
    public GameObject Enemies;
    public int commonCheck = 0;
    PlayerMove player;
    public void Start()
    {
        Punch.SetActive(false);
        player = gameObject.GetComponent<PlayerMove>();
    }
    public void Update()
    {
        if (Time.time >= nextTimeAttack)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                CommmonAttackHand();
                nextTimeAttack = Time.time + 1f / attackRate;
                commonCheck++;
                if(commonCheck == 2)
                {
                    DoubleAttackHand();
                    player.anim.SetBool("IsJumping", true);
                    commonCheck = 0;
                }
                else if(commonCheck < 2) { player.anim.SetBool("IsJumping", false); }
            }
            if(Input.GetKey(KeyCode.LeftControl))
            {
                Punch.SetActive(true);
                Slam();
            }
            else { Punch.SetActive(false); }

            if (Input.GetKeyDown(KeyCode.L))
            {
                CommonAttackLeg();
                nextTimeAttack = Time.time + 1f / attackRate;
            }
        }
    }
    void Slam()
    {
        if (PlayerMove.isSlam == true)
        {
            damage = 30;
            Punch.GetComponent<BoxCollider2D>().size = new Vector2(0.6525193f, 0.1192278f);
            Punch.GetComponent<BoxCollider2D>().offset = new Vector2(0.09048828f, 0.1852393f);
        }
    }
    void CommmonAttackHand()
    {
        damage = 20;
        StartCoroutine(CoolDown());
        player.anim.SetTrigger("IsCommonHandPunch");
        Punch.GetComponent<BoxCollider2D>().size = new Vector2(0.1347026f, 0.1034407f);
        Punch.GetComponent<BoxCollider2D>().offset = new Vector2(0.1852112f, 0.3131149f);
    }

    void CommonAttackLeg()
    {
        damage = 30;
        StartCoroutine(CoolDown());
        player.anim.SetTrigger("IsCommonLeg");
        Punch.GetComponent<BoxCollider2D>().size = new Vector2(0.2347026f, 0.1221223f);
        Punch.GetComponent<BoxCollider2D>().offset = new Vector2(0.1852112f, 0.1872759f);
    }

    void DoubleAttackHand()
    {
        damage = 45;
        StartCoroutine(CoolDown());
        Punch.GetComponent<BoxCollider2D>().size = new Vector2(0.1347026f, 0.1034407f);
        Punch.GetComponent<BoxCollider2D>().offset = new Vector2(0.1852112f, 0.3131149f);
    }

    IEnumerator CoolDown()
    {
        Punch.GetComponent<BoxCollider2D>().isTrigger = true;
        Punch.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Punch.SetActive(false);

    }
}
