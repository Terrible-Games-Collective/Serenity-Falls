using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public Inventory PlayerInventory;
    public Text keyText;
    public 
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInventory.Key == true)
        {
            keyText.text = "Key Obtained";
        }
        if (PlayerInventory.Key == false)
        {
            keyText.text = "Key not found";
        }

    }
}
