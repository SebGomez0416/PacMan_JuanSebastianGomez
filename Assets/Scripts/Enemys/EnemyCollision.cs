using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Character"))
        {
            var obj = c.gameObject.GetComponent<IKillable>();
            obj?.Die();
        }       
    }
}
