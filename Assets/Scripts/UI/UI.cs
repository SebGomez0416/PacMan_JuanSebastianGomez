using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject PauseScreen;

    private bool isPause;
    private bool isActiveSettings;
    public static event Action SendGameOver;
    public static event Action DestroyLevel;
    public static event Action GenerateLevel;
    public static event Action InitTime;
    public static event Action SaveData;
    

    private void OnEnable()
    {
        Score.NextLevel += NextLevel;
        Lives.GameOver += GameOver;
        UIAudioSettings.IsActiveSettings +=getActiveSettings ;
    }

    private void OnDisable()
    {
        Score.NextLevel -= NextLevel;
        Lives.GameOver -= GameOver;
        UIAudioSettings.IsActiveSettings -= getActiveSettings ;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void getActiveSettings(bool get)
    {
        isActiveSettings = get;
    }

    private void NextLevel()
    {
        SendGameOver?.Invoke();
        winScreen.SetActive(true);
    }

    private void GameOver()
    {
        SendGameOver?.Invoke();
        GameOverScreen.SetActive(true);
    }

    private void Pause()
    {
        if (isActiveSettings) return;
        isPause = !isPause;
        PauseScreen.SetActive(isPause);
        SendGameOver?.Invoke();
    }
    
    public void MenuButton()
    {
        SaveData?.Invoke();
        SceneManager.LoadScene("Menu");
    }
    
    public void ChangeLevel()
    {
        DataBetweenScenes.instance.level++; 
        DestroyLevel?.Invoke();
        SaveData?.Invoke();
        winScreen.SetActive(false);
        GenerateLevel?.Invoke();
        InitTime?.Invoke();
    }

    public void ButtonExit()
    {
        SaveData?.Invoke();
        Application.Quit();
    }
}


