using UnityEngine;

public class CharacterCollision : MonoBehaviour
{       

    private void OnTriggerEnter2D(Collider2D c)
    {
       IKillable obj = c.gameObject.GetComponent<IKillable>();
       obj?.Death();
    }

}
