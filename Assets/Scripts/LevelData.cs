using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New LevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private string level;    
    public List<GameObject> objects;
    [SerializeField] private AudioClip levelAudio;

    public AudioClip LevelAudio
    {
        get { return levelAudio; }
    }

    public string Level
    {
        get { return level; }
        set { level = value; }
    }
}

    
