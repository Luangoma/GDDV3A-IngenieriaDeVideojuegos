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
    [SerializeField] private AsteroidType asteroidType;

    public Action<float> OnUpdate;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        if (_scriptableObjectObstacle.Target == null)
        {
            _scriptableObjectObstacle.Target = GameObject.FindWithTag("Player");
        }
    }

    void Update()
    {
        float delta = Time.deltaTime;
        FollowTarget(delta);
        OnUpdate?.Invoke(delta);
    }

    #endregion

    #region PublicMethods

    public float GetDistanceFromTarget()
    {
        return (_scriptableObjectObstacle.Target.transform.position - transform.position).magnitude;
    }

    public void FollowTarget(float delta)
    {
        Vector2 heading = _scriptableObjectObstacle.Target.transform.position - transform.position;
        float distance = heading.magnitude;
        float factor = 1 / (distance + 0.01f); // add a small value to prevent divisor from being 0.
        rigidBody.AddForce(heading.normalized * delta * _scriptableObjectObstacle.GetSpeed(asteroidType) * factor, ForceMode.VelocityChange);
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
