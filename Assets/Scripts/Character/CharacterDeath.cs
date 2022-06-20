using System;
using UnityEngine;

public class CharacterDeath : MonoBehaviour, IKillable
{
    [SerializeField]private bool powerUp;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector3 init;
    
    public static event Action NotifyDeath;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        init= new Vector3(0, 2.4f, 0);
    }

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
        if (powerUp) return;
        sr.enabled = false;
        rb.position = init;
        NotifyDeath?.Invoke();
    }

    private void SetActive()
    {
        powerUp = !powerUp;
    }
}
