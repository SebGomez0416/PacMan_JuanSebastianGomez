using System;
using UnityEngine;

public class Coin : MonoBehaviour, ISpawmer,ICollectable
{
   [SerializeField] private SpawnData SpawnData;
   [SerializeField] int score;
   [SerializeField]private TileMapController tilemap;
   private Tile currentTile;
   private SpriteRenderer sr;
   
   public static event Action <int> SendScore;

   private void Awake()
   {
      sr = GetComponent<SpriteRenderer>();
   }

   public void Spawn()
   {
      sr.enabled = true;
      currentTile = gameObject.AddComponent<Tile>();
      tilemap.RandSpawnObject(currentTile);
      gameObject.transform.position = currentTile.pos;
   }
   
   public int Amount()
   {
      return SpawnData.Amount;
   }

   public void GetObject()
   {
      SendScore?.Invoke(score);
      gameObject.SetActive(false);
   }
}
