using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BatteryType
{
    normal,
    doubleA
}
// is an Interactable
public class Battery : Interactable
{
    [Header("Battery variables")]
    // type of battery
    public BatteryType thisBatteryType;
    // sprite of the battery
    public SpriteRenderer keySprite;
    // all its triggers
    public CircleCollider2D triggerCollider;
    public EdgeCollider2D batteryCollider;
    // flashlight to be enhanced
    public GameObject flashlight;
    

    void Update()
    {
        // when player is in range of battery and pressed e use functions
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            GetBattery();
            upgradeFlashlight();
        }
    }
    // Once player pressed e on battery remove the battery
    // could also just destroy the game object but this works for now
    public void GetBattery()
    {
        keySprite.enabled = false;
        triggerCollider.enabled = false;
        batteryCollider.enabled = false;
    }

    // transform flashlight wideness by 2 everythime battery is used
    public void upgradeFlashlight()
    {
        flashlight.transform.localScale += new Vector3(0, 2, 0);
    }
}
