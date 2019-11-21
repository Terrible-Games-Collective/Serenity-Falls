using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    public GameObject popupUI;

    private float cooldownTimer;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = 3;
        popupUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CooldownTimer(popupUI);
    }

    public void CooldownTimer(GameObject uiObjects)
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
            uiObjects.SetActive(false);
        }
    }
}
