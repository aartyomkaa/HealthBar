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

    private string _textSplit;

    private void OnEnable()
    {
        _textSplit = " / ";

        SetSlider();
        SetText();

        _player.HealthChanged += StartMoveBar;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= StartMoveBar;
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

    private void StartMoveBar()
    {
        var moveBarCoroutine =  StartCoroutine(MoveBar());

        if (_slider.value == _player.GetHealth)
        {
            StopCoroutine(moveBarCoroutine);
        }
    }

    private IEnumerator MoveBar()
    {
        float healthPoints = Mathf.Abs(_slider.value - _player.GetHealth);
        float healthPointsMove = 1;
        var waitForSeconds = new WaitForSeconds(0.1f);

        for (int i = 0; i < healthPoints; i++)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.GetHealth, healthPointsMove);

            SetText();

            yield return waitForSeconds;
        }
    }
}