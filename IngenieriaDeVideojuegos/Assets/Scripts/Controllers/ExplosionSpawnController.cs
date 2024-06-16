using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionSpawnController : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int initialCapacity = 100;
    [SerializeField] private int maxCapacity = 200;

    private ObjectPool<GameObject> explosionPool;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        if (explosionPrefab == null)
            return;
        explosionPool = new ObjectPool<GameObject>(OnCreateExplosion, OnGetExplosion, OnReleaseExplosion, OnDestroyExplosion, initialCapacity, maxCapacity, true);
    }

    #endregion

    #region PublicMethods

    public void SpawnExplosion(Vector3 position)
    {
        var pooleableObject = explosionPool.Get();
        var gameObject = pooleableObject.GetObject();
        gameObject.transform.position = position;
    }

    #endregion

    #region ObjectPoolCallbacks

    private GameObject OnCreateExplosion()
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.SetActive(false);
        return explosion;
    }

    private void OnGetExplosion(IPooleableObject<GameObject> obj)
    {
        obj.GetObject().SetActive(true);

        ExplosionController explosionController = gameObject.GetComponent<ExplosionController>();
        explosionController.PlayAnimation();
        explosionController.OnAnimationStop = () => {
            explosionPool.Release(obj);
        };
    }

    private void OnReleaseExplosion(IPooleableObject<GameObject> obj)
    {
        obj.GetObject().SetActive(false);
    }

    private void OnDestroyExplosion(IPooleableObject<GameObject> obj)
    {
        obj.GetObject().SetActive(false);
        Destroy(obj.GetObject());
    }

    #endregion

}
