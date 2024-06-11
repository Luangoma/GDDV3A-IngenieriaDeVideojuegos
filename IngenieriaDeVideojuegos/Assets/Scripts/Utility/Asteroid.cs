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

    public void FollowTarget()
    {
        Vector2 heading = _scriptableObjectObstacle.target.transform.position - transform.position;

        // Los asteroides se mueven hacia la nave mas rapido a mas lejos estan
        float step = heading.magnitude / _scriptableObjectObstacle.speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _scriptableObjectObstacle.target.transform.position, step);

        if (heading.magnitude > 250)
        {
            onFarFromPlayer?.Invoke();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        OnCollideTarget();
    }
    public void OnCollideTarget()
    {
        // disminuir vida

    }

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
        FollowTarget();
    }

    #endregion

}
