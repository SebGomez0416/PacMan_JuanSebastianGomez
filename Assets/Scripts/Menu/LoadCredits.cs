using System.IO;
using TMPro;
using UnityEngine;

public class LoadCredits : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI credits;
    [SerializeField]private TextAsset creditsText;

    private void Awake()
    {
        credits.text = creditsText.text;
    }
   
}