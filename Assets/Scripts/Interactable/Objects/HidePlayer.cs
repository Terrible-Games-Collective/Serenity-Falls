using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : Interactable
{
    public IsHiding isHiding;
    public GameObject player;
    public GameObject hidingObject;
    public Camera cam;
    public GameObject HideUI;
    private Vector2 prevPos;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        // isHiding is a Scriptable and saves last state of the character 
        // so need to set it false for the bug of player exiting the game while hiding
        isHiding.isHiding = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // to hide need player to press e and in range to object
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            // if player is hiding do UnHide()
            if (isHiding.isHiding)
            {
                HideUI.SetActive(false);
                UnHide();
            }
            // if player is not hiding Hide()
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
    // to hide() set state to hiding and teleport player to the hiding spot "interactable object"
    // also save the spot to know where to go when unhide does its thing
    // also character game object will be off
    // also bring camera closer
    public void Hide()
    {
        isHiding.isHiding = true;
        prevPos = new Vector2(player.transform.position.x, player.transform.position.y);
        player.transform.position = new Vector2(hidingObject.transform.position.x, hidingObject.transform.position.y);
        player.SetActive(false);
        cam.orthographicSize = 2;
    }
    // unhide() will change state of player to not hiding
    // and teleport to its postion when it went to hiding
    // basically reverse what was done in Hide()
    public void UnHide()
    {
        isHiding.isHiding = false;
        player.transform.position = prevPos;
        player.SetActive(true);
        cam.orthographicSize = 10;
    }
    // catch the player if its hiding and reverse what is done in hide()
    public void MonsterCatch()
    {
        isHiding.isHiding = false;
        player.SetActive(true);
        cam.orthographicSize = 10;     
        // player dead
    }

}
