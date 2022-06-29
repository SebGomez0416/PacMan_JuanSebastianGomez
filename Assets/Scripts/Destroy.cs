using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnEnable()
    {
        UI.DestroyLevel += DestroyObject;
    }

    private void OnDisable()
    {
        UI.DestroyLevel -= DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
