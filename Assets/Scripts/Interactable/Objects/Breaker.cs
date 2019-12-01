using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : Interactable
{
    public GameObject[] MapLighting;
    private MonsterBrain monsterBrain;

    // blocked door
    public float cooldown;
    public float cooldownTimer;
    // check status of the cooldown
    public bool cdOn;
    private void Start()
    {
        cdOn = false;
        monsterBrain = GameObject.FindWithTag("Monster").GetComponent<MonsterBrain>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            // set cooldowntimer and use breaker
            cooldownTimer = cooldown;
            if (!cdOn)
            {
                UseBreaker(0);
            }
        }
        CooldownTM();
    }
    public void UseBreaker(int n)
    {
        // player = 0
        // monster = 1

        if (n == 0)
        {
            cdOn = true;
            foreach (GameObject light in MapLighting)
            {
                light.gameObject.SetActive(true);
            }
        }
        else if (n == 1)
        {
            // set all lights to false
            foreach (GameObject light in MapLighting)
            {
                light.gameObject.SetActive(false);
            }
        }
           
        monsterBrain.breakerOn = !monsterBrain.breakerOn;
    }

    public void SwitchBreaker()
    {
        UseBreaker(1);
    }

    public void CooldownTM()
    {
        // a cooldown timer once finnished set status cooldown good to be used again
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
            cdOn = false;
        }
    }
}
