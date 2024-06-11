using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathHUDController : MonoBehaviour, IHUD
{
    #region Variables

    [SerializeField] private Canvas canvas;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private string menuSceneName;

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

    public bool GetVisible()
    {
        return this.canvas.gameObject.activeSelf;
    }

    public void SetVisible(bool visible)
    {
        this.canvas.gameObject.SetActive(visible);
    }

    public void OnReturnToMenuButtonPressed()
    {
        ReturnToMenu();
    }

    #endregion

    #region PrivateMethods

    private void ReturnToMenu()
    {
        if (this.menuSceneName != null)
            SceneManager.LoadScene(this.menuSceneName, LoadSceneMode.Single);
    }

    #endregion

}
