using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Image healthBar;
    [SerializeField] private HealthController healthController;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        UpdateHealthBar(Time.deltaTime);
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods

    private void UpdateHealthBar(float delta)
    {
        this.healthBar.fillAmount = Mathf.Lerp(this.healthBar.fillAmount, this.healthController.GetHealthPercentage(), delta * 10);
    }

    #endregion

}
