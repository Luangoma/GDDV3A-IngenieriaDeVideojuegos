using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System;
using UnityEngine.Pool;

public class Asteroid : MonoBehaviour, IObstacle
{
    #region Variables

    [SerializeField] public ScriptableObjectObstacle _scriptableObjectObstacle;
    [SerializeField] private Rigidbody rigidBody;

    public Action OnFarFromPlayer;

    #endregion

    #region MonoBehaviour

    void Start()
    {
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
        float distance = heading.magnitude;
        float factor = 1 / (distance + 0.01f); // add a small value to prevent divisor from being 0.

        rigidBody.AddForce(heading.normalized * delta * _scriptableObjectObstacle.speed * factor, ForceMode.VelocityChange);


        if (distance > 250)
        {
            OnFarFromPlayer?.Invoke();
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
