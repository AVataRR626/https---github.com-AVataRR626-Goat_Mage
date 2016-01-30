using UnityEngine;
using System.Collections;

public enum UIState {MainMenu, GameHud, Pause, GameOver}

public class UIManager : Singleton<UIManager>
{
    // guarantee this will be always a singleton only - can't use the constructor!
    protected UIManager() { }

    public GameObject MainMenuPanel;
    public GameObject GameHudPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    public UIState State;

    #region Blurring
    private BlurMainCamera BluringScript
    {
        get
        {
            var result = gameObject.GetComponent<BlurMainCamera>() ?? gameObject.AddComponent<BlurMainCamera>();
            result.FadeDuration = BlurFadeDuration;
            return result;
        }
    }
    public bool BlurBackgrounds = true;
    [Range(0,5)]
    public float BlurFadeDuration = 1.0f;
    #endregion

    private void SetState(UIState newState)
    {
        DeactivateAllPanels();
        switch (newState)
            {
                case UIState.MainMenu:
                    MainMenuPanel.SetActive(true);
                    if(BlurBackgrounds) BluringScript.Blur();
                    Time.timeScale = 0.0f;
                break;
                case UIState.GameHud:
                    GameHudPanel.SetActive(true);
                    BluringScript.UnBlur();
                    Time.timeScale = 1.0f;
                break;
                case UIState.Pause:
                    PausePanel.SetActive(true);
                    if (BlurBackgrounds) BluringScript.Blur();
                    Time.timeScale = 0.0f;
                break;
                case UIState.GameOver:
                    GameOverPanel.SetActive(true);
                    if (BlurBackgrounds) BluringScript.Blur();
                    Time.timeScale = 0.0f;
                break;
            }
        State = newState;
        
    }

    private void DeactivateAllPanels()
    {
        MainMenuPanel.SetActive(false);
        GameHudPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    [ContextMenu("Pause")]
    public void Pause()
    {
        SetState(UIState.Pause);
    }

    [ContextMenu("UnPause")]
    public void UnPause()
    {
        if(State == UIState.Pause)
        SetState(UIState.GameHud);
    }

    [ContextMenu("New Game")]
    public void NewGame()
    {
        DeactivateAllPanels();
        SetState(UIState.GameHud);
        //TODO GameManager.Instance.NewGame();
    }

    [ContextMenu("Return To Main Menu")]
    public void ReturnToMainMenu()
    {
        DeactivateAllPanels();
        SetState(UIState.MainMenu);
        //TODO GameManager.Instance.EndGame();
    }
}
