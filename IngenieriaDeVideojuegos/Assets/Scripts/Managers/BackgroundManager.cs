using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private BackgroundController background;
    [SerializeField] private Transform followTarget;
    [SerializeField] private UpdateType updateType;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        if (updateType == UpdateType.Update)
            UpdateBackground(Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (updateType == UpdateType.FixedUpdate)
            UpdateBackground(Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        if (updateType == UpdateType.LateUpdate)
            UpdateBackground(Time.deltaTime);
    }

    #endregion

    #region PublicMethods

    #endregion

    #region PrivateMethods

    private void UpdateBackground(float delta)
    {
        background.SetBackgroundOffset(followTarget.position, delta);
    }

    #endregion
}
