using UnityEngine;
using Valve.VR;

public class HandInteract : MonoBehaviour
{    
    public bool grabed = false;

    public string curHand;

    public void setGrabed(bool value)
    {
        grabed = value;
        if (value)
        {
            curHand = transform.parent.name;
        }
        else
        {
            curHand = null;
        }
    }
}
