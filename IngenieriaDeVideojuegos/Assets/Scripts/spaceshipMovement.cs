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

        if (maxHorizontalMove > horizontalMove && horizontalMove > 0)   //
        {
            horizontalInercia = maxHorizontalMove;
        }
        else
        if (maxHorizontalMove < horizontalMove && horizontalMove > 0)
        {
            maxHorizontalMove += 0.01f * horizontalMove;        // Restamos la diferencia al máximo
            horizontalInercia = maxHorizontalMove;

        }
        else
        if (maxHorizontalMove > horizontalMove && horizontalMove < 0)
        {
            maxHorizontalMove += 0.01f * horizontalMove;        // Restamos la diferencia al máximo
            horizontalInercia = maxHorizontalMove;
        }
        else
        if (maxHorizontalMove < horizontalMove && horizontalMove < 0)
        {
            horizontalInercia = maxHorizontalMove;
        }

        // Lógica vertical

        if (maxVerticalMove > verticalMove && verticalMove > 0)   //
        {
            verticalInercia = maxVerticalMove;
        }
        else
        if (maxVerticalMove < verticalMove && verticalMove > 0)
        {
            maxVerticalMove += 0.01f * verticalMove;        // Restamos la diferencia al máximo
            verticalInercia = maxVerticalMove;

        }
        else
        if (maxVerticalMove > verticalMove && verticalMove < 0)
        {
            maxVerticalMove += 0.01f * verticalMove;        // Restamos la diferencia al máximo
            verticalInercia = maxVerticalMove;
        }
        else
        if (maxVerticalMove < verticalMove && verticalMove < 0)
        {
            verticalInercia = maxVerticalMove;
        }

        ship.Move(new Vector3(horizontalInercia * speed, verticalInercia * speed, 0));
    }
}
