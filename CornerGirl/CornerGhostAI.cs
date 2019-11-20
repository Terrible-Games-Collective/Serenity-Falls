using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerGhostAI : MonoBehaviour
{
    public bool detected = false;
    public bool alreadyDetected = false;
    public float moveSpeed = 20f;

    public Rigidbody2D ghostRb;
    public Transform ghostTrans;

    public GameObject scareEffect;
    public GameObject target;
    public Vector3 spawnLoc;

    // Start is called before the first frame update
    void Start()
    {
        ghostRb = this.GetComponent<Rigidbody2D>();
        ghostTrans = this.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            detection();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            unDetected();
        }
    }

    public void detection()
    {
        detected = true;
        if(alreadyDetected)
        {
            jumpscare();
        }
    }

    public void unDetected()
    {
        detected = false;
        alreadyDetected = true;
    }

    public void escape()
    {
        ghostRb.AddForce(ghostTrans.right * moveSpeed, ForceMode2D.Impulse);
    }

    public void jumpscare()
    {
        Vector3 spawnloc = target.transform.position;
        GameObject scare = Instantiate(scareEffect, transform.position, Quaternion.identity);
        Destroy(scare, 5f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        spawnLoc = target.transform.position;
        if (!alreadyDetected)
        {
            if (detected)
            {
                escape();
            }
        }else if(alreadyDetected)
        {
        

        }
    }
}
