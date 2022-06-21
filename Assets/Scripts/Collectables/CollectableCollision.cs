using UnityEngine;

public class CollectableCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D c)
    {
        var obj = c.gameObject.GetComponent<ICollectable>();
        obj?.GetObject();
    }
}
