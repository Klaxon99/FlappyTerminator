using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : Ship, IPoolable
{
    [SerializeField] private float _shootDelay;

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        WaitForSeconds wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            yield return wait;

            Shoot(Vector2.left);
        }
    }
}