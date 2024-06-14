using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonPersistent<LevelManager>
{
    #region Variables

    [SerializeField] private string menuSceneName;
    [SerializeField] private string creditsSceneName;
    [SerializeField] private string[] playSceneNames;

    private string currentSceneName;

    #endregion

    #region PublicGetters

    public string MenuSceneName { get { return menuSceneName; } }
    public string CreditsSceneName { get { return creditsSceneName; } }
    public string CurrentSceneName { get { return currentSceneName; } }

    public string[] PlaySceneNames { get { return playSceneNames; } }

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
    
    // Loads a level by scene name.
    public void LoadLevel(string levelName)
    {
        if (levelName == null)
            return;
        this.currentSceneName = levelName;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        print($"Successfully loaded level {levelName}");
    }

    // Reloads the current level.
    public void ReloadLevel()
    {
        if (this.currentSceneName != null)
            LoadLevel(this.currentSceneName);
    }

    // Returns the name of the current scene.
    public string GetCurrentScene()
    {
        return this.currentSceneName;
    }

    // Returns to the main menu.
    public void ReturnToMenu()
    {
        this.LoadLevel(this.menuSceneName);
    }

    #endregion

    #region PrivateMethods
    #endregion
}
