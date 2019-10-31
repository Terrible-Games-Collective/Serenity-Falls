using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlay : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
}
