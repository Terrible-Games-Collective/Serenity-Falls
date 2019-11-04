using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaUI : MonoBehaviour
{
    public Text AreaText;
    public Area PlayerArea;
    // Start is called before the first frame update
    void Start()
    {
        StartArea();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartArea()
    {
        AreaText.text = PlayerArea.Name;
    }
    public void UpdateArea()
    {
        AreaText.text = PlayerArea.Name;
    }
}
