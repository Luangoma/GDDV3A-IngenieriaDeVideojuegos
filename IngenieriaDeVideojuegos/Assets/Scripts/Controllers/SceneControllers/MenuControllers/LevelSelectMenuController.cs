using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenuController : MonoBehaviour
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

    public void OnLevelButtonPressed(int level)
    {
        LoadPlayLevel(level);
    }

    public void OnReturnToMenuPressed()
    {
        ReturnToMenu();
    }

    #endregion

    #region PrivateMethods

    private void LoadPlayLevel(int level)
    {
        string levelName = LevelManager.Instance.PlaySceneNames[Mathf.Clamp(level, 1, LevelManager.Instance.PlaySceneNames.Length) - 1];
        LevelManager.Instance.LoadLevel(levelName);
    }

    private void ReturnToMenu()
    {
        LevelManager.Instance.ReturnToMenu();
    }

    #endregion
}
