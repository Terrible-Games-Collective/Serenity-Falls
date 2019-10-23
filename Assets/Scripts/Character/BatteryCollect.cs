using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCollect : MonoBehaviour
{
    public GameObject light;
    public float scaleAmount = 5;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Battery"))
        {
            light.transform.localScale += new Vector3(scaleAmount, 0, 0);
        }
    }
}
