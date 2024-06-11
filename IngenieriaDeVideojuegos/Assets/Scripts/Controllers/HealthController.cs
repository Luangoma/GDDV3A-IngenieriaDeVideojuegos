using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    #region Variables

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) this.Damage(10);
        if (Input.GetKeyDown(KeyCode.O)) this.Heal(10);
    }

    #endregion

    #region PublicMethods

    public void SetHealth(float health)
    {
        this.currentHealth = Mathf.Clamp(health, 0, maxHealth);
    }

    public float GetHealth()
    {
        return this.currentHealth;
    }

    public float GetMaxHealth()
    {
        return this.maxHealth;
    }

    public float GetHealthPercentage()
    {
        if (this.maxHealth == 0)
            return 0;
        return this.currentHealth / this.maxHealth;
    }

    public void Damage(float damage)
    {
        if (damage < 0)
            damage *= -1;
        this.SetHealth(this.currentHealth - damage);
    }

    public void Heal(float heal)
    {
        if (heal < 0)
            heal *= -1;
        this.SetHealth(this.currentHealth + heal);
    }

    #endregion

    #region PrivateMethods
    #endregion

}
