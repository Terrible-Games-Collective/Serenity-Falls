using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;

    public void PlaySound(Vector3 pos, bool open)
    {
        if (open)
        {
            AudioSource.PlayClipAtPoint(openDoorSound, pos);
        } else
        {
            AudioSource.PlayClipAtPoint(closeDoorSound, pos);
        }
    }
}
