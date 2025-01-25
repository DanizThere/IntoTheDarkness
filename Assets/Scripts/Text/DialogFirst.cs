using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogFirst : MonoBehaviour
{
    public TMPro.TMP_Text dialogText;
    public GameObject dialogSys;

    public bool dialogIsGoing;
    int i = 0;
    public string[] Text;
    private void Start()
    {
        dialogSys.SetActive(true);

        Text[0] = "Необходимо проверить твои навыки и подсистемы. Наверняка что-то могло заклинить после падения.";
    }
    void Update()
    {
        dialogText.text = Text[i];
        if (dialogIsGoing == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                i++;
                Text[1] = "Попробуй подвигаться, попрыгать.";
                Text[2] = "Так. Вроде всё работает";
                Text[3] = "Пройди до конца полигона.";
                dialogIsGoing = true;
                dialogText.text = Text[i];
            }
            if (i == 4)
            {
                dialogSys.SetActive(false);
                i++;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("teleport"))
        {
            dialogSys.SetActive(true);
            Text[4] = "1";
            Text[5] = "Телепорты? Я такого не делал.";
            Text[6] = "Ладно";
            if(i == 7)
            {
                dialogSys.SetActive(false);
            }
        }
    }
}
