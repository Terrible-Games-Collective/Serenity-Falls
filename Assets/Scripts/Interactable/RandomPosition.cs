using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public Vector2[] positions;
    public int spawnNumber;

    public GameObject InteractablePrefab;
    // Start is called before the first frame update
    void Start()
    {
        reshuffle2();

        for (int i = 0; i < spawnNumber; i++)
        {
            GameObject item = Instantiate(InteractablePrefab);
            item.transform.position = positions[i];
        }
    }
    
    void reshuffle()
    {
        // from Knuth shuffle algorithm
        for (int i = 0; i<positions.Length; i++)
        {
            Vector2[] tmp = positions;
            int r = Random.Range(i, positions.Length);
            positions[i] = positions[r];
            positions[r] = tmp[i];
        }

    }
    void reshuffle2()
    {
        System.Random random = new System.Random();
        // from Knuth shuffle algorithm
        for (int i = 0; i < positions.Length; i++)
        {
            int r = random.Next(i, positions.Length);
            Vector2 temp = positions[i];
            positions[i] = positions[r];
            positions[r] = temp;
        }

    }

}
