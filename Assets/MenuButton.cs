using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour
{
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
