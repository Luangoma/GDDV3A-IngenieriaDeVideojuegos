using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthController : MonoBehaviour
{
    #region Variables

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public Action<float, float> OnValueChanged;
    public Action OnDeath;

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

    public void SetHealth(float health)
    {
        float oldValue = this.currentHealth;
        this.currentHealth = Mathf.Clamp(health, 0, maxHealth);
        OnValueChanged?.Invoke(oldValue, currentHealth);
        if (this.IsDead())
            OnDeath?.Invoke();
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

    public bool IsAlive()
    {
        return this.currentHealth > 0;
    }

    public bool IsDead()
    {
        return this.currentHealth <= 0;
    }

    #endregion

    #region PrivateMethods
    #endregion

}
