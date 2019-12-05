using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainQuit : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
