using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : SingletonPersistent<DebugManager>
{
    #region Variables

    [SerializeField] private bool debugEnabled = false;

    private static bool isDebugEnabled = false;

    #endregion

    #region GettersAndSetters

    public static bool DebugEnabled { get { return isDebugEnabled; } set { isDebugEnabled = value; } }

    #endregion

    #region MonoBehaviour

    void Start()
    {
        DebugManager.isDebugEnabled = DebugManager.Instance.debugEnabled;
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
