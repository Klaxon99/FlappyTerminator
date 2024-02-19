using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Ship : MonoBehaviour
{
    [SerializeField] private Gun _shooter;

    protected Health Health;

    public void LoadGun(ObjectPool shootPool)
    {
        _shooter.Load(shootPool);
    }

    protected void Shoot(Vector2 direction)
    {
        _shooter.Shoot(direction);
    }

    public virtual void ResetStats()
    {
        Health.Recovery(Health.MaxValue);
    }
}