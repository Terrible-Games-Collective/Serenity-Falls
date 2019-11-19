using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public Transform[] moveSpots;
    public GameObject[] doors;


    public GameObject key;
    public bool containsKey;

    public int roomID;

    private Sector sector;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sector.updatePlayersSector(this);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        Debug.Log("exited Room " + roomID);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        if (key != null)
            containsKey = true;
        else
            containsKey = false;
        
        if (sector == null)
            sector = transform.parent.gameObject.GetComponent<Sector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
