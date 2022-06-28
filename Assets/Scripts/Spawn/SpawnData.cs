using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnData",menuName = "SpawnData")]
public class SpawnData : ScriptableObject
{
    [SerializeField] private int amount;

    public int Amount { get { return amount; } }
    
    
}
