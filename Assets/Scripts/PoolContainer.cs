using UnityEngine;

[RequireComponent (typeof(ObjectPool))]
public class PoolContainer : MonoBehaviour
{
    [SerializeField] private int _maxSize;

    private ObjectPool _pool;

    public int MaxSize => _maxSize;
    public int ItemsCount { get; private set; }

    private void Start()
    {
        _pool = GetComponent<ObjectPool>();
        ItemsCount = 0;
    }

    public bool TryGetObject(out PoolObject poolObject)
    {
        if (ItemsCount == MaxSize)
        {
            if (_pool.ObjectsCount == 0)
            {
                poolObject = null;
                return false;
            }
        }
        else
        {
            ItemsCount++;
        }

        poolObject = _pool.GetObject();
        return true;
    }
}