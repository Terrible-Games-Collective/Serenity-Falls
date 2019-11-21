using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : Interactable
{
    public GameObject MapLighting;
    public GameObject MainLights;

    private MonsterBrain monsterBrain;

    void Start()
    {
        monsterBrain = GameObject.FindWithTag("Monster").GetComponent<MonsterBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            StartCoroutine(UseBreaker());
        }
    }
    private IEnumerator UseBreaker()
    {
        // if (main lights are on)
        //      turn it off
        //      waitforseconds(2) 
        //      backuplights on
        // else if (main lights are off)
        //      waitforseconds(5)
        //      turn it on
        //      turn off backup
        if (MainLights.activeSelf)
        {
            MainLights.SetActive(false);
            yield return new WaitForSeconds(2f);
            MapLighting.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(3f);
            MainLights.SetActive(true);
            MapLighting.SetActive(false);
        }
        monsterBrain.breakerOn = !monsterBrain.breakerOn;
    }

    public void SwitchBreaker()
    {
        StartCoroutine(UseBreaker());
    }

}
