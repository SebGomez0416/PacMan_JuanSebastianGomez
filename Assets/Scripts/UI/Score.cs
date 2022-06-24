using UnityEngine;
using System;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private int scoreToWin;
    [SerializeField] private AudioClip nextLevel;
    
    public static event Action NextLevel;
    public static event Action <string> PlaySound;

    private void Start()
    {
        textScore.text = ""+DataBetweenScenes.instance.ScoreCoins;
    }
    
    private void OnEnable()
    {
        Coin.SendScore += UpdateScore;
    }

    private void OnDisable()
    {
        Coin.SendScore -= UpdateScore;
    }
    
    private void UpdateScore(int s)
    {
        DataBetweenScenes.instance.ScoreCoins += s;
        textScore.text = ""+ DataBetweenScenes.instance.ScoreCoins;

        if (DataBetweenScenes.instance.ScoreCoins == scoreToWin)
        {
            NextLevel?.Invoke();
            PlaySound?.Invoke(nextLevel.name);
        }
            
    }
}
