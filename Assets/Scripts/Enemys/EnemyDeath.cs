using UnityEngine;

public class EnemyDeath : MonoBehaviour, IKillable
{
    [SerializeField] int score;
    [SerializeField]private bool powerUp;
    
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

    public void Death()
    {
        if (!powerUp) return;
        gameObject.SetActive(false);
    }

    private void SetActive()
    {
        powerUp = !powerUp;
    }

}
