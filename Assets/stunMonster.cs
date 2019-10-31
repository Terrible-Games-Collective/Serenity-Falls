using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunMonster : MonoBehaviour
{
    // Start is called before the first frame update
    private FovDetection fov;

    void Start()
    {
        fov = GetComponentInChildren<FovDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fov.IsInView()) {
            fov.Target.GetComponent<MonsterAI>().SendMessage("ApplyStun");
            Debug.Log("Stunned!");
        }
    }
}
