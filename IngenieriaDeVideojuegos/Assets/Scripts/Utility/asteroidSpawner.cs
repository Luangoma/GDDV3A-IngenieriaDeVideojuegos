using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMover : MonoBehaviour
{
    public GameObject asteroidPrefab;
    [SerializeField] private Camera cameraReference;
    public int tamPool = 50;
    public float spawnRate = 2.0f;
    // Falta meter un countdown de los asteroides o que si se alejan mucho desaparezcan

    private GameObject[] asteroidPool;      // Puede que en vez de gameObject aqui haya que hacer un tipo Object pool
    private Vector2 dimPantalla;


    // Start is called before the first frame update
    void Start()
    {
        asteroidPool = new GameObject[tamPool];
        for (int i = 0; i < tamPool; i++)
        {
            asteroidPool[i] = Instantiate(asteroidPrefab);
            asteroidPool[i].SetActive(false);
        }
        dimPantalla = cameraReference.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraReference.transform.position.z));
        InvokeRepeating("SpawnAsteroid", 0f, spawnRate);

    }
    void SpawnAsteroid()
    {
        for (int i = 0; i < tamPool; i++)
        {
            if (!asteroidPool[i].activeInHierarchy)
            {
                float spawnX = Random.Range(-dimPantalla.x, dimPantalla.x);
                float spawnY = Random.Range(-dimPantalla.y, dimPantalla.y);
                asteroidPool[i].transform.position = new Vector2(spawnX, spawnY);
                print("asteroide en "+spawnX+", "+spawnY);
                asteroidPool[i].SetActive(true);
                break;
            }
        }
    }
}
