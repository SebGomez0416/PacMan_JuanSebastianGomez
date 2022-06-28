using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadController : MonoBehaviour
{
    private GameData data;
    private string filePath = "Assets/Data/gameData.dat";

    private void OnEnable()
    {
        Menu.LoadData += Load;
        AudioController.LoadPref += LoadPref;      
    }

    private void OnDisable()
    {
        Menu.LoadData -= Load;
        AudioController.LoadPref -= LoadPref;
    }

    private void Load()
    {
        if (!File.Exists(filePath)) return;
      
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open);
      
        data = (GameData)bf.Deserialize(file);
        file.Close();

        DataBetweenScenes.instance.ScoreCoins = data.ScoreCoins;
        DataBetweenScenes.instance.lives = data.lives;
        DataBetweenScenes.instance.time = data.time;
        DataBetweenScenes.instance.level = data.level;
        DataBetweenScenes.instance.load=true;
        DataBetweenScenes.instance.Volume = data.Volume;
        DataBetweenScenes.instance.mute = data.mute;        
    }

    private void LoadPref()
    {
        if (!File.Exists(filePath)) return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open);

        data = (GameData)bf.Deserialize(file);
        file.Close();
        
        DataBetweenScenes.instance.Volume = data.Volume;
        DataBetweenScenes.instance.mute = data.mute;
    }


}
