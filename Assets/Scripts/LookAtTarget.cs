using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.Find("FollowHead").transform;
    }

    void Update()
    {
        if (target)
        {
            transform.LookAt(target.position);
        }
    }
}
