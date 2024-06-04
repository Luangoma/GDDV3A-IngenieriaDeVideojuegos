using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Asteroid : MonoBehaviour
{
    public Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 heading = target.position-transform.position;
        float step = heading.magnitude/speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
