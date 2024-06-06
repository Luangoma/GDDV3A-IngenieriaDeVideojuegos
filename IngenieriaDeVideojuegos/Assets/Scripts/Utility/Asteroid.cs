using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System;

public class Asteroid : MonoBehaviour
{
    #region Variables

    public GameObject target;
    public float speed;
    public Action onFarFromPlayer;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        speed = 100.0f;
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector2 heading = target.transform.position-transform.position;

        // Los asteroides se mueven hacia la nave mas rapido a mas lejos estan
        float step = heading.magnitude/speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        if (heading.magnitude > 250)
        {
            onFarFromPlayer?.Invoke();
        }
    }

    #endregion

}
