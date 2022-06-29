using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject PlayScreen;

    public static event Action LoadData; 
    public static event Action SavePref;
    

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
        SavePref?.Invoke();
        SceneManager.LoadScene("GamePlay");
    }

    public void ContinueButton()
    {
        LoadData?.Invoke();
        if (!DataBetweenScenes.instance.load) return;
        SceneManager.LoadScene("GamePlay");
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
