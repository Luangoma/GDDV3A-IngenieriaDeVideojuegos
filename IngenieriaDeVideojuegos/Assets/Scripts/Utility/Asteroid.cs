using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Asteroid : MonoBehaviour
{
    #region Variables

    public GameObject target;
    public float speed;
    public float timeSinceActivated;
    public float lifeTime;

    #endregion

    #region MonoBehaviour

    // Start is called before the first frame update
    void Start()        // En la creacion del objeto
    {
        speed = 100.0f;
        lifeTime = 15f;
        target = GameObject.FindWithTag("Player");
    }
    void OnEnable() {   // Cada vez que se active el objeto
        timeSinceActivated = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 heading = target.transform.position-transform.position;

        // Los asteroides se mueven hacia la nave mas rapido a mas lejos estan
        float step = heading.magnitude/speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        timeSinceActivated += Time.deltaTime;

        //Desactivador por tiempo
        //if (timeSinceActivated >= lifeTime)
        //{
        //    gameObject.SetActive(false);
        //}
        // Desactivador por lejanía
        if (heading.magnitude > 250)
        {
            gameObject.SetActive(false);
        }
    }

    #endregion

    public bool GetActive()
    {
        return gameObject.activeSelf;
    }

    public void SetActive(bool newActive)
    {
        gameObject.SetActive(newActive);
    }

    public void Reset()
    {

    }

}
