using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour, IHUD
{
    #region Variables

    [SerializeField] private Canvas canvas;

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

    public void OnResumeButtonPressed()
    {
        Resume();
    }

    public void OnReturnToMenuButtonPressed()
    {
        Resume(); // Important to resume first to unpause (reset time scale to 1) before going back to main menu. This is done automatically, but, again, done for correctness sake...
        ReturnToMenu();
    }

    public void OnQuitButtonPressed()
    {
        QuitGame();
    }

    public void OnRetryButtonPressed()
    {
        Retry();
    }

    #endregion

    #region PrivateMethods

    private void Resume()
    {
        HUDManager.Instance.Resume();
    }

    private void Retry()
    {
        Resume(); // Unpause first (doesn't matter since time scale is reset automatically, but this is done for correctness sake...)
        LevelManager.Instance.ReloadLevel();
    }

    private void ReturnToMenu()
    {
        LevelManager.Instance.ReturnToMenu();
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    #endregion

}
