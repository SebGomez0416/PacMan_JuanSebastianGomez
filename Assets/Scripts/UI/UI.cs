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
    public static event Action InitUI;

    private void Start()
    {
        DataBetweenScenes.instance.level++;
        if( DataBetweenScenes.instance.level == 1) DataBetweenScenes.instance.Init();
        InitUI?.Invoke();
    }

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
    
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}


