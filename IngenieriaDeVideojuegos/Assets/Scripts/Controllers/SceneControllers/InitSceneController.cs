using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSceneController : MonoBehaviour
{
    #region Variables
    #endregion

    #region MonoBehaviour

    void Awake()
    {
        
    }

    void Start()
    {
        LevelManager.Instance.ReturnToMenu();
    }

    void Update()
    {
        
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods
    #endregion
}
