using UnityEngine;

public class WallFactory : MonoBehaviour
{
    [SerializeField] private BlackWall _blackWall;
    [SerializeField] private RedWall _redWall;
    [SerializeField] private YellowWall _yellowWall;

    public BlackWall CreatedBlackWall(Vector2 position)
    {
        BlackWall blackWall = Instantiate(_blackWall, position, Quaternion.identity);
        return blackWall;
    }
    
    public RedWall CreatedRedWall(Vector2 position)
    {
        RedWall redWall = Instantiate(_redWall, position, Quaternion.identity);
        return redWall;
    }
    
    public YellowWall CreatedYellowWall(Vector2 position)
    {
        YellowWall yellowWall = Instantiate(_yellowWall, position, Quaternion.identity);
        return yellowWall;
    }
}
