using UnityEngine;

public class CharacterCollision : MonoBehaviour
{       

    private void OnTriggerEnter2D(Collider2D c)
    {
       var obj = c.gameObject.GetComponent<IKillable>();
       obj?.Die();      
    }

}
