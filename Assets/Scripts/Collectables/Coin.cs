using System;
using UnityEngine;

public class Coin : MonoBehaviour, ISpawmer,ICollectable
{
   public TileMapController tilemap { set; private get; }
   [SerializeField] private SpawnData SpawnData;
   [SerializeField] int score;   
   private Tile currentTile;
   private SpriteRenderer sr;
   
   public static event Action <int> SendScore;
   public static event Action Collected;

   private void Awake()
   {
      sr = GetComponent<SpriteRenderer>();
   }

   public void Spawn(TileMapController map)
   {
      tilemap = map;
      sr.enabled = true;
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
      Collected?.Invoke();
      gameObject.SetActive(false);
   }
}
