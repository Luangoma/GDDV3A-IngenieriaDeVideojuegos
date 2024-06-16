using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Animator animator;

    public Action OnAnimationStart;
    public Action OnAnimationStop;

    private float elapsedTime = 0.0f;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        UpdateAnimationTime(Time.deltaTime);
        if (DebugManager.DebugEnabled && Input.GetKeyDown(KeyCode.K)) PlayAnimation();
    }

    #endregion

    #region PublicMethods

    public void PlayAnimation()
    {
        animator?.Play("Base Layer.explosion");
        OnAnimationStart?.Invoke();
    }

    public void StopAnimation()
    {
        animator?.StopPlayback();
        OnAnimationStop?.Invoke();
    }

    #endregion

    #region PrivateMethods

    private void UpdateAnimationTime(float delta)
    {
        elapsedTime += delta;
        if (elapsedTime > 1.8f)
        {
            StopAnimation();
            elapsedTime = 0.0f;
        }
    }

    #endregion
}
