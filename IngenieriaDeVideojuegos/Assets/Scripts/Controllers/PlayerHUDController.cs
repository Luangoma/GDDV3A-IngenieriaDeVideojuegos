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

    private PlayerController playerController;
    private HealthController healthController;

    #endregion

    #region MonoBehaviour

    void Start()
    {
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

    public void SetPlayerReference(PlayerController player)
    {
        this.playerController = player;
        this.healthController = player.GetComponent<HealthController>();
    }

    #endregion

    #region PrivateMethods

    private bool AllComponentsAreValid()
    {
        return
            this.canvas != null &&
            this.healthBar != null &&
            this.scoreText != null &&
            this.playerController != null &&
            this.healthController != null
            ;
    }

    private void UpdateHUD(float delta)
    {
        if (!AllComponentsAreValid())
            return;
        UpdateHealthBar(delta);
        UpdateScore();
    }

    private void UpdateHealthBar(float delta)
    {
        this.healthBar.fillAmount = Mathf.Lerp(this.healthBar.fillAmount, this.healthController.GetHealthPercentage(), delta * 10);
    }

    private void UpdateScore()
    {
        this.scoreText.text = "Score : " + GameManager.Instance.GetScore();
    }

    private void UpdateTargetScore()
    {
        this.targetScoreText.text = "Target : " + GameManager.Instance.GetTargetScore();
    }

    #endregion

}
