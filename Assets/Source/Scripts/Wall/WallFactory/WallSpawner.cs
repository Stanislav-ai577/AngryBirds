using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private WallFactory _wallFactory;
    
    private void Start()
    {
        SpawnBlackWall();
        SpawnRedWall();
        SpawnYellowWall();
    }

    private void SpawnBlackWall()
    {
        _wallFactory.CreatedBlackWall(new Vector2(Random.Range(0, 5), Random.Range(0, -5)));
    }
    
    private void SpawnRedWall()
    {
        _wallFactory.CreatedRedWall(new Vector2(Random.Range(0, 10), Random.Range(0, -5)));
    }
    
    private void SpawnYellowWall()
    {
        _wallFactory.CreatedYellowWall(new Vector2(Random.Range(0, 3), Random.Range(0, -5)));
    }
}
