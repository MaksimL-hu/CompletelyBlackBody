using TMPro;
using UnityEngine;

public class FromNormalizedSliderToTextViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private NormalizedSlider _slider;

    private void OnEnable()
    {
        _slider.ValueChanged += ChangeText;
    }

    private void OnDisable()
    {
        _slider.ValueChanged -= ChangeText;
    }

    private void ChangeText(float text)
    {
        _text.text = text.ToString();
    }
}