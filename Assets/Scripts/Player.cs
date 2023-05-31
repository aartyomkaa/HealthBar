using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction<float> OnHealthChanged;
    
    private float _maxHealth = 100;
    private float _currentHealth;

    public float GetMaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (MinHealth(amount) == false)
        {
            _currentHealth -= amount;

            OnHealthChanged?.Invoke(_currentHealth);
        }
    }

    public void ReciveHeal(float amount) 
    { 
        if (MaxHealth(amount) == false)
        {
            _currentHealth += amount;

            OnHealthChanged?.Invoke(_currentHealth);
        }
    }

    private bool MinHealth(float amount)
    {
        if (_currentHealth - amount < 0)
            return true;
        return false;
    }

    private bool MaxHealth(float amount)
    {
        if (_currentHealth + amount > _maxHealth)
            return true;
        return false;
    }
}
