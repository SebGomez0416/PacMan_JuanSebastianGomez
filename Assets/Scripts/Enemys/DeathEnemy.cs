using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    [SerializeField] int score;

   

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

}
