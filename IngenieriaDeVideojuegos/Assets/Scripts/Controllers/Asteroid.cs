using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System;

public class Asteroid : MonoBehaviour, IObstacle
{
    #region Variables

    [Header("Scriptable Object Shared Data")]
    [SerializeField] public ScriptableObjectObstacle _scriptableObjectObstacle;

    [Header("Components")]
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private SpriteRenderer spriteOn;
    [SerializeField] private SpriteRenderer spriteOff;

    [Header("Obstacle Type Data")]
    [SerializeField] private AsteroidType asteroidType;

    public Action<float> OnUpdate;

    private float elapsedTime = 0.0f;

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
        ObstacleBehaviour(delta);
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

    public void SetType(AsteroidType type)
    {
        UpdateType(type);
    }

    public void SetRandomType()
    {
        AsteroidType chosenType = (AsteroidType)UnityEngine.Random.Range((int)(AsteroidType.Default) + 1, (int)(AsteroidType.NUM_TYPES));
        SetType(chosenType);
    }

    #endregion

    #region PrivateMethods

    private void UpdateType(AsteroidType type)
    {
        this.asteroidType = type;
        this.spriteOn.sprite = _scriptableObjectObstacle.GetSpriteOn(type);
        this.spriteOff.sprite = _scriptableObjectObstacle.GetSpriteOff(type);
    }

    private void ObstacleBehaviour(float delta)
    {
        elapsedTime += delta;
        if (this.asteroidType == AsteroidType.Projectile && elapsedTime >= 5.0f)
        {
            elapsedTime -= 5.0f;
            Vector3 dir = (_scriptableObjectObstacle.Target.transform.position - transform.position).normalized;
            rigidBody.AddForce(dir * delta * _scriptableObjectObstacle.GetSpeed(asteroidType) * 12, ForceMode.VelocityChange);
            print("GIVING A LIL PUSH!");
        }
    }

    #endregion

}
