using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPosition : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Transform startTransform;
    private Vector3 compare;
    
    private GameObject promptText;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        promptText = GameObject.Find("Prompt");
    }

    void Update()
    {
        compare = startPosition - transform.position;

        if (Mathf.Abs(compare.x) > 2 || Mathf.Abs(compare.y) > 0.5 || Mathf.Abs(compare.z) > 1)
        {
            if (this.GetComponent<HandInteract>().grabed == false)
            {
                transform.position = startPosition;
                transform.rotation = startRotation;

                if (this.GetComponent<Collider>().tag == "Organoid")
                {
                    promptText.GetComponent<TextMeshPro>().text = "Извлеките органоид из цитоплазмы\nи промойте его!";
                }
            }
        }
    }
}
