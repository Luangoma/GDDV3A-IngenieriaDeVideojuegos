using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletSpawnerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxBullets = 20;
    [SerializeField] private Transform[] bulletSpawnTransformList;

    private ObjectPool<GameObject> bulletPool;
    private int transformIdx = 0;

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
        if (this.bulletSpawnTransformList.Length < 1)
            return;
        int idx = NextTransformIdx();
        obj.GetObject().transform.position = bulletSpawnTransformList[idx].position;
        obj.GetObject().transform.rotation = bulletSpawnTransformList[idx].rotation;
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

    private int NextTransformIdx()
    {
        this.transformIdx = (this.transformIdx + 1) % this.bulletSpawnTransformList.Length;
        return this.transformIdx;
    }

    #endregion
}
