using System.IO;
using TMPro;
using UnityEngine;

public class LoadCredits : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI credits;

    private void Awake()
    {
        LoadText();
    }

    private void LoadText()
    {
        FileStream fs = File.OpenRead( "Assets/StreamingAssets/Credits.txt");
        StreamReader sr = new StreamReader(fs);
        credits.text = sr.ReadToEnd();
        
        sr.Close();
        fs.Close();        
    }
}