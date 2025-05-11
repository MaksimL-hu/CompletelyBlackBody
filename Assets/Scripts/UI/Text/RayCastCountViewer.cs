using UnityEngine;

public class RayCastCountViewer : TextViewer
{
    [SerializeField] private PathBuilder _pathBuilder;
    [SerializeField] private string _additionalText;

    private void OnEnable()
    {
        _pathBuilder.PathBuilt += ChangeTextValue;
    }

    private void OnDisable()
    {
        _pathBuilder.PathBuilt -= ChangeTextValue;
    }

    protected override void ChangeTextValue()
    {
        Text.text = _additionalText + (_pathBuilder.PathPointCount - 1).ToString();
    }
}