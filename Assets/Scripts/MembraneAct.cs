using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MembraneAct : MonoBehaviour
{
    private GameObject promptText;

    public GameObject organelles;

    void Start()
    {
        promptText = GameObject.Find("Prompt");
    }

    void Update()
    {
        if (transform.childCount > 0)
        {
            organelles.SetActive(false);
            promptText.GetComponent<TextMeshPro>().text = "�������� ��������� � ��������� ��������\n" + "�� ������ (" + (5 - transform.childCount) + " �� 5)";
        }
        else if (transform.childCount == 0)
        {
            promptText.GetComponent<TextMeshPro>().text = "��������� �������� �� ���������� �\n�������� ���!";
            organelles.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
