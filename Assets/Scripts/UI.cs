using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textClock;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textWin;
    [SerializeField] private GameObject life;
    [SerializeField] private GameObject screenGameOver;
    [SerializeField] private float offSet;
    [SerializeField] private int scoreToWin;
    
    private bool timerBool;
    private float currentTime;
    private TimeSpan timer;
    private int score;
    private int AmountLife;
    private GameObject[] lives;

    public static event Action SendGameOver;

    private void Awake()
    {
        textClock.text = "00:00";
        timerBool = false;
        AmountLife = 3;
        lives = new GameObject[AmountLife];
        SpawnLives();
    }
    private void Start()
    {
        InitTimer();
    }

    private void OnEnable()
    {
        Coin.SendScore += UpdateScore;
        CharacterDeath.NotifyDeath += UpdateLives;
    }

    private void OnDisable()
    {
        Coin.SendScore -= UpdateScore;
        CharacterDeath.NotifyDeath -= UpdateLives;
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
        if (score == scoreToWin)
        {
            textWin.enabled = true;
            GameOver();
        }
    }

    private void UpdateLives()
    {
        AmountLife--;
        lives[AmountLife].gameObject.SetActive(false);
        if (AmountLife == 0)
            GameOver();
    }
    
    private void GameOver()
    {
        EndTime();
        SendGameOver?.Invoke();
        screenGameOver.SetActive(true);
    }

    private void  SpawnLives()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i]=Instantiate(life,transform);
            lives[i].transform.position += new Vector3(offSet*i, 0, 0);
        }
    }

   
    public void ButtonMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
   

}


