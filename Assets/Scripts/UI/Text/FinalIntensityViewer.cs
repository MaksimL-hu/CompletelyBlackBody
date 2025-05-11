using UnityEngine;

public class FinalIntensityViewer : TextViewer
{
    [SerializeField] private RayDrawer _rayDrawer;
    [SerializeField] private string _additionalText;

    private void OnEnable()
    {
        _rayDrawer.PathBuilder.PathBuilt += ChangeTextValue;
    }

    private void OnDisable()
    {
        _rayDrawer.PathBuilder.PathBuilt -= ChangeTextValue;
    }

    protected override void ChangeTextValue()
    {
        Text.text = _additionalText + (_rayDrawer.GetFinalExtinction() / Constants.ColorAlpha).ToString();
    }
}