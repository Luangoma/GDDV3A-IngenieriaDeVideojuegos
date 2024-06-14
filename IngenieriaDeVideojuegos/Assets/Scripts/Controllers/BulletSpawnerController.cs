using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxBullets = 20;
    [SerializeField] private Transform bulletSpawnTransform;

    private ObjectPool<GameObject> bulletPool;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        this.Init();
    }

    void Update()
    {
        
    }

    #endregion

    #region PublicMethods

    public void SpawnBullet()
    {
        this.bulletPool.Get();
    }

    #endregion

    #region PrivateMethods

    private void Init()
    {
        if (this.bulletPrefab != null)
            this.bulletPool = new ObjectPool<GameObject>(OnCreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, this.maxBullets, this.maxBullets, true);
    }

    private GameObject OnCreateBullet()
    {
        GameObject bullet = ObjectSpawner.SpawnGameObject(this.bulletPrefab, false);
        return bullet;
    }

    private void OnGetBullet(IPooleableObject<GameObject> obj)
    {
        if (this.bulletSpawnTransform == null)
            return;
        obj.GetObject().transform.position = bulletSpawnTransform.position;
        obj.GetObject().transform.rotation = bulletSpawnTransform.rotation;
        obj.GetObject().SetActive(true);
        obj.GetObject().GetComponent<BulletController>().OnDespawnBullet = () => { this.bulletPool.Release(obj); };
    }

    private void OnReleaseBullet(IPooleableObject<GameObject> obj)
    {
        obj.GetObject().SetActive(false);
        obj.GetObject().GetComponent<BulletController>().OnDespawnBullet = null;
    }

    private void OnDestroyBullet(IPooleableObject<GameObject> obj)
    {
        obj.GetObject().SetActive(false);
        Destroy(obj.GetObject());
    }

    #endregion
}
