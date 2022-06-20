using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float lerpTime;
    [SerializeField] private float time;
    [SerializeField] private float speedChange;
    private SpriteRenderer sr;

    public static event Action EndPowerUp;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Potion.ActivePowerUp += Active;
    }

    private void OnDisable()
    {
        Potion.ActivePowerUp -= Active;
    }

    private void Active()
    {
        StartCoroutine(Colors());
    }

    IEnumerator Colors()
    {
        lerpTime += speedChange;
        Change();
        yield return new WaitForSeconds(speedChange);
        if (lerpTime <= time)
            StartCoroutine("Colors");
        else
        { 
            EndPowerUp?.Invoke();
            lerpTime = 0;
            sr.color = Color.white;
        }
    }

    private void Change()
    {
        if (sr.color == Color.white)
            sr.color = Color.red;
        else if (sr.color == Color.red)
            sr.color = Color.white;
    }
}
