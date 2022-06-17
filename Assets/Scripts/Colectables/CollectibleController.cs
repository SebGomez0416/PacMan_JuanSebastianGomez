using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
     [SerializeField]private List<GameObject> collectibles;
     [SerializeField] private int amount;
    

     private void Start()
     {
          Spawn();
     }

     private void Spawn()
     {
          foreach (GameObject obj in collectibles)
          {
               for (int i = 0; i < amount; i++)
               {
                    GameObject o = Instantiate(obj,transform);
                    o.GetComponent<ICollectible>().Spawn();
               }
          }
     }
}
