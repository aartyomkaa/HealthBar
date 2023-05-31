using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private const string _textSplit = " / ";

    private Coroutine _moveBar;

    private void OnEnable()
    {
        SetSlider();
        SetText();

        _player.OnHealthChanged += StartMoveBar;
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= StartMoveBar;
    }

    private void SetSlider()
    {
        _slider.maxValue = _player.GetMaxHealth;
        _slider.value = _player.GetMaxHealth;
    }

    private void SetText()
    {
        _text.text = _slider.value + _textSplit + _player.GetMaxHealth.ToString();
    }

    private void StartMoveBar(float currentHealth)
    {
        if (_moveBar != null)
        {
            StopCoroutine(_moveBar);
        }

        if(_slider.value != currentHealth)
        {
            _moveBar = StartCoroutine(MoveBar(currentHealth));
        }
    }

    private IEnumerator MoveBar(float currentHealth)
    {
        float healthPointsMove = 1;
        float waitSeconds = 0.05f;
        var waitForSeconds = new WaitForSeconds(waitSeconds);

        while(_slider.value != currentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth, healthPointsMove);

            yield return waitForSeconds;
        }

        SetText();
    }
}