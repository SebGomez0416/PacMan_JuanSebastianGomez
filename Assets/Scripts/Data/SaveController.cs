using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveController : MonoBehaviour
{
   private GameData data;
   private string filePath = "Assets/Data/gameData.dat";

   private void Save()
   {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(filePath);

      data = new GameData();
      
      data.ScoreCoins = DataBetweenScenes.instance.ScoreCoins;
      data.lives = DataBetweenScenes.instance.lives;
      data.time = DataBetweenScenes.instance.time;
      data.level = DataBetweenScenes.instance.level;
      

      bf.Serialize(file, data);
   }

   private void OnDestroy()
   {
      Save();
   }
}
