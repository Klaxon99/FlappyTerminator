using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool _projectilePool;
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private float _upperBound;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _spawnDelay;
    
    private int _enemiesCount = 4;
    private List<PoolObject> _enemies;

    private void Start()
    {
        _enemyPool.Fill(_enemiesCount);
        InitEnemies();
        _enemies = new List<PoolObject>(_enemyPool.PoolObjects);
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            yield return wait;

            Generate();
        }
    }

    public void Generate()
    {
        if (_enemyPool.ObjectsCount > 0 )
        {
            Enemy enemy = _enemyPool.GetObject().GetPoolableComponent() as Enemy;
            enemy.gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        foreach (PoolObject poolObject in _enemies)
        {
            Enemy enemy = poolObject.GetPoolableComponent() as Enemy;
            enemy.ResetStats();
            _enemyPool.PutObject(poolObject);
        }
    }

    private void InitEnemies()
    {
        float verticalStepPosition = Mathf.Abs(_lowerBound - _upperBound) / _enemiesCount;
        float currentVerticalPosition = _lowerBound;

        foreach (PoolObject poolObject in _enemyPool.PoolObjects)
        {
            Enemy enemy = poolObject.GetPoolableComponent() as Enemy;

            enemy.LoadGun(_projectilePool);
            enemy.GetComponent<EnemyCollector>().SetPool(_enemyPool);

            Vector3 position = transform.localPosition;
            enemy.transform.position = new Vector3(position.x, currentVerticalPosition);
            currentVerticalPosition = Mathf.MoveTowards(currentVerticalPosition, _upperBound, verticalStepPosition);
        }
    }
}