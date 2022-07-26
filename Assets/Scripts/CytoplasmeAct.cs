using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CytoplasmeAct : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Organoid")
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Organoid")
        {
            Transform child = other.GetComponent<Transform>().GetChild(0);
            child.gameObject.SetActive(true);
        }
    }
}
