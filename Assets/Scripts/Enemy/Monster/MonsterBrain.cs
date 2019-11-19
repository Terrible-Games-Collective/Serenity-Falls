using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBrain : MonoBehaviour
{
    public struct monster_manager
    {

        public int keysLeft;
        public int blockedDoors;
        public int minionsSpawned;
        public int maxMinions;

        public bool breakerOn;
        public Sector currentSector; //this gets updated by the sectors directly.


    }

    public monster_manager manager = new monster_manager();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void updateCurrentSector(Sector sector) {
        manager.currentSector = sector;
    }
}
