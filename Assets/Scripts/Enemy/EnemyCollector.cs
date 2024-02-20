using UnityEngine;

[RequireComponent (typeof(PoolObject))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Enemy))]
public class EnemyCollector : MonoBehaviour
{
    private ObjectPool _enemyPool;
    private PoolObject _poolEnemyObject;
    private Enemy _enemy;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _poolEnemyObject = GetComponent<PoolObject>();
        _enemy = _poolEnemyObject.GetPoolableComponent() as Enemy;
    }

    private void OnEnable()
    {
        _health.Dead += Collect;
    }

    private void OnDisable()
    {
        _health.Dead -= Collect;
    }

    public void SetPool(ObjectPool objectPool)
    {
        _enemyPool = objectPool;
    }

    private void Collect()
    {
        if (_enemyPool != null)
        {
            _enemy.ResetStats();
            _enemyPool.PutObject(_poolEnemyObject);
        }
    }
}