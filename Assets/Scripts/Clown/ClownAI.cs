using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAI : MonoBehaviour
{
    public bool detected = false;
    public Transform clownTrans;
    public GameObject clownScare;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        clownTrans = this.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");

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
            unDetection();
        }
    }

    public void detection()
    {
        detected = true;
    }

    public void unDetection()
    {
        detected = false;
    }

    public void jumpscare()
    {
        Vector3 playerLoc = player.transform.position;
        unDetection();
        GameObject scare = Instantiate(clownScare, playerLoc, Quaternion.identity);
        Destroy(scare, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            jumpscare();
        }

    }
}
