using UnityEngine;

public class DeathEnemy : MonoBehaviour, ICollidable
{
    [SerializeField] int score;

    public int GetScore()
    {
        return score;
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

}
