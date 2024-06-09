using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : Singleton<HUDManager>
{
    #region Variables

    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject pauseMenuHUD;

    private bool isPaused = false;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SwitchPauseMenu();
    }

    #endregion

    #region PublicMethods

    public void Resume()
    {
        print("Resume");
        this.playerHUD?.SetActive(true);
        this.pauseMenuHUD?.SetActive(false);
        isPaused = false;
    }

    private void Pause()
    {
        print("Pause");
        this.playerHUD?.SetActive(false);
        this.pauseMenuHUD?.SetActive(true);
        isPaused = true;
    }

    private void SwitchPauseMenu()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    #endregion

    #region PrivateMethods
    #endregion

}
