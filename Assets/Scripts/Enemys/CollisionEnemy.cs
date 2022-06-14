using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D c)
    {
        IKillable obj = c.gameObject.GetComponent<IKillable>();
        obj?.Kill();
        
    }

}
