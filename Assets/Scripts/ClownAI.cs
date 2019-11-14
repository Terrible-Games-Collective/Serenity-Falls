using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAI : MonoBehaviour
{
    public bool detected = false;
    public Transform clownTrans;

    public GameObject clownScare;

    // Start is called before the first frame update
    void Start()
    {
        clownTrans = this.GetComponent<Transform>();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           detection();
        }
    }

    public void detection()
    {
        detected = true;
    }

    public void jumpscare()
    {
        GameObject scare = Instantiate(clownScare, transform.position, Quaternion.identity);
        Destroy(scare, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(detected)
        {
            jumpscare();
        }
    }
}
