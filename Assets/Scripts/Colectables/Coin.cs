using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
   [SerializeField] int score;
   [SerializeField]private TileMapController tilemap;
   private Tile currentTile;
   private SpriteRenderer sr;
   
   public static event Action SendScore;

   private void Awake()
   {
      sr = GetComponent<SpriteRenderer>();
   }

   public void Spawn()
   {
      sr.enabled = true;
      currentTile = gameObject.AddComponent<Tile>(); 
      currentTile.occupied = true;
      tilemap.RandSpawnPoint(currentTile);
      gameObject.transform.position = currentTile.pos;
   }

   public void Destroy()
   {
      SendScore?.Invoke();
      gameObject.SetActive(false);
   }
}
