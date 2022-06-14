
using UnityEngine;

public class Death : MonoBehaviour, IKillable
{
   
    public void Kill()
    {
        Debug.Log("murio");
    }
}
