using System;
using UnityEngine;

public class ShootRubber : MonoBehaviour
{
   public Action OnReleaseShoot;
   
   [SerializeField] private float _maxDistance;
   [SerializeField] private float _force;
   private Bird _bird;
   private Vector2 _start;
   private Camera _camera;
   private bool _isCanShoot;

   private void Awake()
   {
      _camera = Camera.main;
      _start = transform.position;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && !_isCanShoot)
      {
         _bird.Launch(Vector2.right * _force);
         _isCanShoot = true;
      }
   }

   public void UpdateBird(Bird bird)
   {
      _bird = bird;
      _isCanShoot = true;
   }
   
   private void OnMouseDrag()
   {
      if (!_isCanShoot)
         return;
      
      Vector2 target = _camera.ScreenToWorldPoint(Input.mousePosition);

      if (Vector2.Distance(_start, target) < _maxDistance)
      {
         transform.position = target;
      }
      else
      {
         Vector2 direction = (target - _start).normalized * _maxDistance;
         transform.position = _start * direction;
      }
   }

   private void OnMouseUp()
   {
      if (!_isCanShoot)
         return;
      
      Vector2 releasePosition = transform.position;
      transform.position = _start;
      Vector2 delta = releasePosition - _start;
      _bird.Launch(-delta * _force);
      _isCanShoot = false;
      OnReleaseShoot?.Invoke();
   }
}
