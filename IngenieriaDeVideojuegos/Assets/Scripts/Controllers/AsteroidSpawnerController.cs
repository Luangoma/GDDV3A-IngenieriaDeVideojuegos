using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private PooleableGameObject asteroidPrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRadiusMax;
    [SerializeField] private float spawnRadiusMin;

    private ObjectPool<PooleableGameObject> asteroidPool;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        if (asteroidPrefab == null)
            return;
        asteroidPool = new ObjectPool<PooleableGameObject>(asteroidPrefab, 100, false);
    }

    void Update()
    {
        
    }

    #endregion


}
