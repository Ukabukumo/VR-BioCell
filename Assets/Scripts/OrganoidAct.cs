using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganoidAct : MonoBehaviour
{
    public bool inPincette = false;

    private Vector3 compare;
    private GameObject cytoplasme;
    private Vector3 cytoplasmeCentre;
    private float delay;
    private Vector3 changePos;

    void Start()
    {
        this.GetComponent<Rigidbody>().mass = 1000;

        changePos = new Vector3(0, 0, 0);

        cytoplasme = GameObject.Find("Cytoplasme");
        cytoplasmeCentre = cytoplasme.transform.position;

        delay = 0;
    }

    void Update()
    {
        compare = cytoplasmeCentre - transform.position;

        if (Mathf.Abs(compare.x) > 0.2 || Mathf.Abs(compare.y) > 0.2 || Mathf.Abs(compare.z) > 0.2)
        {
            if (GetComponent<HandInteract>().grabed == false && inPincette == false)
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }

            else if (inPincette)
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else
        {
            Transform child = this.GetComponent<Transform>().GetChild(0);
            child.gameObject.SetActive(false);

            delay -= Time.deltaTime;
            if (this.GetComponent<HandInteract>().grabed == false && delay <= 0)
            {
                delay = 0.1f;
                transform.Translate(-changePos * 10 * Time.deltaTime);
                changePos = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
                transform.Translate(changePos * 10 * Time.deltaTime);
            }
        }
    }
}
