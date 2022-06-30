using UnityEngine;
using System;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private int scoreToWin;
    [SerializeField] private AudioClip nextLevel;
    [SerializeField] private GameObject nextLevelButton;
    private const int finalLevel = 2;
    
    private int currentScore;
    
    public static event Action NextLevel;
    public static event Action <string, bool> PlaySound;

    private void Start()
    {
        textScore.text = ""+DataBetweenScenes.instance.ScoreCoins;
    }
    
    private void OnEnable()
    {
        Coin.SendScore += UpdateScore;
        UI.ChangeLv += ResetScore;
    }

    private void OnDisable()
    {
        Coin.SendScore -= UpdateScore;
        UI.ChangeLv -= ResetScore;
    }

    private void ResetScore()
    {
        currentScore = 0;
    }
    
    private void UpdateScore(int s)
    {
        DataBetweenScenes.instance.ScoreCoins += s;
        currentScore += s;
        textScore.text = ""+ DataBetweenScenes.instance.ScoreCoins;
        if (currentScore == scoreToWin)
        {
            if(DataBetweenScenes.instance.level == finalLevel) nextLevelButton.SetActive(false);
            NextLevel?.Invoke();
            PlaySound?.Invoke(nextLevel.name, false);
        }
            
    }
}
