using UnityEngine;

public class Gun : MonoBehaviour
{
    private ObjectPool _pool;

    public bool IsLoaded => _pool != null;

    public void Load(ObjectPool pool)
    {
        _pool = pool;
    }

    public void Shoot(Vector2 direction)
    {
        if (IsLoaded)
        {
            Projectile shoot = _pool.GetObject().GetPoolableComponent() as Projectile;

            shoot.gameObject.SetActive(true);
            shoot.transform.position = transform.position;
            shoot.SetDirection(direction);
        }
    }    
}