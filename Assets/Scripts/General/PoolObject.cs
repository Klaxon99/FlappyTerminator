using UnityEngine;

public class PoolObject : MonoBehaviour 
{
    private IPoolable _poolableComponent;

    private void Awake()
    {
        _poolableComponent = GetComponent<IPoolable>();
    }

    public IPoolable GetPoolableComponent()
    {
        return _poolableComponent;
    }
}