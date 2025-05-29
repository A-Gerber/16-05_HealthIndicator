using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _currentCount;
    private float _minCount = 0f;

    public event Action<float> Changed;

    public float MaxCount { get; private set; } = 100f;
    public bool IsAlive => _currentCount > 0;

    private void Awake()
    {
        _currentCount = MaxCount;
    }

    private void Start()
    {
        Changed?.Invoke(_currentCount);
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            _currentCount = Mathf.Max(_minCount, _currentCount - damage);

            Changed?.Invoke(_currentCount);
        }
    }

    public void Heal(float healing)
    {
        if (healing > 0)
        {
            _currentCount = Mathf.Min(MaxCount, _currentCount + healing);

            Changed?.Invoke(_currentCount);
        }
    }

    public void ResetCount()
    {
        _currentCount = MaxCount;
    }
}