using System.Collections;
using UnityEngine;

public class RedWall : BlackWall
{
    public override void Hit()
    {
        transform.localScale = new Vector2(5, 5);
        StartCoroutine(DestroyTick());
    }

    public override IEnumerator DestroyTick()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
