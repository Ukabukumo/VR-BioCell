using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class PipetteAct : MonoBehaviour
{
    private int countDrops;
    private bool active;
    private HandInteract handInteract;

    [SerializeField]
    private GameObject drop;

    [SerializeField]
    private SteamVR_Action_Boolean gripAction;
    [SerializeField]
    private SteamVR_Action_Boolean pinchAction;

    void Start()
    {
        countDrops = 5;
        active = false;
        handInteract = GetComponent<HandInteract>();
    }

    void Update()
    {
        if (handInteract.curHand == pinchAction.activeDevice.ToString())
        {
            if (GetComponent<HandInteract>().grabed)
            {
                if (pinchAction.state && !active)
                {
                    active = true;
                    if (countDrops == 1)
                    {
                        Transform water = transform.GetChild(0);
                        water.gameObject.SetActive(false);
                        Instantiate(drop, transform.position, Quaternion.identity);
                        countDrops--;
                    }
                    else if (countDrops > 1)
                    {
                        Instantiate(drop, transform.position, Quaternion.identity);
                        countDrops--;
                    }
                }
                else if (!pinchAction.state)
                {
                    active = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Flask")
        {
            Transform water = transform.GetChild(0);
            water.gameObject.SetActive(true);
            countDrops = 5;
        }
    }
}
