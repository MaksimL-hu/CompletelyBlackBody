using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoleSettings : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] protected RingEdgeColliderWithHole RingEdgeColliderWithHole;

    private void OnEnable()
    {
        _inputField.onEndEdit.AddListener(SetSliderValue);
        _slider.onValueChanged.AddListener(SetInputFieldValue);
    }

    private void OnDisable()
    {
        _inputField.onEndEdit.RemoveListener(SetSliderValue);
        _slider.onValueChanged.RemoveListener(SetInputFieldValue);
    }

    private void SetSliderValue(string value)
    {
        _slider.value = int.Parse(value);
    }

    protected virtual void SetInputFieldValue(float value)
    {
        _inputField.text = value.ToString();
    }
}