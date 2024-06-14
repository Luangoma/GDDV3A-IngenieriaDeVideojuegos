using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuController : MonoBehaviour
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

    public void OnReturnButtonPressed()
    {
        ReturnToMenu();
    }

    #endregion

    #region PrivateMethods

    private void ReturnToMenu()
    {
        LevelManager.Instance.ReturnToMenu();
    }

    #endregion
}
