using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BatteryType
{
    normal,
    doubleA
}
public class Battery : Interactable
{
    [Header("Battery variables")]
    public BatteryType thisBatteryType;
    
    public SpriteRenderer keySprite;
    public CircleCollider2D triggerCollider;
    public EdgeCollider2D batteryCollider;
    public GameObject flashlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            GetBattery();
            upgradeFlashlight();
        }
    }
    public void GetBattery()
    {
        keySprite.enabled = false;
        triggerCollider.enabled = false;
        batteryCollider.enabled = false;
    }

    public void upgradeFlashlight()
    {
        flashlight.transform.localScale += new Vector3(0, 2, 0);
    }
}
