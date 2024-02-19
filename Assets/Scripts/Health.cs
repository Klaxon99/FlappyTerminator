using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _minValue;

    public event Action Dead;
    public event Action<float> OnHealthChange;

    public float Value { get; private set; }
    public float MaxValue { get; private set; }
    public bool IsAlive => Value > _minValue;

    private void Start()
    {
        MaxValue = 100;
        _minValue = 0;
        Value = MaxValue;
    }

    public void TakeDamage(float damage)
    {
        Value = Mathf.Clamp(Value - damage, _minValue, Value);
        OnHealthChange?.Invoke(Value);

        if (IsAlive == false)
        {
            Dead?.Invoke();
        }
    }

    public void Recovery(float healthCount)
    {
        Value = Mathf.Clamp(Value + healthCount, Value, MaxValue);
        OnHealthChange?.Invoke(Value);
    }
}