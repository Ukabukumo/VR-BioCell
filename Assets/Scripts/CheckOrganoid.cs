using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckOrganoid : MonoBehaviour
{
    public bool placed = false;
    public Material blueHighlight;
    public Material defaultMat;

    private bool first = true;
    private bool washed = false;
    private GameObject promptText;


    void Start()
    {
        promptText = GameObject.Find("Prompt");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Organoid")
        {
            if (other.GetComponent<HandInteract>().grabed == false)
            {
                if ((other.GetComponent<Collider>().name + "Plate") == this.name)
                {
                    placed = true;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Organoid")
        {
            if (other.GetComponent<HandInteract>().grabed == false)
            {
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                other.GetComponent<Rigidbody>().freezeRotation = true;

                checkFlush(other);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Organoid")
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.GetComponent<Rigidbody>().freezeRotation = false;
            if ((other.GetComponent<Collider>().name + "Plate") == this.name)
            {
                placed = false;
            }
        }
    }

    public bool getPlaced()
    {
        return placed;
    }

    public void checkFlush(Collider other)
    {
        Transform child = other.GetComponent<Transform>().GetChild(0);

        if (child.gameObject.activeSelf)
        {
            promptText.GetComponent<TextMeshPro>().text = "Вы не промыли помещенный органоид!";
            placed = false;

            setMaterial(false);
        }

        else if (child.gameObject.activeSelf == false && first)
        {
            promptText.GetComponent<TextMeshPro>().text = "Извлеките органоид из цитоплазмы\nи промойте его!";
            first = false;

            if ((other.GetComponent<Collider>().name + "Plate") == this.name)
            {
                placed = true;
            }

            setMaterial(true);
        }
    }

    public void setMaterial(bool value)
    {
        Transform plate, ch;
        plate = transform.GetChild(0);

        if (value)
        {
            ch = plate.transform.GetChild(0);
            ch.GetComponent<Renderer>().material = blueHighlight;

            ch = plate.transform.GetChild(1);
            ch.GetComponent<Renderer>().material = blueHighlight;
        }
        else
        {
            ch = plate.transform.GetChild(0);
            ch.GetComponent<Renderer>().material = defaultMat;

            ch = plate.transform.GetChild(1);
            ch.GetComponent<Renderer>().material = defaultMat;
        }
    }
}
