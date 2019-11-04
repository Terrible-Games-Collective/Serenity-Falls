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
        }
    }
    public void GetBattery()
    {
        keySprite.enabled = false;
        triggerCollider.enabled = false;
        batteryCollider.enabled = false;
    }
}
