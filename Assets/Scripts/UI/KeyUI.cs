using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public Inventory PlayerInventory;
    public Image[] keys;
    public Sprite keyObtained;
    public Sprite keyMissing;
    public Text keyText;

    // Start is called before the first frame update
    void Start()
    {
        InitKeys();
    }

    void Update()
    {
        if (PlayerInventory.Key > 0)
        {
            keyText.text = PlayerInventory.Key + " Key Obtained";
        }
        if (PlayerInventory.Key == 0)
        {
            keyText.text = "Key not found";
        }

    }


    public void InitKeys()
    {
        for (int i = 0; i < 3; i++)
        {
            keys[i].gameObject.SetActive(true);
            keys[i].sprite = keyMissing;
        }
    }
    public void UpdateKeys()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < PlayerInventory.Key && PlayerInventory.Key != 0)
            {
                keys[i].sprite = keyObtained;
            }
            else
            {
                keys[i].sprite = keyMissing;
            }
        }
    }
}

