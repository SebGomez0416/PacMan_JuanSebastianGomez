using UnityEngine;

public class DataBetweenScenes : MonoBehaviour
{
    public static DataBetweenScenes instance;
    public int ScoreCoins { get; set; }
    public int lives { get; set; }
    public float time { get; set; }
    public int level { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Init()
    {
        ScoreCoins = 0;
        lives = 5;
    }
}
