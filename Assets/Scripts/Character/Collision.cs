using UnityEngine;

public class Collision : MonoBehaviour
{       

    private void OnCollisionEnter2D(Collision2D c)
    {
        ICollidable obj = c.gameObject.GetComponent<ICollidable>();
        obj?.Destroy();

        // llmar getscore cuando construya la UI
    }
}
