using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryHUDController : MonoBehaviour, IHUD
{
    #region Variables

    [Header("HUD Data")]
    [SerializeField] private Canvas canvas;

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

    public void OnReturnToMenuButtonPressed()
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
