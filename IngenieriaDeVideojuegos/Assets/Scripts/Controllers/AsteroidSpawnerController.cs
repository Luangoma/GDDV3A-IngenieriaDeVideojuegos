using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private PlayerController playerReference;
    [SerializeField] private int initialCapacity = 100;
    [SerializeField] private int maxCapacity = 200;
    [SerializeField] private float spawnRate = 0.5f;
    [SerializeField] private float spawnRadiusMax = 100.0f;
    [SerializeField] private float spawnRadiusMin = 20.0f;

    private ObjectPool<GameObject> asteroidPool;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        if (asteroidPrefab == null || playerReference == null)
            return;
        asteroidPool = new ObjectPool<GameObject>(CreateAsteroid, OnGetAsteroid, OnReleaseAsteroid, DestroyAsteroid, initialCapacity, maxCapacity, true);
        InvokeRepeating("SpawnAsteroid", 0.0f, spawnRate);
    }

    #endregion

    #region PrivateMethods

    void SpawnAsteroid()
    {
        // print("spawning");
        asteroidPool.Get();
    }

    #endregion

    #region ObjectPoolCallbacks

    private GameObject CreateAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab);
        asteroid.SetActive(false);
        return asteroid;
    }

    private void OnGetAsteroid(IPooleableObject<GameObject> obj)
    {
        Vector3 playerPosition = playerReference.transform.position;
        Vector3 spawnPosition = playerPosition;

        /*
        float signX = Random.Range(0, 1) < 0.5 ? 1.0f : -1.0f;
        float signY = Random.Range(0, 1) < 0.5 ? 1.0f : -1.0f;

        float offsetX = Random.Range(spawnRadiusMin, spawnRadiusMax) * signX;
        float offsetY = Random.Range(spawnRadiusMin, spawnRadiusMax) * signY;

        spawnPosition.x += offsetX;
        spawnPosition.y += offsetY;
        */

        
        if (Random.Range(0f, 1f) < 0.5f)
        {
            spawnPosition.x = Random.Range(playerPosition.x + spawnRadiusMin, playerPosition.x + spawnRadiusMax);
        }
        else
        {
            spawnPosition.x = Random.Range(playerPosition.x - spawnRadiusMax, playerPosition.x - spawnRadiusMin);
        }
        if (Random.Range(0f, 1f) < 0.5f)
        {
            spawnPosition.y = Random.Range(playerPosition.y + spawnRadiusMin, playerPosition.y + spawnRadiusMax);
        }
        else
        {
            spawnPosition.y = Random.Range(playerPosition.y - spawnRadiusMax, playerPosition.y - spawnRadiusMin);
        }
        

        obj.GetObject().transform.position = spawnPosition;

        Asteroid asteroid = obj.GetObject().GetComponent<Asteroid>();
        if (asteroid != null)
            asteroid.onFarFromPlayer = () => { asteroidPool.Release(obj); };

        obj.GetObject().SetActive(true);
    }

    private void OnReleaseAsteroid(IPooleableObject<GameObject> obj)
    {
        obj.GetObject().SetActive(false);
    }

    private void DestroyAsteroid(IPooleableObject<GameObject> obj)
    {
        obj.GetObject().SetActive(false);
        Destroy(obj.GetObject());
    }

    #endregion

}
