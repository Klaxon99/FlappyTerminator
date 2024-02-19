using UnityEngine;

public class Enemy : Ship, IPoolable
{
    [SerializeField] private float _shootDelay;

    private float _timer = 0f;

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_timer > _shootDelay)
        {
            _timer = 0f;
            Shoot(Vector2.left);
        }

        _timer += Time.deltaTime;
    }

    public override void ResetStats()
    {
        base.ResetStats();
        _timer = 0f;
    }
}