using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _shootPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PoolObject poolObject))
        {
            _shootPool.PutObject(poolObject);
        }
    }
}