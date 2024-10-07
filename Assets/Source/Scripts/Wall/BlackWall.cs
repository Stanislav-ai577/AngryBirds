using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BlackWall : MonoBehaviour,IHit
{
    public virtual void Hit()
    {
        StartCoroutine(DestroyTick());
    }

    public virtual IEnumerator DestroyTick()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
