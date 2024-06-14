using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    #region Variables

    [SerializeField] private float damage;
    
    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region PublicMethods

    public void OnTriggerEnter(Collider other)
    {
        bool success;
        HealthController healthController;
        success = other.TryGetComponent<HealthController>(out healthController);

        if (!success) // If the hit object does not have a health component, then don't apply damage.
            return;

        healthController.Damage(damage);

        print($"Collided with a damageable object and dealt {damage} points of damage");
    }

    #endregion

    #region PrivateMethods
    #endregion

}
