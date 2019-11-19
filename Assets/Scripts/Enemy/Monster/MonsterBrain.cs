using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBrain : MonoBehaviour
{

    [SerializeField]
    private GameObject[] key1Doors;
    [SerializeField]
    private GameObject[] key2Doors;
    [SerializeField]
    private GameObject[] key3Doors;

    [SerializeField]
    private GameObject[] allKeys;

    private Room currentRoom; //this gets updated by the sectors directly.


    public struct monster_manager
    {
        public List<GameObject> key1UnblockedDoors;
        public List<GameObject> key2UnblockedDoors;
        public List<GameObject> key3UnblockedDoors;
        public List<GameObject> key1BlockedDoors;
        public List<GameObject> key2BlockedDoors;
        public List<GameObject> key3BlockedDoors;

        public List<GameObject> key1MinionSpawns;
        public List<GameObject> key2MinionSpawns;
        public List<GameObject> key3MinionSpawns;

        public List<GameObject> remainingKeys;

        public int keysLeft;
        public int blockedDoors;
        public int minionsSpawned;
        public int maxMinions;

        public bool breakerOn;


    }




    public monster_manager monster_brain = new monster_manager();




    // Start is called before the first frame update
    void Start()
    {
        monster_brain.remainingKeys = new List<GameObject>();
       
        foreach (GameObject door in key1Doors)
        {
            monster_brain.key1UnblockedDoors.Add(door);
        }

        foreach (GameObject door in key2Doors)
        {
            monster_brain.key2UnblockedDoors.Add(door);
        }

        foreach (GameObject door in key3Doors)
        {
            monster_brain.key3UnblockedDoors.Add(door);
        }



        foreach (GameObject key in allKeys)
        {
            monster_brain.remainingKeys.Add(key);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCurrentRoom(Room room) {
        currentRoom = room;
    }
}
