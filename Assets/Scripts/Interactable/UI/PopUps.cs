using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUps : MonoBehaviour
{
    public GameObject popupUI;
    public string msg;

    // popup for player help - controls objectives...
    void Start()
    {
        popupUI.SetActive(false);
    }

    public void closePopup()
    {
        popupUI.SetActive(false);
    }
    public void openPopup()
    {
        popupUI.GetComponent<Text>().text = msg;
        popupUI.SetActive(true);
    }
}
