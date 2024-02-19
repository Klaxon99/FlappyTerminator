using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PoolObject _prefab;
    [SerializeField] private Transform _container;

    private Queue<PoolObject> _pool;

    public IEnumerable<PoolObject> PoolObjects => _pool;
    public int ObjectsCount => _pool.Count;

    private void Awake()
    {
        _pool = new Queue<PoolObject>();
    }

    public void Fill(int objectCount)
    {
        for (int i = 0; i < objectCount; i++)
        {
            _pool.Enqueue(CreateObject());
        }
    }

    public PoolObject GetObject()
    {
        if (_pool.Count == 0)
        {
            return CreateObject();
        }

        return _pool.Dequeue();
    }

    public void PutObject(PoolObject poolObject)
    {
        _pool.Enqueue(poolObject);
        poolObject.gameObject.SetActive(false);
    }

    private PoolObject CreateObject()
    {
        PoolObject poolObject = Instantiate(_prefab);
        poolObject.gameObject.SetActive(false);

        poolObject.transform.parent = _container;

        return poolObject;
    }
}