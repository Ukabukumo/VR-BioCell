using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;
using TMPro;

public class SwitchQuest : MonoBehaviour
{
    public GameObject quest1;
    public GameObject quest2;

    private bool end = false;
    private bool active = false;
    private GameObject timeText;
    private GameObject taskText;
    private GameObject promptText;
    private float timeLeft;
    private int countQuest = 1;

    [SerializeField]
    private SteamVR_Action_Boolean menuAction;

    [SerializeField]
    private int timeQuest;

    [SerializeField]
    private GameObject plates1;

    [SerializeField]
    private GameObject plates2;

    [SerializeField]
    private GameObject resultText;

    void Start()
    {
        taskText = GameObject.Find("Task");
        timeText = GameObject.Find("Time");
        promptText = GameObject.Find("Prompt");
        timeLeft = timeQuest;
    }

    void Update()
    {
        if (!menuAction.state)
        {
            active = false;
        }

        if (end == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timeText.GetComponent<TextMeshPro>().text = "Oсталось времени: " + string.Format("{0:D2}:{1:D2}", (int)(timeLeft / 60), (int)(timeLeft % 60));
            }
            else
            {
                end = true;
                timeLeft = timeQuest;
                plates1.GetComponent<Quest>().countPoints();
                plates1 = plates2;  
            }
        }

        if (menuAction.state && !end && !active)
        {
            active = true;
            promptText.SetActive(false);
            end = true;
            timeLeft = timeQuest;
            plates1.GetComponent<Quest>().countPoints();
            plates1 = plates2;
        }

        if (end && menuAction.state && countQuest < 2 && !active)
        {
            active = true;
            promptText.SetActive(true);
            resultText.SetActive(false);
            taskText.GetComponent<TextMeshPro>().text = "Задание: расположите органоиды растительной\nклетки по чашкам Петри";
            countQuest++;
            end = false;
            GameObject tmp;
            resultText.SetActive(false);

            tmp = GameObject.Find("Membrane");
            if (tmp != null)
            {
                Destroy(tmp);
            }

            tmp = GameObject.Find("Cytoplasme");
            if (tmp != null)
            {
                Destroy(tmp);
            }

            tmp = GameObject.Find("Mitochondria");
            if (tmp != null)
            {
                if (tmp.GetComponent<HandInteract>().grabed == false)
                {
                    Destroy(tmp);
                }
            }

            tmp = GameObject.Find("Core");
            if (tmp != null)
            {
                if (tmp.GetComponent<HandInteract>().grabed == false)
                {
                    Destroy(tmp);
                }
            }

            tmp = GameObject.Find("RoughEPS");
            if (tmp != null)
            {
                if (tmp.GetComponent<HandInteract>().grabed == false)
                {
                    Destroy(tmp);
                }
            }

            tmp = GameObject.Find("SmoothEPS");
            if (tmp != null)
            {
                if (tmp.GetComponent<HandInteract>().grabed == false)
                {
                    Destroy(tmp);
                }
            }

            tmp = GameObject.Find("CytoskeletonMicrotubules");
            if (tmp != null)
            {
                if (tmp.GetComponent<HandInteract>().grabed == false)
                {
                    Destroy(tmp);
                }
            }

            tmp = GameObject.Find("Centrioles");
            if (tmp != null)
            {
                if (tmp.GetComponent<HandInteract>().grabed == false)
                {
                    Destroy(tmp);
                }
            }

            tmp = GameObject.Find("GolgiApparatus");
            if (tmp != null)
            {
                if (tmp.GetComponent<HandInteract>().grabed == false)
                {
                    Destroy(tmp);
                }
            }

            tmp = GameObject.Find("Plates");
            if (tmp != null)
            {
                Destroy(tmp);
            }

            tmp = GameObject.Find("PlatesName");
            if (tmp != null)
            {
                Destroy(tmp);
            }

            quest1.SetActive(false);
            quest2.SetActive(true);
        }
    }
}