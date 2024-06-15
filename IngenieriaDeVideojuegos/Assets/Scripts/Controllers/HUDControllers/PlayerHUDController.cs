using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour, IHUD
{
    #region Variables

    [Header("Canvas Data")]
    [SerializeField] private Canvas canvas;

    [Header("HUD Health Data")]
    [SerializeField] private Image healthBar;

    [Header("HUD Score Data")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text targetScoreText;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        InitObservers();
        UpdateScore(0);
        UpdateTargetScore();
    }

    void Update()
    {
        UpdateHUD(Time.deltaTime);
    }

    #endregion

    #region PublicMethods

    public bool GetVisible()
    {
        return this.canvas.gameObject.activeSelf;
    }

    public void SetVisible(bool visible)
    {
        this.canvas.gameObject.SetActive(visible);
    }

    #endregion

    #region PrivateMethods

    private bool AllComponentsAreValid()
    {
        return
            HUDManager.Instance != null &&
            HUDManager.Instance.GetPlayerController() != null &&
            HUDManager.Instance.GetHealthController() != null &&
            this.canvas != null &&
            this.healthBar != null &&
            this.scoreText != null
            ;
    }

    private void UpdateHUD(float delta)
    {
        if (!AllComponentsAreValid())
            return;
        UpdateHealthBar(delta);
    }

    private void UpdateHealthBar(float delta)
    {
        this.healthBar.fillAmount = Mathf.Lerp(this.healthBar.fillAmount, HUDManager.Instance.GetHealthController().GetHealthPercentage(), delta * 10);
    }

    private void UpdateScore(int score)
    {
        this.scoreText.text = "Score : " + score;
    }

    private void UpdateTargetScore()
    {
        this.targetScoreText.text = "Target : " + GameManager.Instance.GetTargetScore();
    }

    private void InitObservers()
    {
        GameManager.Instance.score.OnValueChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int oldScore, int newScore)
    {
        UpdateScore(newScore);
    }

    #endregion

}
