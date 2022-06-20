using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textClock;
    [SerializeField] private TextMeshProUGUI textScore;
    private bool timerBool;
    private float currentTime;
    private TimeSpan timer;
    private int score;

    private void Awake()
    {
        textClock.text = "00:00";
        timerBool = false;
    }
    private void Start()
    {
        InitTimer();
    }

    private void OnEnable()
    {
        Coin.SendScore += UpdateScore;
    }

    private void OnDisable()
    {
        Coin.SendScore -= UpdateScore;
    }

    private void InitTimer()
    {
        timerBool = true;
        currentTime = 0;
        StartCoroutine("UpdateTime");
    }

    private void EndTime()
    {
       timerBool = false;
    }

    private IEnumerator UpdateTime()
    {
        while (timerBool)
        {
            currentTime += Time.deltaTime;
            timer =TimeSpan.FromSeconds(currentTime);
            string timerStr =" "+ timer.ToString("mm':'ss");
            textClock.text = timerStr;
            yield return null;
        }
    }

    private void UpdateScore(int s)
    {
        score += s;
        textScore.text = ""+score;
    }

   
   

}


