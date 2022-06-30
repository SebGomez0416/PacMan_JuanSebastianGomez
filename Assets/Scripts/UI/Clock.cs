using TMPro;
using System;
using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textClock;
    
    private bool timerBool;
    private float currentTime;
    private TimeSpan timer;

    private void Start()
    {
        textClock.text = "00:00";
        timerBool = false;
        InitTimer();
    }

    private void OnEnable()
    {
        UI.SendGameOver += EndTime;
    }

    private void OnDisable()
    {
        UI.SendGameOver -= EndTime;
    }

    private void EndTime()
    {
        timerBool = !timerBool;
        if(timerBool) InitTimer();
    }

    private void InitTimer()
    {
        timerBool = true;
        currentTime = DataBetweenScenes.instance.time;
        StartCoroutine("UpdateTime");
    }
    
    private IEnumerator UpdateTime()
    {
        while (timerBool)
        {
            currentTime += Time.deltaTime;
            DataBetweenScenes.instance.time = currentTime;
            timer =TimeSpan.FromSeconds(currentTime);
            string timerStr =" "+ timer.ToString("mm':'ss");
            textClock.text = timerStr;
            yield return null;
        }
    }
    
    
    
    
}
