using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public int sectorID;

    public Transform[] NursePathSpots;
    public GameObject nurse;
    private MonsterBrain monsterBrain;
    

    public bool containsKey;

    public GameObject[] sectorRooms;
    public Room playersRoom;
    public bool containsPlayer;

    public bool containsClown;
    public bool containsGirl;



    // Start is called before the first frame update
    void Start()
    {
        monsterBrain = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterBrain>();

        //Transform[] tempArray = GetComponentsInChildren<Transform>();
        //sectorRooms = new GameObject[tempArray.Length];
        //for(int i = 0; i < sectorRooms.Length; i++)
        //{
        //    sectorRooms[i] = tempArray[i].gameObject;
        //}

        //Loop through all rooms and set their ID
        Room tempRoom;
        for (int i = 0; i < sectorRooms.Length; i++)
        {
            tempRoom = sectorRooms[i].GetComponent<Room>();
            tempRoom.roomID = i;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            monsterBrain.updateCurrentSector(this);
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

    public void updatePlayersRoom(Room room) {
        playersRoom = room;
        monsterBrain.updateCurrentSector(this);

    }

    public GameObject getRandomRoom()
    {
        Debug.Log(Random.Range(0, sectorRooms.Length));
        return sectorRooms[(int)Random.Range(0, sectorRooms.Length)];
    }
}
