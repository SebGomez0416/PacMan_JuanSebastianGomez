using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int score;

   

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

}
