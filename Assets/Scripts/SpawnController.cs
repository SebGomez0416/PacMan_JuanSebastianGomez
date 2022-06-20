
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
     [SerializeField] private List<GameObject> objects;

     private void Start()
     {
          Spawn();
     }

     private void Spawn()
     {
          foreach (GameObject obj in objects)
          {
               for (int i = 0; i < obj.GetComponent<ISpawmer>().Amount(); i++)
               {
                    GameObject o = Instantiate(obj, transform);
                    o.GetComponent<ISpawmer>().Spawn();
               }
          }
     }
}
    
