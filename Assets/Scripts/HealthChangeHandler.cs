using UnityEngine;
using UnityEngine.UI;

public class HealthChangeHandler : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _health.OnHealthChange += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.OnHealthChange -= ChangeHealth;
    }

    private void ChangeHealth(float health)
    {
        _slider.value = CalculateHealthPercernt();
    }

    private float CalculateHealthPercernt()
    {
        return _health.Value / _health.MaxValue;
    }
}