using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject PlayScreen;

    public static event Action LoadData;

    private void Start()
    {
        DataBetweenScenes.instance.Init();
    }

    public void PlayButton()
    {
        PlayScreen.SetActive(true);
    }
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(DataBetweenScenes.instance.level);
    }

    public void ContinueButton()
    {
        LoadData?.Invoke();
        if (!DataBetweenScenes.instance.load) return;
        SceneManager.LoadScene(DataBetweenScenes.instance.level);
    }

    public void CreditsButton(bool set)
    {
        creditsScreen.SetActive(set);
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
}
