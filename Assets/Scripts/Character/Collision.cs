using UnityEngine;

public class Collision : MonoBehaviour
{       

    private void OnCollisionEnter2D(Collision2D c)
    {
        ICollectible obj = c.gameObject.GetComponent<ICollectible>();
        obj?.Destroy();

        // llmar getscore cuando construya la UI
    }
}
