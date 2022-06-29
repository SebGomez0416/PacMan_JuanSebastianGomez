using System;
using UnityEngine;

public class Potion : MonoBehaviour, ISpawmer,ICollectable
{
    private TileMapController tilemap;
    [SerializeField] private SpawnData SpawnData;    
    private Tile currentTile;
    private bool isActive;

    public static event Action ActivePowerUp;

    private void OnEnable()
    {
        PowerUp.EndPowerUp += SetActive;
        ActivePowerUp+=SetActive;
    }

    private void OnDisable()
    {
        PowerUp.EndPowerUp -= SetActive;
        ActivePowerUp+=SetActive;
    }

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
        if (isActive) return;
        ActivePowerUp?.Invoke();
        Destroy(this.gameObject);
    }

    private void SetActive()
    {
        isActive = !isActive;
    }
    
}
