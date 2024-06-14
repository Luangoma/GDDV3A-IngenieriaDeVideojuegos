using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
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

    public void OnReturnToMenuButtonPressed()
    {
        ReturnToMenu();
    }

    #endregion

    #region PrivateMethods

    private void ReturnToMenu()
    {
        LevelManager.Instance?.ReturnToMenu();
    }

    #endregion

}
