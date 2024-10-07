using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _shootPoint;
    private bool _isCanLaunch;
    
    private void OnValidate()
    {
        _rigidbody2D ??= GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        _rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (_isCanLaunch)
        {
            transform.position = _shootPoint.position;
        }
    }

    public void Setup(Transform shootPoint, Transform startPoint)
    {
        _shootPoint = shootPoint;
        transform.DOJump(shootPoint.position, 0.5f, 2, 2 ).OnComplete(() =>
        {
            _isCanLaunch = true;
        });
    }
    
    public void Launch(Vector2 direction)
    {
        _isCanLaunch = false;
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IHit hit))
        {
            hit.Hit();
        }
    }
}
