using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathHUDController : MonoBehaviour, IHUD
{
    #region Variables

    [SerializeField] private Canvas canvas;
    [SerializeField] private Image backgroundImage;

    private PlayerController playerController;

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
    }

    public void OnReturnToMenuButtonPressed()
    {
        ReturnToMenu();
    }

    public void OnRetryButtonPressed()
    {
        Retry();
    }

    #endregion

    #region PrivateMethods

    private void ReturnToMenu()
    {
        LevelManager.Instance.ReturnToMenu();
    }

    private void Retry()
    {
        LevelManager.Instance.ReloadLevel();
    }

    #endregion

}
