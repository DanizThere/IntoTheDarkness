using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullCamera : MonoBehaviour
{
    public Camera m_Camera;
    public float size = 13f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player")) m_Camera.orthographicSize = size;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player")) m_Camera.orthographicSize = 8f;
    }
}
