using UnityEngine;

public class MyCamera : MonoBehaviour
{
   private GameObject target;
   private SpriteRenderer sr;
   private Camera cam;
   private Vector3 size;
   private Vector3 max;
   private Vector3 min;
   private Vector3 movement;
   private Vector3 initPos;

   [SerializeField] private float moveDistance;
   [SerializeField] private float minX;
   [SerializeField] private float maxX;
   [SerializeField] private float minY;
   [SerializeField] private float maxY;
   [SerializeField] private float lerpTime;

   public void init(GameObject _target)
   {
      target = _target;
      sr = target.GetComponent<SpriteRenderer>();
      cam= Camera.main;
      movement = transform.position;
      initPos = transform.position;
   }
   
   private void OnEnable()
   {
      CharacterDeath.NotifyDeath += ResetPosition;
   }

   private void OnDisable()
   {
      CharacterDeath.NotifyDeath -= ResetPosition;
   }
   
   private void LateUpdate()
   {
      Vector2 cameraMovement = target.transform.position;
      
      max=cam.ScreenToWorldPoint(Vector3.zero);
      min= cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

      size = sr.bounds.size;
      size.y *= 5;
      size.x *= 6;


      if (Input.GetKeyDown(KeyCode.W))
      {
         if (cameraMovement.y >= min.y - size.y)
            Move(Direction.Dir.Up);
      }

      if (Input.GetKeyDown(KeyCode.S))
      {
         if (cameraMovement.y <= max.y + size.y)
            Move(Direction.Dir.Down);
      }

      if (Input.GetKeyDown(KeyCode.D))
      {
         if (cameraMovement.x >= min.x - size.x)
            Move(Direction.Dir.Right);
      }

      if (Input.GetKeyDown(KeyCode.A))
      {
         if (cameraMovement.x <= max.x + size.x)
            Move(Direction.Dir.Left);
      }

      transform.position =Vector3.Lerp(transform.position,movement,lerpTime);
   }

   private void Move(Direction.Dir direction)
   {
      movement = transform.position;
      switch (direction)
      {
         case Direction.Dir.Up:
            movement.y = Mathf.Clamp(transform.position.y + moveDistance, minY, maxY);
            break;
         
         case Direction.Dir.Down:
            movement.y = Mathf.Clamp(transform.position.y - moveDistance, minY, maxY);
            break;
         
         case Direction.Dir.Left:
            movement.x = Mathf.Clamp(transform.position.x-moveDistance, minX, maxX);
            break;
         
         case Direction.Dir.Right:
            movement.x = Mathf.Clamp(transform.position.x+moveDistance, minX, maxX);
            break;
      }
   }

   private void ResetPosition()
   {
      movement = initPos;
   }
}
