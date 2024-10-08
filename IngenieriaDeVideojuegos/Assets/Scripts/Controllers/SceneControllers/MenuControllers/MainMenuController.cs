using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Variables

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

    public void OnPlayButtonPressed()
    {
        PlayGame();
    }

    public void OnCreditsButtonPressed()
    {
        LoadCreditsMenu();
    }

    public void OnQuitButtonPressed()
    {
        QuitGame();
    }

    #endregion

    #region PrivateMethods

    private void PlayGame()
    {
        LevelManager.Instance.LoadLevel(LevelManager.Instance.LevelSelectSceneName);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void LoadCreditsMenu()
    {
        LevelManager.Instance.LoadLevel(LevelManager.Instance.CreditsSceneName);
    }

    #endregion

}
