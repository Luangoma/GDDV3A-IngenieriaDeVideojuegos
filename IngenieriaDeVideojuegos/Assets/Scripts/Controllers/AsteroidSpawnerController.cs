using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private IPooleableObject asteroidPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRadiusMax;
    [SerializeField] private float spawnRadiusMin;

    private ObjectPool asteroidPool;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        //asteroidPool = new ObjectPool(asteroidPrefab, 100, false);
    }

    void Update()
    {
        
    }

    #endregion


}
