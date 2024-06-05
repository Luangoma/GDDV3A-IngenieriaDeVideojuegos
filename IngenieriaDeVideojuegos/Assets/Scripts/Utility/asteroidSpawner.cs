using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMover : MonoBehaviour
{
    public GameObject asteroidPrefab;
    [SerializeField] private Camera cameraReference;
    public GameObject player;
    public int tamPool = 50;
    public float spawnRate = 0.1f;
    public float maxrSpawn = 100f;
    public float minrSpawn = 20f;
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
        
        InvokeRepeating("SpawnAsteroid", 0f, spawnRate);    // Invocar meteoritos de forma indefinida en base a spawnRate

    }
    void SpawnAsteroid()
    {
        
        for (int i = 0; i < tamPool; i++)
        {
            if (!asteroidPool[i].activeInHierarchy)
            {
                float playerX = player.transform.position.x, playerY = player.transform.position.y, playerZ = player.transform.position.z; ;
                float spawnX=0, spawnY=0, spawnZ=0;
                
                
                if (Random.Range(0f, 1f) < 0.5f)
                {
                    spawnX = Random.Range(playerX+ minrSpawn, playerX+ maxrSpawn);
                }
                else {
                    spawnX = Random.Range(playerX- maxrSpawn, playerX- minrSpawn);
                }
                if (Random.Range(0f, 1f) < 0.5f) {
                    spawnY = Random.Range(playerY+ minrSpawn, playerY+ maxrSpawn);
                } else { 
                    spawnY = Random.Range(playerY- maxrSpawn, playerY- minrSpawn);
                }
                spawnZ = player.transform.position.z;

                // Podría tenerse tambien en cuenta la velocidad del jugador al posicionarlos
                asteroidPool[i].transform.position = new Vector3(spawnX, spawnY, spawnZ);   
                print("asteroide en "+spawnX+", "+spawnY);
                asteroidPool[i].SetActive(true);
                break;
            }
        }
    }
}
