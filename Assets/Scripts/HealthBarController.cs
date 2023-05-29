using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private float _fillSpeed = 15f;
    private string _textSplit;

    private void Start()
    {
        SetMaxHealth();
        _textSplit = " / ";
    }

    private void Update()
    {
        SetHealth();
        _text.text = _player.GetHealth.ToString() + _textSplit + _player.GetMaxHealth.ToString();
    }

    private void SetMaxHealth()
    {
        _slider.maxValue = _player.GetMaxHealth;
        _slider.value = _player.GetMaxHealth;
    }

    private void SetHealth()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _player.GetHealth, _fillSpeed * Time.deltaTime);
    }
}