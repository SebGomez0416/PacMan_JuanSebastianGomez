using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D c)
    {
        IKillable obj = c.gameObject.GetComponent<IKillable>();
        obj?.Kill();
        
    }

}
