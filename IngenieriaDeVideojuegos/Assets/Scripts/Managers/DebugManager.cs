using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : SingletonPersistent<DebugManager>
{
    #region Variables

    [SerializeField] private bool debugEnabled = false;

    #endregion

    #region GettersAndSetters

    public bool DebugEnabled { get { return debugEnabled; } set { debugEnabled = value; } }

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
    #endregion

    #region PrivateMethods
    #endregion
}
