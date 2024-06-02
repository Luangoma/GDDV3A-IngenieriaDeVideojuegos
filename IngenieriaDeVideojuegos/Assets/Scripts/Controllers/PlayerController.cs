using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private float linearAcceleration;
    [SerializeField] private float angularAcceleration;
    
    [SerializeField] private float maxLinearVelocity;
    [SerializeField] private float maxAngularVelocity;

    private Vector2 movementVector;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        UpdateMovement(Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods

    private void GetInput()
    {
        movementVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) movementVector.x += 1;
        if (Input.GetKey(KeyCode.S)) movementVector.x -= 1;

        if (Input.GetKey(KeyCode.D)) movementVector.y += 1;
        if (Input.GetKey(KeyCode.A)) movementVector.y -= 1;
    }

    private void UpdateMovement(float delta)
    {
        if (this.rigidBody.velocity.magnitude < this.maxLinearVelocity)
            this.rigidBody.AddForce(delta * this.movementVector.x * this.transform.up * this.linearAcceleration, ForceMode.VelocityChange);

        if (this.rigidBody.angularVelocity.magnitude < this.maxAngularVelocity)
        {
            this.rigidBody.AddTorque(delta * (-1 * this.movementVector.y) * this.transform.forward * this.angularAcceleration, ForceMode.VelocityChange);
            this.rigidBody.AddForce(delta * this.movementVector.y * this.movementVector.x * this.transform.right * (this.linearAcceleration / 2), ForceMode.VelocityChange);
        }
    }

    #endregion

}
