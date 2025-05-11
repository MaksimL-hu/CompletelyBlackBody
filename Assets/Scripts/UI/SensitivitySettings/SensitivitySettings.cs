using UnityEngine;

public class SensitivitySettings : MonoBehaviour
{
    [SerializeField] private NormalizedSlider _slider;
    [SerializeField] private DragSensitivity _sensitivity;

    private void OnEnable()
    {
        _slider.ValueChanged += ChangeSensitivity;
    }

    private void OnDisable()
    {
        _slider.ValueChanged -= ChangeSensitivity;
    }

    private void ChangeSensitivity(float value)
    {
        _sensitivity.SetSensitivity(value);
    }
}