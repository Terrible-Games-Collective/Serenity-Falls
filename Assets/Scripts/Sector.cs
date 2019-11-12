using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public Transform[] NursePathSpots;
    public GameObject nurse;

    public GameObject[] sectorRooms;

    public bool containsKey;


    public int playerRoomID;
    public bool containsPlayer;



    // Start is called before the first frame update
    void Start()
    {
        //Loop through all rooms and set their ID
        Room tempRoom;
        for (int i = 0; i < sectorRooms.Length; i++)
        {
            tempRoom = sectorRooms[i].GetComponent<Room>();
            tempRoom.roomID = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("entered Sector 0");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("exited Sector 0");
        }
    }



    //Should be called when the player picks up a key
    public void KeyAquired()
    {
        Room tempRoom;
        containsKey = false;
        for (int i = 0; i < sectorRooms.Length; i++)
        {
            tempRoom = sectorRooms[i].GetComponent<Room>();
            if (tempRoom.containsKey)
            {
                tempRoom.key = null;
                tempRoom.containsKey = false;
            }
        }
    }
}
