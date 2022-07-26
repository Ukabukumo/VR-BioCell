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
            promptText.GetComponent<TextMeshPro>().text = "Возьмите скальпель и разрежьте мембрану\n" + "по меткам (" + (5 - transform.childCount) + " из 5)";
        }
        else if (transform.childCount == 0)
        {
            promptText.GetComponent<TextMeshPro>().text = "Извлеките органоид из цитоплазмы и\nпромойте его!";
            organelles.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
