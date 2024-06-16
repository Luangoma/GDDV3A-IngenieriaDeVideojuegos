using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    #region Variables

    [SerializeField] private AsteroidSpawnerController asteroidSpawnController;
    [SerializeField] private BulletSpawnerController bulletSpawnController;
    [SerializeField] private ExplosionSpawnController explosionSpawnController;

    #endregion

    #region Getters

    public AsteroidSpawnerController AsteroidSpawner { get { return asteroidSpawnController; } }

    public BulletSpawnerController BulletSpawner { get { return bulletSpawnController; } }

    public ExplosionSpawnController ExplosionSpawner { get { return explosionSpawnController; } }

    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods
    #endregion
}
