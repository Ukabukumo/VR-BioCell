using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropAct : MonoBehaviour
{
    private GameObject promptText;

    void Start()
    {
        promptText = GameObject.Find("Prompt");
        StartCoroutine(deadTime(1));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "PipetteLabel")
        {
            other.gameObject.SetActive(false);
            promptText.GetComponent<TextMeshPro>().text = "Поместите органоид в свою чашу";
            Destroy(gameObject);
        }

        if (other.GetComponent<Collider>().tag != "Pipette" && other.GetComponent<Collider>().tag != "Plate")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator deadTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
