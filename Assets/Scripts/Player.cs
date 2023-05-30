using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private UnityEvent _healthChanged = new UnityEvent();

    public event UnityAction HealthChanged
    {
        add => _healthChanged.AddListener(value);
        remove => _healthChanged.RemoveListener(value);
    }
    
    private float _maxHealth = 100;
    private float _currentHealth;

    public float GetMaxHealth => _maxHealth;
    public float GetHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (_currentHealth > 0)
        {
            if (amount > _currentHealth)
            {
                _currentHealth = 0;
            }
            else
            {
                _currentHealth -= amount;
            }

            _healthChanged.Invoke();
        }
    }

    public void ReciveHeal(float amount) 
    { 
        if (_currentHealth < _maxHealth)
        {
            if (amount + _currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            else
            {
                _currentHealth += amount;
            }

            _healthChanged.Invoke();
        }
    }
}
