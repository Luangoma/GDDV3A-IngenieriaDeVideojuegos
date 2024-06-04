using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMover : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int tamPool = 5;

    private GameObject[] asteroidPool;

    // Start is called before the first frame update
    void Start()
    {
        asteroidPool = new GameObject[tamPool];
        for (int i = 0; i < tamPool; i++)
        {
            asteroidPool[i] = Instantiate(asteroidPrefab);
            //asteroidPool[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
