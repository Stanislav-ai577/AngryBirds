using System;
using System.Collections;
using UnityEngine;

public class SlingShootAmmo : MonoBehaviour
{
    [SerializeField] private ShootRubber _rubber;
    [SerializeField] private BirdFactory _factory;
    [SerializeField] private Transform _rubberPosition;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxAmmo;
    private float _currentAmmo;

    private void Awake()
    {
        _rubber.OnReleaseShoot += NextBird;
    }

    private void Start()
    {
        _currentAmmo = _maxAmmo;
        NextBird();
    }

    private void NextBird()
    {
        if (_currentAmmo <= 0)
            throw new Exception("Ammo most be positive.");

        _currentAmmo--;
        StartCoroutine(ReloadDelay());
    }

    private void CreatedBird()
    {
        Bird newBird = _factory.CreatedBird(_startPosition.position);
        newBird.Setup(_rubberPosition, _startPosition);
        _rubber.UpdateBird(newBird);
    }
    
    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(_delay);
        CreatedBird();
    }
}
