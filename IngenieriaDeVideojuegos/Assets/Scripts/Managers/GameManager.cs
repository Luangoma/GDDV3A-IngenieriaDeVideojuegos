using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Variables

    private PlayerController playerReference;
    private HealthController playerHealthController;

    private int score;

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

    public int GetScore()
    {
        return this.score;
    }

    public void IncrementScore()
    {
        this.score++;
    }

    #endregion

    #region PrivateMethods

    private void InitVariables()
    {
        this.score = 0;

        GameObject obj = GameObject.FindWithTag("Player");

        if (obj != null)
            playerReference = obj.GetComponent<PlayerController>();

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
