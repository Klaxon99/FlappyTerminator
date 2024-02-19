using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(PlayerMover))]
public class Player : Ship
{
    [SerializeField] private float _shootSpeed;
    [SerializeField] private ObjectPool _shootPool;
    [SerializeField] private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private PlayerMover _playerMover;
    private CollisionHandler _collisionHandler;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _playerMover = GetComponent<PlayerMover>();
        Health = GetComponent<Health>(); 
        LoadGun(_shootPool);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot(Vector2.right * _shootSpeed);
        }
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
        Health.Dead += OnDead;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
        Health.Dead -= OnDead;
    }

    public override void ResetStats()
    {
        base.ResetStats();
        _playerMover.Reset();
        _scoreCounter.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground ground)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        GameOver?.Invoke();
    }
}