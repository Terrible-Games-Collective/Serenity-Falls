﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0);
        }
    }
}
