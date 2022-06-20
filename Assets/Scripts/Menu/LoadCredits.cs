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
        //https://docs.unity3d.com/Manual/StreamingAssets.html
        FileStream fs = File.OpenRead( Application.streamingAssetsPath + "Credits.txt");
        StreamReader sr = new StreamReader(fs);
        credits.text = sr.ReadToEnd();
        
        sr.Close();
        fs.Close();        
    }
}