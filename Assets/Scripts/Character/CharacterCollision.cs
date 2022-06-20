using UnityEngine;

public class CharacterCollision : MonoBehaviour
{       

    private void OnTriggerEnter2D(Collider2D c)
    {
       var obj = c.gameObject.GetComponent<IKillable>();
       obj?.Death();
       
       var collectable = c.gameObject.GetComponent<ICollectable>();
       collectable?.GetObject();
    }

}
