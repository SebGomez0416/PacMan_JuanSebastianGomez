using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;

    private void Start()
    {
        DataBetweenScenes.instance.Init();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("LvOne");
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
