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
        var moveBarCoroutine = StartCoroutine(MoveBar(currentHealth));

        if (_slider.value == currentHealth)
        {
            StopCoroutine(moveBarCoroutine);
        }
    }

    private IEnumerator MoveBar(float currentHealth)
    {
        float healthPoints = Mathf.Abs(_slider.value - currentHealth);
        float healthPointsMove = 1;
        float waitSeconds = 0.05f;
        var waitForSeconds = new WaitForSeconds(waitSeconds);

        for (int i = 0; i < healthPoints; i++)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth, healthPointsMove);

            yield return waitForSeconds;
        }

        SetText();
    }
}