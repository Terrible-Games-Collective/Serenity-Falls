using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBrain : MonoBehaviour
{



    //Data updated by other objects that contains the game state
    //Info will be selecteivly fed to the monster at different intervals
    public Sector startingSector;

    public int keysLeft;
    public int blockedDoors;
    public int minionsSpawned;
    public int maxMinions;
    
    public bool breakerOn;
    public Sector currentSector; //this gets updated by the sectors directly.
    public Sector[] allSectors; //Array of all sectors, theri index is their sector ID



    



    // Start is called before the first frame update
    void Start()
    {
        currentSector = startingSector;

        keysLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //Updates the current sector that the player is in
    public void updateCurrentSector(Sector sector) {
        currentSector = sector;
    }


    //returns a sector that still contains a key
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
