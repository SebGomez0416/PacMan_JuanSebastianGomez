using System;
using UnityEngine;

public class Coin : MonoBehaviour, ISpawmer,ICollectable
{
   private TileMapController tilemap;
   [SerializeField] private SpawnData SpawnData;
   [SerializeField] int score;   
   private Tile currentTile;

   public static event Action <int> SendScore;

   public void Spawn(TileMapController map)
   {
      tilemap = map;
      tilemap.RandSpawnObject( out currentTile);
      gameObject.transform.position = currentTile.pos;
   }
   
   public int GetAmount()
   {
      return SpawnData.Amount;
   }

   public void GetObject()
   {
      SendScore?.Invoke(score);
      Destroy(this.gameObject);
   }
}
