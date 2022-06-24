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
    [SerializeField] private TextMeshProUGUI textGameOver;
    [SerializeField] private TextMeshProUGUI textPause;
    [SerializeField] private GameObject life;
    [SerializeField] private GameObject screenGameOver;
    [SerializeField] private GameObject nextLevel;
    
    [SerializeField] private float offSet;
    [SerializeField] private int scoreToWin;
    
    private bool timerBool;
    private bool isPause;
    private float currentTime;
    private TimeSpan timer;
    private GameObject[] lives;

    public static event Action SendGameOver;

    private void Start()
    {
        DataBetweenScenes.instance.level++;
        
        if( DataBetweenScenes.instance.level == 1) DataBetweenScenes.instance.Init();
        
        textScore.text = ""+DataBetweenScenes.instance.ScoreCoins;
        textClock.text = "00:00";
        timerBool = false;
        lives = new GameObject[ DataBetweenScenes.instance.lives];
        
        SpawnLives();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void InitTimer()
    {
        timerBool = true;
        currentTime = DataBetweenScenes.instance.time;
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
            DataBetweenScenes.instance.time = currentTime;
            timer =TimeSpan.FromSeconds(currentTime);
            string timerStr =" "+ timer.ToString("mm':'ss");
            textClock.text = timerStr;
            yield return null;
        }
    }

    private void UpdateScore(int s)
    {
        DataBetweenScenes.instance.ScoreCoins += s;
        textScore.text = ""+ DataBetweenScenes.instance.ScoreCoins;
        if ( DataBetweenScenes.instance.ScoreCoins == scoreToWin )
        {
            nextLevel.SetActive(true);
            if (DataBetweenScenes.instance.level == 3)
            {
                textWin.enabled = true;
                nextLevel.SetActive(false);
            }
            GameOver();
        }
    }

    private void UpdateLives()
    {
        DataBetweenScenes.instance.lives--;
        lives[ DataBetweenScenes.instance.lives].gameObject.SetActive(false);
        if (DataBetweenScenes.instance.lives == 0)
        {
            nextLevel.SetActive(false);
            GameOver();
        }
          
    }
    
    private void GameOver()
    {
        textGameOver.enabled = true;
        EndTime();
        SendGameOver?.Invoke();
        screenGameOver.SetActive(true);
    }

    private void Pause()
    {
        isPause = !isPause;
        if (isPause) timerBool = false;
        else InitTimer();
        textPause.enabled = isPause;
        screenGameOver.SetActive(isPause);
        SendGameOver?.Invoke();
    }

    private void  SpawnLives()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i]=Instantiate(life,transform);
            lives[i].transform.position += new Vector3(offSet*i, 0, 0);
        }
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


