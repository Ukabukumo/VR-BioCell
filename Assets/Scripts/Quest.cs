using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Quest : MonoBehaviour
{
    public Material greenHighlight;
    public Material redHighlight;
    public GameObject resultText;

    private int NumChild;
    private int countPlaced;

    void Start()
    {
        NumChild = transform.childCount;
        countPlaced = 0;
    }

    public void countPoints()
    {
        for (int i = 0; i < NumChild; i++)
        {
            Transform child = transform.GetChild(i);
            Transform ch;

            if (child.GetComponent<CheckOrganoid>().placed)
            {
                countPlaced += 1;
                child = child.transform.GetChild(0);

                ch = child.transform.GetChild(0);
                ch.GetComponent<Renderer>().material = greenHighlight;

                ch = child.transform.GetChild(1);
                ch.GetComponent<Renderer>().material = greenHighlight;
            }
            else
            {
                child = child.transform.GetChild(0);
                ch = child.transform.GetChild(0);
                ch.GetComponent<Renderer>().material = redHighlight;

                ch = child.transform.GetChild(1);
                ch.GetComponent<Renderer>().material = redHighlight;
            }
        }

        if (countPlaced == 0 || countPlaced >= 5)
        {
            resultText.GetComponent<TextMeshPro>().text = "Hабрано " + countPlaced.ToString() + " баллов!";
        }

        else if (countPlaced == 1)
        {
            resultText.GetComponent<TextMeshPro>().text = "Hабран " + countPlaced.ToString() + " балл!";
        }

        else if (countPlaced == 2 || countPlaced == 3 || countPlaced == 4)
        {
            resultText.GetComponent<TextMeshPro>().text = "Hабрано " + countPlaced.ToString() + " балла!";
        }
        resultText.SetActive(true);
    }
}
