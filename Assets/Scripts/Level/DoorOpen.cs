using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public Animator Door;
    bool isOpen;
    public int scene;
    void Start()
    {
        Door = GetComponent<Animator>();
        isOpen = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen && collision.gameObject.tag == "Player")
        {
            isOpen = true;
            Door.SetBool("IsClosed", isOpen);
            StartCoroutine(OpenAnim());
        }
    }
    private IEnumerator OpenAnim()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(scene);
    }
}
