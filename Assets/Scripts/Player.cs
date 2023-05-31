using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<float> OnHealthChanged;
    
    private float _maxHealth = 100;
    private float _currentHealth;

    public float GetMaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void ReciveHeal(float amount) 
    { 
        _currentHealth += amount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }
}