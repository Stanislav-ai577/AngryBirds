using UnityEngine;

public class BirdFactory : MonoBehaviour
{
   [SerializeField] private Bird _bird;
   
   public Bird CreatedBird(Vector2 position)
   {
      Bird birdCreated = Instantiate(_bird, position, Quaternion.identity, transform);
      return birdCreated;
   }
}
