using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
        void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                HPHUD.HpHeal();
                SaveManager.instance.activeSave.respawnPos = transform.position;
                SaveManager.instance.Save();
            }
        }
}
