using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonPersistent<LevelManager>
{
    #region Variables

    [SerializeField] private string menuSceneName;
    [SerializeField] private string creditsSceneName;

    private string currentSceneName;

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

    public void LoadLevel(string levelName)
    {
        this.currentSceneName = levelName;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    public void ReloadLevel()
    {
        if (this.currentSceneName != null)
            LoadLevel(this.currentSceneName);
    }

    public string GetCurrentScene()
    {
        return this.currentSceneName;
    }

    #endregion

    #region PrivateMethods
    #endregion
}
