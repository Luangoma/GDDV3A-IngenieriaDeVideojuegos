using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region Variables

    private PlayerController playerReference;
    private HealthController playerHealthController;

    public ObservableVariable<int> score = new ObservableVariable<int>();
    
    [SerializeField] private int targetScore;

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
        return this.score.Value;
    }

    public void IncrementScore()
    {
        this.score.Value++;
    }

    public int GetTargetScore()
    {
        return this.targetScore;
    }

    #endregion

    #region PrivateMethods

    private void InitVariables()
    {
        this.score.Value = 0;

        this.score.OnValueChanged += OnScoreChanged;

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

    private void PlayerHasWon()
    {
        HUDManager.Instance.DisplayPlayerVictory();
    }

    private void OnScoreChanged(int oldScore, int newScore)
    {
        if (newScore >= targetScore)
        {
            PlayerHasWon();
        }
    }

    #endregion
}
