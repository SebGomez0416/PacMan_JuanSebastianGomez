using UnityEngine;

public class CharacterCollision : MonoBehaviour
{       

    private void OnTriggerEnter2D(Collider2D c)
    {
        ICollectible obj = c.gameObject.GetComponent<ICollectible>();
        obj?.Destroy();
    }
}
