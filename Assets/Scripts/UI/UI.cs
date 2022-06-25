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
        SceneManager.LoadScene("Menu");
    }
    
    public void ChangeLevel()
    {
        DataBetweenScenes.instance.level++; 
        SceneManager.LoadScene(DataBetweenScenes.instance.level);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}


