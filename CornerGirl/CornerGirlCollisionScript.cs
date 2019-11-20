using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerGirlCollisionScript : MonoBehaviour
{
    public GameObject myCornerGirl;
    private CornerGirlAI _cornerGirlAIScript;

    // Start is called before the first frame update
    void Start()
    {
        //get variable
        _cornerGirlAIScript = myCornerGirl.GetComponent<CornerGirlAI>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Detection();
            Debug.Log("collision was detetced");
        }
    }

    public void Detection()
    {
        _cornerGirlAIScript.detected = true;
    }
}
