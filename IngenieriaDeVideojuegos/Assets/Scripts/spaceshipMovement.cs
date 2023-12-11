using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipMovement : MonoBehaviour
{
    public float speed=1;
    public float horizontalMove;
    public float verticalMove;
    public CharacterController ship;
    public float horizontalInercia = 0;
    public float verticalInercia = 0;
    public float maxHorizontalMove = 0;
    public float maxVerticalMove = 0;
    void Start()
    {
        ship = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        // Lógica horizontal

        if (horizontalMove > 0 && maxHorizontalMove < 1.5f)
        {
            maxHorizontalMove += 0.01f * horizontalMove;        // Restamos la diferencia al máximo
            horizontalInercia = maxHorizontalMove;
            Vector3 rotation = transform.eulerAngles;
            rotation.z = 270f;
            //rotation.z = Mathf.Min(rotation.z, 270f);
            transform.eulerAngles = rotation;

        }
        else if (horizontalMove < 0 && maxHorizontalMove > -1.5f)
        {
            maxHorizontalMove += 0.01f * horizontalMove;        // Restamos la diferencia al máximo
            horizontalInercia = maxHorizontalMove;
            Vector3 rotation = transform.eulerAngles;
            rotation.z = 90f;
            transform.eulerAngles = rotation;
        }
        else
        {
            //horizontalInercia = maxHorizontalMove;        // No es necesario porque horizontalInercia ya tiene el valor del maxHorizontalMove de la ùltima iteración
        }

        // Lógica vertical

        if (verticalMove != 0 && maxHorizontalMove < 1.5f)
        {
            maxVerticalMove += 0.01f * verticalMove;        // Restamos la diferencia al máximo
            verticalInercia = maxVerticalMove;

        }
        else
        {
            verticalInercia = maxVerticalMove;
        }
        
        ship.Move(new Vector3(horizontalInercia * speed, verticalInercia * speed, 0));
    }
}
