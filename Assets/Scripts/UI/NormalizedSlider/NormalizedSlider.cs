using System;
using UnityEngine;
using UnityEngine.UI;

public class NormalizedSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _value;

    public event Action<float> ValueChanged;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeValue);
    }

    private void ChangeValue(float value)
    {
        _value = value / _slider.maxValue;
        ValueChanged?.Invoke(_value);
    }
}