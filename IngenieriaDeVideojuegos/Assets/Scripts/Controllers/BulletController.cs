using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Variables

    [SerializeField] private float velocity = 100;
    [SerializeField] private float despawnTime = 10.0f;

    public Action OnDespawnBullet;

    private float elapsedTime = 0.0f;

    #endregion

    #region MonoBehaviour
    
    void Start()
    {
        
    }

    void Update()
    {
        float delta = Time.deltaTime;
        UpdateBulletPosition(delta);
        UpdateBulletLifetime(delta);
    }

    #endregion

    #region PublicMethods

    public void OnTriggerEnter(Collider other)
    {
        print("bullet has collided!!!!!");
    }

    #endregion

    #region PrivateMethods

    private void UpdateBulletPosition(float delta)
    {
        this.transform.position += this.transform.up * velocity * delta;
    }

    private void UpdateBulletLifetime(float delta)
    {
        this.elapsedTime += delta;
        if (elapsedTime >= despawnTime)
        {
            this.elapsedTime = 0;
            this.OnDespawnBullet?.Invoke();
        }
    }

    #endregion

}
