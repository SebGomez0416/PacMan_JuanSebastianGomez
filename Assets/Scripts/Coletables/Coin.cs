using UnityEngine;

public class Coin : MonoBehaviour, ICollidable
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
