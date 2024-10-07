using System.Collections;
using UnityEngine;

public class YellowWall : BlackWall
{
    [SerializeField] private SpriteRenderer _renderer;

    private void OnValidate()
    {
        _renderer ??= GetComponent<SpriteRenderer>();
    }

    public override void Hit()
    {
        _renderer.materials[0].color = Color.magenta;
        StartCoroutine(DestroyTick());
    }

    public override IEnumerator DestroyTick()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
