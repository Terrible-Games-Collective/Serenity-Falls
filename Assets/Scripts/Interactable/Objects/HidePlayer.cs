using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : Interactable
{
    public bool isHiding;
    public GameObject player;
    public GameObject hidingObject;
    public Camera cam;
    public GameObject HideUI;
    private Vector2 prevPos;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (isHiding)
            {
                HideUI.SetActive(false);
                UnHide();
            }
            else
            {
                HideUI.SetActive(true);
                Hide();
            }
        }
        // else if monsterInRange && isHiding
        // cast IfoundYou()
        // MonsterCatch()
    }
    public void Hide()
    {
        isHiding = true;
        prevPos = new Vector2(player.transform.position.x, player.transform.position.y);
        player.transform.position = new Vector2(hidingObject.transform.position.x, hidingObject.transform.position.y);
        player.SetActive(false);
        cam.orthographicSize = 2;
    }
    public void UnHide()
    {
        isHiding = false;
        player.transform.position = prevPos;
        player.SetActive(true);
        cam.orthographicSize = 5;
    }

    public void MonsterCatch()
    {
        isHiding = false;
        player.SetActive(true);
        cam.orthographicSize = 5;     
        // player dead
    }
}
