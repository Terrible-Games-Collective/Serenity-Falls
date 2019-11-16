using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareFollowPlayer : MonoBehaviour
{

    public GameObject target;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private float posZ;

    // Start is called before the first frame update
    void Start()
    {
        posZ = target.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {

            transform.position = target.transform.position;
            /**
            Vector3 delta = target.transform.position - transform.position;
            Vector3 destination = transform.position + delta;
            destination.z = posZ;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    **/
        }
    }
}
