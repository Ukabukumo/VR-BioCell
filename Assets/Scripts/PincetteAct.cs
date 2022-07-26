using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PincetteAct : MonoBehaviour
{
    private Collider organoid;

    [SerializeField]
    private SteamVR_Action_Boolean gripAction;
    [SerializeField]
    private SteamVR_Action_Boolean pinchAction;

    private bool oneShot = false;
    private int state = 0;
    private HandInteract handInteract;

    private void Start()
    {
        handInteract = GetComponent<HandInteract>();
    }

    void Update()
    {
        if (handInteract.grabed)
        {
            if (handInteract.curHand == pinchAction.activeDevice.ToString())
            {
                if (pinchAction.state && !oneShot)
                {
                    PincetteAnim();
                    oneShot = true;
                }
                else if (!pinchAction.state && oneShot)
                {
                    PincetteAnim(true);
                    oneShot = false;
                }
            }
        }
        else if (oneShot)
        {
            PincetteAnim(true);
            oneShot = false;
        }
    }

    private void PincetteAnim(bool inverse = false)
    {
        int i = inverse ? -1 : 1;

        Transform child = transform.GetChild(0);
        Transform ch;
        Quaternion curRotation;

        curRotation = transform.rotation;
        transform.rotation = Quaternion.Euler(90, 270, 0);

        ch = child.transform.GetChild(1);
        ch.transform.position = new Vector3(ch.transform.position.x + i * 0.0094f, ch.transform.position.y, ch.transform.position.z + i * 0.001f);
        ch.transform.rotation *= Quaternion.Euler(0, 0, -6 * i);

        ch = child.transform.GetChild(2);
        ch.transform.position = new Vector3(ch.transform.position.x - i * 0.0094f, ch.transform.position.y, ch.transform.position.z - i * 0.001f);
        ch.transform.rotation *= Quaternion.Euler(0, 0, -6 * i);

        transform.rotation = curRotation;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Organoid")
        {
            if (pinchAction.stateDown && GetComponent<HandInteract>().grabed)
            {
                organoid = other;
                organoid.transform.parent = transform;
                organoid.GetComponent<HandInteract>().grabed = true;
                organoid.GetComponent<Rigidbody>().isKinematic = true;
            }

            if (pinchAction.stateUp || !GetComponent<HandInteract>().grabed)
            {
                if (organoid != null)
                {
                    organoid.transform.parent = null;
                    organoid.GetComponent<HandInteract>().grabed = false;
                    organoid.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
    }
}
