using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    public GameObject popupUI;

    void Start()
    {
        popupUI.SetActive(false);
    }

    public void PopItUp()
    {
        popupUI.SetActive(true);
    }
}
