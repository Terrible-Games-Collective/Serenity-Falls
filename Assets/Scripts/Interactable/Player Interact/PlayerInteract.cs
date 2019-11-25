using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Inventory PlayerInventory;
    // player inventory for now it just have the number of keys the player has
    void Start()
    {
        // everytime you start a game key would be 0
        PlayerInventory.Key = 0;
    }
}
