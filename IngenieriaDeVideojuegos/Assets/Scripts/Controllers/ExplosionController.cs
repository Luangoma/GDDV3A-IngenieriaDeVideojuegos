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

    public void PlayAnimation()
    {
        animator?.Play("explosion");
        OnAnimationStart?.Invoke();
    }

    public void StopAnimation()
    {
        animator?.StopPlayback();
        OnAnimationStop?.Invoke();
    }

    #endregion

    #region PrivateMethods
    #endregion
}
