using UnityEngine;
using System;

public class Lives : MonoBehaviour
{
    [SerializeField] private GameObject life;
    [SerializeField] private float offSet;
    
    private GameObject[] lives;
    public static event Action GameOver;
    
    private void Init()
    {
        lives = new GameObject[ DataBetweenScenes.instance.lives];
        SpawnLives();
    }

    private void OnEnable()
    {
        CharacterDeath.NotifyDeath += UpdateLives;
        UI.InitUI += Init;
    }

    private void OnDisable()
    {
        CharacterDeath.NotifyDeath -= UpdateLives;
        UI.InitUI -= Init;
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
            GameOver?.Invoke();
    }
}
