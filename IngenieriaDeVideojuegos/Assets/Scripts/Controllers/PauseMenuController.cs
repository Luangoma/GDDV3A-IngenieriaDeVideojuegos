using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    #region Variables

    [SerializeField] private string menuSceneName;

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

    public void OnResumeButtonPressed()
    {
        Resume();
    }

    public void OnReturnToMenuButtonPressed()
    {
        Resume(); // important to resume first to unpause (reset time scale to 1) before going back to main menu.
        ReturnToMenu();
    }

    public void OnQuitButtonPressed()
    {
        QuitGame();
    }
    
    #endregion

    #region PrivateMethods

    private void Resume()
    {
        HUDManager.Instance.Resume();
    }

    private void ReturnToMenu()
    {
        if(this.menuSceneName != null)
            SceneManager.LoadScene(this.menuSceneName, LoadSceneMode.Single);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    #endregion

}
