using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalpelAct : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "ScalpelLabel")
        {
            Destroy(other.gameObject);
        }
    }
}
