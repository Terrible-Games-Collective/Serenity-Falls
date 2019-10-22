using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory PlayerInventory;
    void Start()
    {
        PlayerInventory.Key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
