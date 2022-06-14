using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float lerpTime;
    [SerializeField] Vector3 up;
    [SerializeField] Vector3 down;
    Vector3 init;
    [SerializeField] float trigger;

    private void Awake()
    {
        init = transform.position;
    }

    private void LateUpdate()
    {
        if(target.position.y > trigger) 
        { 
            transform.position = Vector3.Lerp(transform.position,up,Time.deltaTime*lerpTime);
        }
        else if (target.position.y >=-trigger && target.position.y <= trigger)
        { 
            transform.position = Vector3.Lerp(transform.position, init, Time.deltaTime * lerpTime);
        }
        else if(target.position.y < -trigger)
        { 
            transform.position = Vector3.Lerp(transform.position, down , Time.deltaTime * lerpTime);
        }
    }
}
