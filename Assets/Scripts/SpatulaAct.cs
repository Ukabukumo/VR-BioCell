using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaAct : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Transform>().tag == "Organoid")
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
        }    
    }
}
