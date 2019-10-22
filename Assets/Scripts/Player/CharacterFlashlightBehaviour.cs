using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlashlightBehaviour : MonoBehaviour
{

    public GameObject[] lights;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject g in lights)
            {
                g.SetActive(!g.activeSelf);
            }
        }

    }
}
