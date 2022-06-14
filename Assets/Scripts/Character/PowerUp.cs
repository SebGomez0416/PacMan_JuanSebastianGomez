using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float lerpTime;
    [SerializeField] private float time;
    private SpriteRenderer sr;
    private bool change;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Active()
    {
        StartCoroutine(Colors());
    }

    IEnumerator Colors()
    {
        change = false;
        lerpTime += 0.1f;
        Change();
        yield return new WaitForSeconds(time);
        if (lerpTime <= 1)
            StartCoroutine("Colors");
        else
        {
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
