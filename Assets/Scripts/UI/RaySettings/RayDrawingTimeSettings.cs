using UnityEngine;

public class RayDrawingTimeSettings : MonoBehaviour
{
    [SerializeField] protected NormalizedSlider _slider;
    [SerializeField] protected RayDrawer _rayDrawer;

    private void OnEnable()
    {
        _slider.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _slider.ValueChanged -= ChangeValue;
    }

    private void ChangeValue(float value)
    {
        _rayDrawer.SetDrawingTime(value);
    }
}