using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveController : MonoBehaviour
{
   private GameData data;
   


   private void OnEnable()
   {
      UI.SaveData += Save;
      Menu.SavePref += Save;
   }

   private void OnDisable()
   {
      UI.SaveData -= Save;
      Menu.SavePref -= Save;
   }
   
   private void Save()
   {
      string filePath = Application.persistentDataPath + "/gameData.dat";
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(filePath);

      data = new GameData();
      
      data.ScoreCoins = DataBetweenScenes.instance.ScoreCoins;
      data.lives = DataBetweenScenes.instance.lives;
      data.time = DataBetweenScenes.instance.time;
      data.level = DataBetweenScenes.instance.level;
      data.Volume = DataBetweenScenes.instance.Volume;
      data.mute = DataBetweenScenes.instance.mute;   

      bf.Serialize(file, data);
   }
}
