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



    //Monsters brain data
    protected List<GameObject> key1UnblockedDoors;
    protected List<GameObject> key2UnblockedDoors;
    protected List<GameObject> key3UnblockedDoors;
    protected List<GameObject> key1BlockedDoors;
    protected List<GameObject> key2BlockedDoors;
    protected List<GameObject> key3BlockedDoors;
    protected List<GameObject> remainingKeys;
    protected int blockedDoors;






    // Start is called before the first frame update
    void Start()
    {
        
       
        foreach (GameObject door in key1Doors)
        {
            key1UnblockedDoors.Add(door);
        }

        foreach (GameObject door in key2Doors)
        {
            key2UnblockedDoors.Add(door);
        }

        foreach (GameObject door in key3Doors)
        {
            key3UnblockedDoors.Add(door);
        }



        foreach (GameObject key in allKeys)
        {
            remainingKeys.Add(key);
        }




        Debug.Log("Key 1 Doors: " + key1UnblockedDoors.Count);
        Debug.Log("Key 2 Doors: " + key2UnblockedDoors.Count);
        Debug.Log("Key 3 Doors: " + key3UnblockedDoors.Count);

        Debug.Log("Keys: " + remainingKeys.Count);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
