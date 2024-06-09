using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Variables

    #endregion

    [SerializeField] private string playSceneName;
    [SerializeField] private string creditsSceneName;

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
        LoadCredits();
    }

    public void OnQuitButtonPressed()
    {
        QuitGame();
    }

    #endregion

    #region PrivateMethods

    private void PlayGame()
    {
        if(this.playSceneName != null)
            SceneManager.LoadScene(this.playSceneName, LoadSceneMode.Single);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void LoadCredits()
    {
        if(this.playSceneName != null)
            SceneManager.LoadScene(this.creditsSceneName, LoadSceneMode.Single);
    }

    #endregion

}
