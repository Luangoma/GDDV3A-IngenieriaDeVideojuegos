using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryHUDController : MonoBehaviour, IHUD
{
    #region Variables

    [Header("HUD Data")]
    [SerializeField] private Canvas canvas;


    private PlayerController playerController;

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

    public void SetVisible(bool visible)
    {
        this.canvas.gameObject.SetActive(visible);
    }

    public bool GetVisible()
    {
        return this.canvas.gameObject.activeSelf;
    }

    public void SetPlayerReference(PlayerController playerReference)
    {
        this.playerController = playerReference;
    }

    #endregion

    #region PrivateMethods
    #endregion
}
