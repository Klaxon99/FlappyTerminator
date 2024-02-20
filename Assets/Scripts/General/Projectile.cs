using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Projectile : MonoBehaviour, IPoolable
{
    [SerializeField] private float _shootingSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector2 _direction = Vector2.zero;

    private void Update()
    {
        transform.Translate(_direction * _shootingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        _spriteRenderer.flipX = direction.x < 0;
    }
}