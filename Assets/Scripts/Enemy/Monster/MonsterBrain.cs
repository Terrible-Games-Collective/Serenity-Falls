using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBrain : MonoBehaviour
{
    public Sector startingSector;
    public struct monster_manager
    {

        public int keysLeft;
        public int blockedDoors;
        public int minionsSpawned;
        public int maxMinions;

        public bool breakerOn;
        public Sector currentSector; //this gets updated by the sectors directly.
        public Sector[] allSectors; //Array of all sectors, theri index is their sector ID
        public Sector GetSectorWithKey()
        {
           for (int i = 1; i < allSectors.Length; i++)
            {
                if (allSectors[i].containsKey)
                    return allSectors[i];
            }
            return null;
        }

    }

    public monster_manager manager = new monster_manager();


    // Start is called before the first frame update
    void Start()
    {
        manager.currentSector = startingSector;
        manager.allSectors = new Sector[4];
        for(int i = 0; i < 4; i++)
        {
            manager.allSectors[i] = GameObject.Find("Sector (" + 0 + ")").GetComponent<Sector>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void updateCurrentSector(Sector sector) {
        manager.currentSector = sector;
    }
}
