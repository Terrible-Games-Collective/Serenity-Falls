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

    private MonsterBrain monsterBrain;

    // Start is called before the first frame update
    void Start()
    {
        ghostRb = this.GetComponent<Rigidbody2D>();
        ghostTrans = this.GetComponent<Transform>();

        monsterBrain = GameObject.FindWithTag("Monster").GetComponent<MonsterBrain>();

        monsterBrain.minionsSpawned++;
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
        GameObject scare = Instantiate(scareEffect, transform.position, Quaternion.identity);
        monsterBrain.minionsSpawned--;
        Destroy(scare, 8.0f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyDetected)
        {
            if (detected)
            {
                escape();
            }
        }
    }
}
