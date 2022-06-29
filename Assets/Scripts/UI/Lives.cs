using UnityEngine;
using System;

public class Lives : MonoBehaviour
{
    [SerializeField] private GameObject life;
    [SerializeField] private float offSet;
    [SerializeField] private AudioClip gameOver;
    
    private GameObject[] lives;
    public static event Action GameOver;
    public static event Action <string, bool> PlaySound;
    
    private void Start()
    {
        lives = new GameObject[ DataBetweenScenes.instance.lives];
        SpawnLives();
    }

    private void OnEnable()
    {
        CharacterDeath.NotifyDeath += UpdateLives;
    }

    private void OnDisable()
    {
        CharacterDeath.NotifyDeath -= UpdateLives;
    }
    
    private void  SpawnLives()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i]=Instantiate(life,transform);
            lives[i].transform.position += new Vector3(offSet*i, 0, 0);
        }
    }
    
    private void UpdateLives()
    {
        DataBetweenScenes.instance.lives--;
        lives[ DataBetweenScenes.instance.lives].gameObject.SetActive(false);
        if (DataBetweenScenes.instance.lives == 0)
        {
            GameOver?.Invoke();
            PlaySound?.Invoke(gameOver.name, false);
        }
           
    }
}
