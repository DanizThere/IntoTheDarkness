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

        Text[0] = "���������� ��������� ���� ������ � ����������. ��������� ���-�� ����� ��������� ����� �������.";
    }
    void Update()
    {
        dialogText.text = Text[i];
        if (dialogIsGoing == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                i++;
                Text[1] = "�������� �����������, ���������.";
                Text[2] = "���. ����� �� ��������";
                Text[3] = "������ �� ����� ��������.";
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
            Text[5] = "���������? � ������ �� �����.";
            Text[6] = "�����";
            if(i == 7)
            {
                dialogSys.SetActive(false);
            }
        }
    }
}
