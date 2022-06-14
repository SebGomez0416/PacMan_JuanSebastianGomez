using System;
using UnityEngine;

public class Potion : MonoBehaviour, ICollidable
{
    [SerializeField] int score;    
    public static event Action ActivePowerUp;

    public int GetScore()
    {
        return score;
    }

    public void Destroy()
    {
        ActivePowerUp?.Invoke();
        gameObject.SetActive(false);
    }
}
