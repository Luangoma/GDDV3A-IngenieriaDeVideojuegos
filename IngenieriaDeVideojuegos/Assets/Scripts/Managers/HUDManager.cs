using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : Singleton<HUDManager>
{
    #region Variables

    [SerializeField] private PlayerHUDController playerHUD;
    [SerializeField] private PauseMenuController pauseMenuHUD;
    [SerializeField] private DeathHUDController deathHUD;
    [SerializeField] private VictoryHUDController victoryHUD;

    private bool isPaused = false;
    private bool canPause = true;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        HideAllHUDs();
        Resume();
    }

    void Update()
    {
        if (canPause && Input.GetKeyDown(KeyCode.Escape)) SwitchPauseMenu();
    }

    #endregion

    #region PublicMethods

    public void Resume()
    {
        print("Resume");
        Time.timeScale = 1.0f;
        this.playerHUD?.SetVisible(true);
        this.pauseMenuHUD?.SetVisible(false);
        isPaused = false;
    }

    public void Pause()
    {
        print("Pause");
        Time.timeScale = 0;
        this.playerHUD?.SetVisible(false);
        this.pauseMenuHUD?.SetVisible(true);
        isPaused = true;
    }

    public void DisplayPlayerDeath()
    {
        this.canPause = false;
        Resume();
        HideAllHUDs();
        deathHUD.SetVisible(true);
    }

    public void DisplayPlayerVictory()
    {
        this.canPause = false;
        Resume();
        HideAllHUDs();
        victoryHUD.SetVisible(true);
    }

    public void AttachHUDS(PlayerController player)
    {
        this.playerHUD?.SetPlayerReference(player);
        this.pauseMenuHUD?.SetPlayerReference(player);
        this.deathHUD?.SetPlayerReference(player);
        this.victoryHUD?.SetPlayerReference(player);
    }

    #endregion

    #region PrivateMethods

    private void HideAllHUDs()
    {
        this.playerHUD?.SetVisible(false);
        this.pauseMenuHUD?.SetVisible(false);
        this.deathHUD?.SetVisible(false);
        this.victoryHUD?.SetVisible(false);
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

}
