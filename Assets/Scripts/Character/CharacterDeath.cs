using System;
using UnityEngine;

public class CharacterDeath : MonoBehaviour, IKillable
{
    [SerializeField]private bool powerUp;   
    public static event Action NotifyDeath;  

    private void OnEnable()
    {
        Potion.ActivePowerUp += SetActive;
        PowerUp.EndPowerUp += SetActive;
    }

    private void OnDisable()
    {
        Potion.ActivePowerUp -= SetActive;
        PowerUp.EndPowerUp -= SetActive;
    }

    public void Die()
    {
        if (powerUp) return;       
        NotifyDeath?.Invoke();
    }

    private void SetActive()
    {
        powerUp = !powerUp;
    }
}
