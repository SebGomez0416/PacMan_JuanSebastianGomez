using UnityEngine;

public class CharacterDeath : MonoBehaviour, IKillable
{
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

    public void Kill()
    {
        Debug.Log("murio");
    }

    private void SetActive()
    {
        powerUp = !powerUp;
    }
}
