using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System;
using UnityEngine.Pool;

public class Asteroid : MonoBehaviour, IObstacle
{
    #region Variables

    public ScriptableObjectObstacle _scriptableObjectObstacle;
    public Action onFarFromPlayer;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        //speed = 100.0f;
        if (_scriptableObjectObstacle.target == null)
        {
            _scriptableObjectObstacle.target = GameObject.FindWithTag("Player");
        }
    }

    void Update()
    {
        FollowTarget(Time.deltaTime);
    }

    #endregion

    #region PublicMethods

    public void FollowTarget(float delta)
    {
        Vector2 heading = _scriptableObjectObstacle.target.transform.position - transform.position;

        // Los asteroides se mueven hacia la nave mas rapido a mas lejos estan
        float step = heading.magnitude / _scriptableObjectObstacle.speed * delta;
        transform.position = Vector3.MoveTowards(transform.position, _scriptableObjectObstacle.target.transform.position, step);

        if (heading.magnitude > 250)
        {
            onFarFromPlayer?.Invoke();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        OnCollideTarget(collision);
    }
    public void OnCollideTarget(Collision collision)
    {
        // Disminuir vida del jugador al colisionar.

        bool success;
        HealthController healthController;

        success = collision.gameObject.TryGetComponent<HealthController>(out healthController);
        
        if (!success)
            return; // The collided object does not have a health component, so we return, since we cannot damage the object.

        float impactVelocity = collision.relativeVelocity.magnitude;

        if(impactVelocity > 12)
            healthController.Damage(impactVelocity / 5);
    }


    #endregion

}
