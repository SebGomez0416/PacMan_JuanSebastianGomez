using UnityEngine;
using System;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private int scoreToWin;
    
    public static event Action NextLevel;

    private void Init()
    {
        textScore.text = ""+DataBetweenScenes.instance.ScoreCoins;
    }
    
    private void OnEnable()
    {
        Coin.SendScore += UpdateScore;
        UI.InitUI += Init;
    }

    private void OnDisable()
    {
        Coin.SendScore -= UpdateScore;
        UI.InitUI -= Init;
    }
    
    private void UpdateScore(int s)
    {
        DataBetweenScenes.instance.ScoreCoins += s;
        textScore.text = ""+ DataBetweenScenes.instance.ScoreCoins;
        
        if ( DataBetweenScenes.instance.ScoreCoins == scoreToWin )
            NextLevel?.Invoke();
    }
}
