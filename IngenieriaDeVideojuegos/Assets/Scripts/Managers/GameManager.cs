using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Variables

    [SerializeField] public PlayerController playerReference;

    private HealthController playerHealthController;

    #endregion

    #region MonoBehaviour
    
    void Start()
    {
        InitVariables();
    }

    void Update()
    {
        
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods

    private void InitVariables()
    {
        if(playerReference != null)
            playerHealthController = playerReference.GetComponent<HealthController>();
        
        if(playerHealthController != null)
            playerHealthController.OnValueChanged += OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(float oldHealth, float newHealth)
    {
        if (newHealth <= 0)
            PlayerHasDied();
    }

    private void PlayerHasDied()
    {
        HUDManager.Instance.DisplayPlayerDeath();
    }

    #endregion
}
