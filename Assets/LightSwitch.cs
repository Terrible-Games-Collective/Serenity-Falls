using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public float MaxRadius;

    public void turnOffLights(Transform MainEnemy, float MaxRadius)
    {
        //Grab all objects that overlap with the FOV Radius
        //if there is more then 100 items this could cause overflow
        Collider2D[] withinRadius = new Collider2D[100];
        int count = Physics2D.OverlapCircleNonAlloc(MainEnemy.position, MaxRadius, withinRadius);

        for (int i = 0; i <= count; i++)
        {
            if (withinRadius[i] != null && withinRadius[i].transform.gameObject.CompareTag("MapLighting"))
            {
                withinRadius[i].transform.gameObject.SetActive(false);
            }
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnOffLights(transform, MaxRadius);
    }
}
